using SQLite;

namespace QZhihuFind.Models.SQLiteModels
{
    public class DailysImagesModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int DailyId { get; set; }
        public string Images { get; set; }
    }
}