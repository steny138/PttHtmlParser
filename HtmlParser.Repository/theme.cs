//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HtmlParser.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class theme
    {
        public int theme_id { get; set; }
        public int board_id { get; set; }
        public string theme_code { get; set; }
        public string theme_name { get; set; }
        public string theme_author { get; set; }
        public string theme_title { get; set; }
        public string theme_content { get; set; }
        public Nullable<int> theme_popularity { get; set; }
        public Nullable<System.DateTime> theme_issue_date { get; set; }
        public string theme_url { get; set; }
        public string theme_desc { get; set; }
    }
}
