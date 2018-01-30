using QZhihuFind.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace QZhihuFind.Services.Interfaces
{
    interface IDailyPresenter
    {
        Task<DailyModel> GetServiceDaily(int id);
        Task<DailyExtraModel> GetServiceDailyExtra(int id);
        Task<DailyModel> GetClientDaily(int id);
        Task<DailyExtraModel> GetClientDailyExtra(int id);
    }
}