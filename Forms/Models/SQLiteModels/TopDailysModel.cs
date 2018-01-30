using SQLite;

namespace QZhihuFind.Models.SQLiteModels
{
    public class TopDailysModel
    {
        [PrimaryKey, Indexed]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ga_prefix { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
    }
}