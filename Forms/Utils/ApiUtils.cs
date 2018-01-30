
namespace QZhihuFind.Utils
{
    public class ApiUtils
    {
        public const string ZhuanlanHost = "https://zhuanlan.zhihu.com/api";
        public const string DailyHost = "https://news-at.zhihu.com/api/4";
        /// <summary>
        /// 启动图片
        /// </summary>
        /// <returns></returns>
        public static string GetStartImage()
        {
            return DailyHost + "/start-image/1080*1776";
        }
        /// <summary>
        /// 推荐文章信息
        /// </summary>
        /// <param name="limit">数量限制</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        public static string GetRecommendationArticles(int limit, int offset)
        {
            return ZhuanlanHost + "/recommendations/posts?limit=" + limit + "&offset=" + offset;
        }
        /// <summary>
        /// 文章信息
        /// </summary>
        /// <param name="slug">文章名称</param>
        /// <returns></returns>
        public static string GetArticle(int slug)
        {
            return ZhuanlanHost + "/posts/" + slug;
        }
        /// <summary>
        /// 文章评论
        /// </summary>
        /// <param name="slug">slug</param>
        /// <returns></returns>
        public static string GetArticleComment(int slug, int limit, int offset)
        {
            return ZhuanlanHost + "/posts/" + slug + "/comments?limit=" + limit + "&offset=" + offset;
        }
        /// <summary>
        /// 今日热闻
        /// </summary>
        /// <returns></returns>
        public static string GetDailyLatest()
        {
            return DailyHost + "/news/latest";
        }
        /// <summary>
        /// 今日热闻
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public static string GetDailyBefore(string date)
        {
            return DailyHost + "/news/before/" + date;
        }
        /// <summary>
        /// 日报
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static string GetDaily(int id)
        {
            return DailyHost + "/news/" + id;
        }
        /// <summary>
        /// 日报额外信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static string GetDailyExtra(string id)
        {
            return DailyHost + "/story-extra/" + id;
        }
        /// <summary>
        /// 长评论
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static string GetDailyCommentLong(string id)
        {
            return DailyHost + "/story/" + id + "/long-comments";
        }
        /// <summary>
        /// 短评论
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static string GetDailyCommentShort(string id)
        {
            return DailyHost + "/story/" + id + "/short-comments";
        }
    }
}
