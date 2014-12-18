using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Model
{
    /// <summary>文章類別</summary>
    public class PttTheme
    {
        public PttTheme()
        {
            this.id = 0;
            this.boardId = 0;
            this.code = string.Empty;
            this.boardName = string.Empty;
            this.title = string.Empty;
            this.content = string.Empty;
            this.desc = string.Empty;
            this.author = string.Empty;
            this.popularity = string.Empty;
            this.issueDate = DateTime.MinValue;
            this._pushContents = new List<PttThemePush>();
        }

        public int id { get; set; }
        public string code { get; set; }

        public int boardId { get; set; }
        public string boardName { get; set; }

        public string content { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public string author { get; set; }
        public string popularity { get; set; }
        public string url { get; set; }
        public DateTime issueDate { get; set; }

        private List<PttThemePush> _pushContents;
        public List<PttThemePush> pushContents { get { return _pushContents; } }
    }

    /// <summary>推文類別</summary>
    public class PttThemePush
    {
        public PttThemePush()
        {
            this.author = string.Empty;
            this.content = string.Empty;
            this.pushType = PushType.normal;
            this.pushDate = DateTime.MinValue;
        }
        public PushType pushType { get; set; }
        public string author { get; set; }
        public string content { get; set; }
        public DateTime pushDate { get; set; }
    }

    /// <summary>推文狀態</summary>
    public enum PushType
    {
        push, boos, normal
    }
}
