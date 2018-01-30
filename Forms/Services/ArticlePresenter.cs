using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using QZhihuFind.Services.Interfaces;
using QZhihuFind.Models.JsonModels;
using QZhihuFind.Utils;
using Newtonsoft.Json;

[assembly: Dependency(typeof(QZhihuFind.Services.ArticlePresenter))]
namespace QZhihuFind.Services
{
    public class ArticlePresenter : IArticlePresenter
    {

        public async Task<ArticleModel> GetServiceArticle(int slug)
        {
            var article = JsonConvert.DeserializeObject<ArticleModel>(
                await WebClientUtils.Instance.GetAsync(ApiUtils.GetArticle(slug)));
            article.UpdateTime = DateTime.Now;
            await Task.Run(() =>
            {
                SQLiteUtils.Instance.UpdateArticle(article);
            });
            return article;

        }

        public async Task<ArticleModel> GetClientArticle(int slug)
        {
            return await Task.Run(() =>
            {
                return SQLiteUtils.Instance.QueryArticle(slug);
            });

        }
    }
}
