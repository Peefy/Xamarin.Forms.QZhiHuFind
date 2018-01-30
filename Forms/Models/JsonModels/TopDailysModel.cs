using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace QZhihuFind.Models.JsonModels
{
    public class TopDailysModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ga_prefix { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
    }
}