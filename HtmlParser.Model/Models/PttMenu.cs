using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Model
{
    class PttMenu
    {
        public PttMenu()
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
