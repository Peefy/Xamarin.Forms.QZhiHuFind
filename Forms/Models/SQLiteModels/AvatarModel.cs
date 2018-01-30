
using SQLite;

namespace QZhihuFind.Models.SQLiteModels
{
    public class AvatarModel
    {
        [PrimaryKey, Indexed]
        public string AuthorSlug { get; set; }
        public string Id { get; set; }
        public string Template { get; set; }
    }
}