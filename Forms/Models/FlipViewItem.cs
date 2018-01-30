using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DuGu.XFLib.Models;

namespace QZhihuFind.Models
{
    public class FlipViewItem : BaseDataObject
    {

        string _image = "";
        string _text = "";
        string _styleId = "";
        int _storyId = 0;

        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public string StyleId
        {
            get { return _styleId; }
            set { SetProperty(ref _styleId, value); }
        }

        public int StoryId
        {
            get { return _storyId; }
            set { SetProperty(ref _storyId, value); }
        }

    }
}
