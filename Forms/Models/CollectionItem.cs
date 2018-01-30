
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DuGu.XFLib.Models;

namespace QZhihuFind.Models
{
    public class CollectionItem : BaseDataObject
    {
        int _idOrSlug = 0;
        string _image = "";
        string _dailyOrArticleImage = "";
        string _dailyOrArticleText = "";

        public int IdOrSlug
        {
            get => _idOrSlug;
            set => SetProperty(ref _idOrSlug, value);
        }

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public string DailyOrArticleImage
        {
            get => _dailyOrArticleImage;
            set => SetProperty(ref _dailyOrArticleImage, value);
        }

        public string DailyOrArticleText
        {
            get => _dailyOrArticleText;
            set => SetProperty(ref _dailyOrArticleText, value);
        }

    }
}
