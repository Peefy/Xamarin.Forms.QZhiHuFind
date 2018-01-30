using SQLite;

namespace QZhihuFind.Models.SQLiteModels
{
    public class DailyCssModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int DailyId { get; set; }
        public string css { get; set; }
    }
}