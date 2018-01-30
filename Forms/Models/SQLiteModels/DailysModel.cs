using SQLite;

namespace QZhihuFind.Models.SQLiteModels
{
    public class DailysModel
    {
        [PrimaryKey, Indexed]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ga_prefix { get; set; }
        public string Date { get; set; }
    }
}