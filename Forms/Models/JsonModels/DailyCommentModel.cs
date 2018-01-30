using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QZhihuFind.Models.JsonModels
{
    public class DailyCommentModel
    {
        public string author { get; set; }
        public int id { get; set; }
        public string content { get; set; }
        public int likes { get; set; }
        public int time { get; set; }
        public string avatar { get; set; }
    }
}