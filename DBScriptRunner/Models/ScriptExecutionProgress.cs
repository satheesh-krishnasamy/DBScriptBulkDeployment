using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBScriptRunner.Models
{
    internal class ScriptExecutionProgress
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string FileName { get; set; }
        public int ReportCount { get; set; }
        public int CurrentFileProgress { get; set; }
    }
}
