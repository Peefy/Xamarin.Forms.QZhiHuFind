using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QZhihuFind.Models.JsonModels
{
    public class BestAnswererModel 
    {
        /// <summary>
        /// ����
        /// </summary>
        public IList<int> Topics { get; set; }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string Description { get; set; }
    }
}