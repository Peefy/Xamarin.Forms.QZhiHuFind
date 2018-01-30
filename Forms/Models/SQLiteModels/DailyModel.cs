using System;
using SQLite;

namespace QZhihuFind.Models.SQLiteModels
{
    public class DailyModel
    {
        [PrimaryKey, Indexed]
        public int Id { get; set; }
        public string body { get; set; }
        public string image_source { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string share_url { get; set; }
        public string ga_prefix { get; set; }
        public int type { get; set; }
        public DateTime updatetime { get; set; }
    }
}