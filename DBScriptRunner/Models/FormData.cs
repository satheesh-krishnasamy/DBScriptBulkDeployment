using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBScriptRunner.Models
{
    public class FormData
    {
        public string DBConnStr { get; set; }
        public string DBServerSelected { get; set; }
        public string DBSelected { get; set; }
        public string SQLObjects { get; set; }
        public string DirectoryName { get; set; }
        public IList<string> DirectoriesRecent { get; set; }
        public IList<string> Databases { get; set; } = new List<string>();
        public IList<string> DBServers { get; set; } = new List<string>();
    }
}
