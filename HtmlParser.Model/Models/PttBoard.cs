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
            this.groupId = 0;
            this.id = 0;
            this.code = string.Empty;
            this.name = string.Empty;
            this.desc = string.Empty;
            this.manager = string.Empty;
            this.popularity = string.Empty;
            this.issueDate = DateTime.MinValue;
        }
        public int groupId { get; set; }
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string manager { get; set; }
        public string popularity { get; set; }
        public DateTime issueDate { get; set; }
    }
}
