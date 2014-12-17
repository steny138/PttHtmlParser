using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Model
{
    public class PttBoard
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string manager { get; set; }
        public int popularity { get; set; }
    }
}
