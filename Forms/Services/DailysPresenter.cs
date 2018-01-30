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

[assembly: Dependency(typeof(QZhihuFind.Services.DailysPresenter))]
namespace QZhihuFind.Services
{
    public class DailysPresenter : IDailysPresenter
    {

        public async Task<DailysModelTotal> GetServiceDailys(string date = null)
        {
            try
            {
                var dailys = JsonConvert.DeserializeObject<DailysModelTotal>(
                    await WebClientUtils.Instance.GetAsync(
                    date == null ? ApiUtils.GetDailyLatest() : 
                        ApiUtils.GetDailyBefore(date)));
                foreach (var item in dailys.Stories)
                {
                    try
                    {
                            var extra = JsonConvert.DeserializeObject<DailyExtraModel>(
                                await WebClientUtils.Instance.GetAsync(ApiUtils.GetDailyExtra(item.Id.ToString())));
                            item.extra = extra;
  
                    }
                    catch
                    {
                        return null;
                    }
                }
                if (date == null)
                {
                    await Task.Run(() =>
                    {
                        SQLiteUtils.Instance.DeleteAllDailys();
                        SQLiteUtils.Instance.UpdateAllDailys(dailys.Stories);
                        SQLiteUtils.Instance.DeleteAllTopDailys();
                        SQLiteUtils.Instance.UpdateAllTopDailys(dailys.Top_stories);
                    });      
                }
                return dailys;
            }
            catch 
            {
                return null;
            }
        }

        public async Task<DailysModelTotal> GetClientDailys()
        {
            var topdailys = await Task.Run(() =>
            {
                return SQLiteUtils.Instance.QueryAllTopDailys();
            });
            topdailys = topdailys.OrderByDescending(d => d.Id).ToList();
            var dailys = await Task.Run(() =>
            {
                return SQLiteUtils.Instance.QueryAllDailys();
            });
            dailys = dailys.OrderByDescending(d => d.Id).ToList();
            if (topdailys.Count == 0 || dailys.Count == 0)
                return null;
            return new DailysModelTotal()
            {
                Stories = dailys,
                Top_stories = topdailys,
            };
        }

    }
}
