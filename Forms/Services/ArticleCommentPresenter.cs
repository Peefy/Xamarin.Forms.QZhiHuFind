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

[assembly: Dependency(typeof(QZhihuFind.Services.ArticleCommentPresenter))]
namespace QZhihuFind.Services
{
    public class ArticleCommentPresenter : IArticleCommentPresenter
    {
        private int limit = 10;

        public async Task<List<ArticleCommentModel>> GetComment(int slug, int offset)
        {
            try
            {
                var comments = JsonConvert.DeserializeObject<List<ArticleCommentModel>>
                    (await WebClientUtils.Instance.GetAsync(ApiUtils.GetArticleComment(slug, limit, offset)));
                return comments;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
