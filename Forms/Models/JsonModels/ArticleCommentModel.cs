using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QZhihuFind.Models.JsonModels
{
    public class ArticleCommentModel
    {
        public string content { get; set; }
        public string href { get; set; }
        public bool liked { get; set; }
        public bool reviewing { get; set; }
        public int inReplyToCommentId { get; set; }
        public string createdTime { get; set; }
        public bool featured { get; set; }
        public int id { get; set; }
        public int likesCount { get; set; }
        public AuthorModel author { get; set; }
    }
}