

using SQLite;

namespace QZhihuFind.Models.SQLiteModels
{
    public class AuthorModel
    {
        [PrimaryKey, Indexed]
        public string Slug { get; set; }
        public string ProfileUrl { get; set; }
        public string Bio { get; set; }
        public string Hash { get; set; }
        public string Uid { get; set; }
        public bool IsOrg { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public string IdentityDescription { get; set; }
        public string Best_answererIdDescription { get; set; }
    }
}