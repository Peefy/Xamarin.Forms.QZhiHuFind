using QZhihuFind.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Threading.Tasks;


namespace QZhihuFind.Services.Interfaces
{
    public interface IArticlePresenter
    {
        Task<ArticleModel> GetServiceArticle(int slug);
        Task<ArticleModel> GetClientArticle(int slug);
    }
}