using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBScriptRunner.Models
{
    class StagedScripts
    {
        public IList<string> ScriptsFilesToRun { get; private set; }
        public string ConnectionString { get; private set; }

        public StagedScripts(string dbConnectionString, IList<string> scriptFilesToExecute)
        {
            this.ScriptsFilesToRun = scriptFilesToExecute;
            this.ConnectionString = dbConnectionString;
        }
    }
}
