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

[assembly: Dependency(typeof(QZhihuFind.Services.DailyCommentPresenter))]
namespace QZhihuFind.Services
{
    public class DailyCommentPresenter : IDailyCommentPresenter
    {
        public async Task<List<DailyCommentModel>> GetComment(string id)
        {
            var comments = new List<DailyCommentModel>();
            try
            {
                var longs = JsonConvert.DeserializeObject<Comments>(
                    await WebClientUtils.Instance.GetAsync(ApiUtils.GetDailyCommentLong(id)));
                comments.AddRange(longs.comments);

                var shorts = JsonConvert.DeserializeObject<Comments>(
                    await WebClientUtils.Instance.GetAsync(ApiUtils.GetDailyCommentShort(id)));
                comments.AddRange(shorts.comments);
                return comments;
            }
            catch 
            {
                return comments;
            }
           
        }
        private class Comments
        {
            public List<DailyCommentModel> comments { get; set; }
        }
    }
}
