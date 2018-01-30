using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft;
using Newtonsoft.Json;

namespace QZhihuFind.Models.JsonModels
{
    public class DailysModelTotal
    {
        public string Date { get; set; }
        public List<DailysModel> Stories { get; set; }
        public List<TopDailysModel> Top_stories { get; set; }

        [JsonIgnore]
        public DateTime DateTime
        {
            get
            {
                return Date == null ? DateTime.Now : DateTime.ParseExact(Date, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture); 

            }
        }
    }
}
