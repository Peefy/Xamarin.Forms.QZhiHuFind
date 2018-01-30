using SQLite;

namespace QZhihuFind.Models.SQLiteModels
{
    public class DailyJsModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int DailyId { get; set; }
        public string js { get; set; }
    }
}