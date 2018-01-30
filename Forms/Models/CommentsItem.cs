using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DuGu.XFLib.Models;

namespace QZhihuFind.Models
{
    public class CommentsItem : BaseDataObject
    {
        string _userImage;
        string _userName;
        string _comment;
        string _publishTime;
        string _likesCountString;

        public string UserImage
        {
            get { return _userImage; }
            set { SetProperty(ref _userImage, value); }
        }

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public string Comment
        {
            get { return _comment; }
            set { SetProperty(ref _comment, value); }
        }

        public string PublishTime
        {
            get { return _publishTime; }
            set { SetProperty(ref _publishTime, value); }
        }

        public string LikesCountString
        {
            get { return _likesCountString; }
            set { SetProperty(ref _likesCountString, value); }
        }
    }
}
