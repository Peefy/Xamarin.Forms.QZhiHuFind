using QZhihuFind.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace QZhihuFind.Services.Interfaces
{
    interface IDailyCommentPresenter
    {
        Task<List<DailyCommentModel>> GetComment(string id);
    }
}