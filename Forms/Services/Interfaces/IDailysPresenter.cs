
using QZhihuFind.Models.JsonModels;
using System.Threading.Tasks;

namespace QZhihuFind.Services.Interfaces
{
    interface IDailysPresenter
    {
        Task<DailysModelTotal> GetServiceDailys(string date = null);
        Task<DailysModelTotal> GetClientDailys();

    }
}