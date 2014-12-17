using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Model
{
    public class PttBoard
    {
        public PttBoard()
        {
            this.id = 0;
            this.code = string.Empty;
            this.name = string.Empty;
            this.desc = string.Empty;
            this.manager = string.Empty;
            this.popularity = 0;
        }
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string manager { get; set; }
        public int popularity { get; set; }
    }
}
