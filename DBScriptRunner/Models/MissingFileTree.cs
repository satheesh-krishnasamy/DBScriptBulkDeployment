using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBScriptRunner.Models
{
    class MissingFileTree
    {
        public IList<MissingFileTree> ChildPath { get; private set; } = new List<MissingFileTree>();
        public int ChildCount { get; set; }
        public string PathPartName { get; set; }
    }
}
