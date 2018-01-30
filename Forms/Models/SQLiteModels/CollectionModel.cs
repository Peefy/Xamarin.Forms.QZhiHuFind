
using SQLite;
using System;

namespace QZhihuFind.Models.SQLiteModels
{
    public class CollectionModel
    {
        [PrimaryKey]
        public int IdOrSlug { get; set; }
        public string Title { get; set; } 
        public string Image { get; set; }
        public string DailyOrArticleImage { get; set; }
    }
}
