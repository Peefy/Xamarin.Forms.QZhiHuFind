using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace QZhihuFind.Models.JsonModels
{
    public class DailysModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ga_prefix { get; set; }
        public List<string> Images { get; set; }
        public string Date { get; set; }
        public DailyExtraModel extra { get; set; }
    }
}