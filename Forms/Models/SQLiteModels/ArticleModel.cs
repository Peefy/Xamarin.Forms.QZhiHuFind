
using SQLite;
using System;

namespace QZhihuFind.Models.SQLiteModels
{
    public class ArticleModel
    {
        [PrimaryKey, Indexed]
        public int Slug { get; set; }
        public string PublishedTime { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string TitleImage { get; set; }
        public string Content { get; set; }
        public int CommentsCount { get; set; }
        public int LikesCount { get; set; }
        public DateTime UpdateTime { get; set; }
        public string AuthorSlug { get; set; }
    }
}