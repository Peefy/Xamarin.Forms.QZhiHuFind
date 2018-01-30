using SQLite;

namespace QZhihuFind.Models.SQLiteModels
{
    public class DailyExtraModel
    {
        [PrimaryKey, Indexed]
        public int Id { get; set; }
        public int long_comments { get; set; }
        public int popularity { get; set; }
        public int short_comments { get; set; }
        public int comments { get; set; }
    }
}