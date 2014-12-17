using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Model
{

    public class PttGroupCollection
    {
        public PttGroupCollection()
        {
            _groups = new List<PttGroup>();
            _boards = new List<PttBoard>();
        }
        private List<PttGroup> _groups;
        public List<PttGroup> groups { get { return _groups; } }

        private List<PttBoard> _boards;
        public List<PttBoard> boards { get { return _boards; } }
    }

    public class PttGroup
    {
        public PttGroup()
        {
            this.id = 0;
            this.code = string.Empty;
            this.name = string.Empty;
            this.desc = string.Empty;
        }

        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
    }
}
