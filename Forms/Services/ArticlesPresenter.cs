
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

[assembly: Dependency(typeof(QZhihuFind.Services.ArticlesPresenter))]
namespace QZhihuFind.Services
{
    public class ArticlesPresenter : IArticlesPresenter
    {
        readonly int limit = 10;

        public async Task<List<ArticleModel>> GetServiceArticles(int offset)
        {
            try
            {
                var articles = JsonConvert.DeserializeObject<List<ArticleModel>>(
                    await WebClientUtils.Instance.GetAsync(ApiUtils.GetRecommendationArticles(limit, offset)));
                await Task.Run(() =>
                {
                    SQLiteUtils.Instance.UpdateArticles(articles);
                });
                return articles;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<ArticleModel>> GetClientArticles()
        {
            return await Task.Run(()=>
            {
                return SQLiteUtils.Instance.QueryArticles(limit);
            });
        }

    }
}
