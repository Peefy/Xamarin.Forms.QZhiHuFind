using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QZhihuFind.Models.JsonModels
{
    public class DailyExtraModel
    {
        public int id { get; set; }
        public int long_comments { get; set; }
        public int popularity { get; set; }
        public int short_comments { get; set; }
        public int comments { get; set; }
    }
}