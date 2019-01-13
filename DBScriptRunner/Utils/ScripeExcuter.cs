using DBScriptRunner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBScriptRunner.Utils
{
    internal class ScripeExcuter
    {
        private readonly IList<string> Files;
        public bool ThrowIfOneFileFails { get; set; }
        public BackgroundWorker Worker { get; private set; }
        public string DBConnectionString { get; private set; }

        public ScripeExcuter(
            BackgroundWorker worker,
            IList<string> files,
            string connString)
        {
            this.Worker = worker;
            this.Files = files;
            this.DBConnectionString = connString;
        }

        public void ReportProgress(
            int overallPercentage,
            string fileName,
            int currentFileCompletedPercentage,
            string message,
            bool isSuccess)
        {
            var scriptExecutionProgress = new ScriptExecutionProgress()
            {
                Success = isSuccess,
                FileName = fileName,
                ReportCount = 0,
                CurrentFileProgress = currentFileCompletedPercentage,
                Message = message
            };

            Worker.ReportProgress(overallPercentage, scriptExecutionProgress);
            //message = string.Empty;
        }

        public void ExecuteScripts(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;

            ReportProgress(0, "", 1, "Starting in few seconds...", true);

            Task.Delay(3000).GetAwaiter().GetResult();

            var completedFiles = 0;
            int overallProgress = 0;
            int currentFileProgressPercentage = 0;

            var successScriptsCount = 0;

            var overallProgressMessage = string.Empty;
            var isOverallSuccess = true;

            try
            {
                foreach (string sqlScriptFile in this.Files)
                {
                    if (helperBW.CancellationPending)
                    {
                        e.Cancel = true;
                        throw new Exception(" User cancelled.");
                    }

                    var progressMessage = string.Empty;
                    var isSuccess = true;
                    currentFileProgressPercentage = 0;

                    //var currentSqlfileExecutionResult = Task.Run<FileExecutionResult>(() =>
                    Task.Run(() =>
                    {
                        try
                        {
                            //FileExecutionResult fileExecutionResult = new FileExecutionResult();

                            progressMessage =
                                Environment.NewLine + "----------------- Executing ------------------------ "
                                + Environment.NewLine + sqlScriptFile;

                            currentFileProgressPercentage = 5;
                            ReportProgress(overallProgress, sqlScriptFile, currentFileProgressPercentage, progressMessage, isSuccess);

                            string script = File.ReadAllText(sqlScriptFile);

                            // split script on GO command
                            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                                     RegexOptions.Multiline | RegexOptions.IgnoreCase);


                            using (SqlConnection Connection = new SqlConnection(this.DBConnectionString))
                            {
                                Connection.Open();
                                Connection.InfoMessage += delegate (object sender1, SqlInfoMessageEventArgs msgEvent)
                                {


                                    var hasError = (msgEvent.Errors != null && msgEvent.Errors.Count > 0);

                                    if (hasError)
                                    {
                                        isSuccess = false;
                                        progressMessage = string.Empty;
                                        foreach (var error in msgEvent.Errors)
                                        {
                                            progressMessage += Environment.NewLine + error;
                                        }

                                    }

                                    progressMessage = Environment.NewLine + msgEvent.Message;
                                    ReportProgress(overallProgress, sqlScriptFile, 25, progressMessage, isSuccess);

                                };
                                foreach (string commandString in commandStrings)
                                {
                                    if (commandString.Trim() != "")
                                    {
                                        using (var command = new SqlCommand(commandString, Connection))
                                        {
                                            command.ExecuteNonQuery();
                                        }
                                    }
                                }
                                Connection.Close();
                            }

                            //var i = 0;
                            //while (i < int.MaxValue - 1) { i++; }

                            progressMessage = Environment.NewLine + "----------------- Completed ------------------------ ";
                            //ReportProgress(overallProgress, sqlScriptFile, 100, progressMessage, isSuccess);

                            successScriptsCount++;

                        }
                        catch (Exception exp)
                        {

                            progressMessage = Environment.NewLine + sqlScriptFile + " has error : " + exp.Message
                            + Environment.NewLine + "----------------- Completed (with errors) ------------------------ ";
                            isSuccess = false;

                            if (this.ThrowIfOneFileFails)
                                throw;
                        }
                        finally
                        {
                            overallProgress = (int)Math.Round((++completedFiles / (double)this.Files.Count) * 100.0, 0);
                            ReportProgress(overallProgress, sqlScriptFile, 100, progressMessage, isSuccess);
                        }
                    }).GetAwaiter().GetResult();
                }

                overallProgressMessage += Environment.NewLine + " Finished all. Completed file count: " + completedFiles.ToString();
            }
            catch (Exception expOut)
            {
                overallProgressMessage += Environment.NewLine + " Failure: " + expOut.Message;
            }
            finally
            {
                ReportProgress(100, "", 100, overallProgressMessage, isOverallSuccess);
            }

        }

    }
}
