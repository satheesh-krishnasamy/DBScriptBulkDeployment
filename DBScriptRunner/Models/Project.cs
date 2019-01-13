using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBScriptRunner.Models
{
    public class Project
    {
        public string Name { get; set; }
        public string ProjectFileName { get; set; }
        public IList<string> FileNames { get; } = new List<string>();
        public FormData FormData { get; set; }
    }
}
