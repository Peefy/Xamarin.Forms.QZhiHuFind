using System;

namespace QZhihuFind.Models.JsonModels
{
    public class ArticleModel
    {
        /// <summary>
        /// 发表时间
        /// </summary>
        public string PublishedTime { get; set; }
        /// <summary>
        /// 该专栏的创建者信息
        /// </summary>
        public AuthorModel Author { get; set; }
        /// <summary>
        /// 文章网页内容获取
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 文章标题大图url(需要注意的是,titleImage的值有可能为空)，和头像一样，也可以组合不同的尺寸参数获取不同尺寸的图片
        /// </summary>
        public string TitleImage { get; set; }
        /// <summary>
        /// HTML格式的文章内容详情，可以通过WebView或者UIWebView展示内容
        /// </summary>
        public string Content { get; set; }
        public int Slug { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
        public int CommentsCount { get; set; }
        /// <summary>
        /// 赞的数量
        /// </summary>
        public int LikesCount { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}