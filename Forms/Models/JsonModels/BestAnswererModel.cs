using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QZhihuFind.Models.JsonModels
{
    public class BestAnswererModel 
    {
        /// <summary>
        /// 话题
        /// </summary>
        public IList<int> Topics { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }
    }
}