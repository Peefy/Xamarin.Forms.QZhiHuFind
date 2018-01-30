
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuGu.XFLib.Models;

namespace QZhihuFind.Models
{
    public class ArticleItem : BaseDataObject
    {
        string _text;
        string _publishedTime;
        string _titleImage;
        string _summary;
        string _userImage;
        string _userName;
        string _updateTimeString;
        string _badgeImage;
        bool _isHasTitleImage;
        int _slug;

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public string PublishedTime
        {
            get { return _publishedTime; }
            set { SetProperty(ref _publishedTime, value); }
        }

        public string TitleImage
        {
            get { return _titleImage; }
            set { SetProperty(ref _titleImage, value); }
        }

        public string Summary
        {
            get { return _summary; }
            set { SetProperty(ref _summary, value); }
        }

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

        public string UpdateTimeString
        {
            get { return _updateTimeString; }
            set { SetProperty(ref _updateTimeString, value); }
        }

        public string BadgeImage
        {
            get { return _badgeImage; }
            set { SetProperty(ref _badgeImage, value); }
        }

        public bool IsHasTitleImage
        {
            get { return _isHasTitleImage; }
            set { SetProperty(ref _isHasTitleImage, value); }
        }

        public int Slug
        {
            get { return _slug; }
            set { SetProperty(ref _slug, value); }
        }

    }
}
