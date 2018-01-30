using QZhihuFind.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZhihuFind.Services.Interfaces
{
    public interface IArticlesPresenter
    {
        Task<List<ArticleModel>> GetServiceArticles(int offset);
        Task<List<ArticleModel>> GetClientArticles();
    }
}