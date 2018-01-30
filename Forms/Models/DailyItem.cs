using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DuGu.XFLib.Models;

namespace QZhihuFind.Models
{
    public class DailyItem : BaseDataObject
    {
        string _image;
        string _text;
        string _commentCountString;
        string _gaPrefix;
        int _storyId;

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

        public string CommentCountString
        {
            get { return _commentCountString; }
            set { SetProperty(ref _commentCountString, value); }
        }

        public string GaPrefix
        {
            get { return _gaPrefix; }
            set { SetProperty(ref _gaPrefix, value); }
        }

        public int StoryId
        {
            get { return _storyId; }
            set { SetProperty(ref _storyId, value); }
        }

    }
}
