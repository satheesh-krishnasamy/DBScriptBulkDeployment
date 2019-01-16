using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBScriptRunner.Models
{
    public class GridViewDataModel
    {
        public int FileNo { get; set; }
        public string FilePath { get; set; }
        public bool FileFound { get; set; } = true;
    }
}
