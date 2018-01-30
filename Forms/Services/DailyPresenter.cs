using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Newtonsoft.Json;

using QZhihuFind.Services.Interfaces;
using QZhihuFind.Models.JsonModels;
using QZhihuFind.Utils;

[assembly: Dependency(typeof(QZhihuFind.Services.DailyPresenter))]
namespace QZhihuFind.Services
{
    public class DailyPresenter : IDailyPresenter
    {

        public async Task<DailyModel> GetServiceDaily(int id)
        {
            var daily = JsonConvert.DeserializeObject<DailyModel>(
                await WebClientUtils.Instance.GetAsync(ApiUtils.GetDaily(id)));
            await Task.Run(() =>
            {
                SQLiteUtils.Instance.UpdateDaily(daily);
            });
            return daily;
        }

        public async Task<DailyExtraModel> GetServiceDailyExtra(int id)
        {
            var extra = JsonConvert.DeserializeObject<DailyExtraModel>(
                await WebClientUtils.Instance.GetAsync(ApiUtils.GetDailyExtra(id.ToString())));
            extra.id = id;
            await Task.Run(() =>
            {
                SQLiteUtils.Instance.UpdateDailyExtra(extra);
            });
            return extra;
        }

        public async Task<DailyModel> GetClientDaily(int id)
        {
            return await Task.Run(() =>
            {
                return SQLiteUtils.Instance.QueryDaily(id);
            });
        }

        public async Task<DailyExtraModel> GetClientDailyExtra(int id)
        {
            return await Task.Run(() =>
            {
                return SQLiteUtils.Instance.QueryDailyExtra(id);
            });
        }

    }
}
