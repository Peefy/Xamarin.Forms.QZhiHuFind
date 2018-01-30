using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModernHttpClient;
using System.Net.Http;

namespace QZhihuFind.Utils
{
    public class WebClientUtils 
    {
        private static WebClientUtils instance;
        public static WebClientUtils Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (typeof(WebClientUtils))
                    {
                        if (instance == null)
                        {
                            instance = new WebClientUtils();
                        }
                    }
                }
                return instance;
            }
        }

        HttpClient httpClient;

        public WebClientUtils()
        {
            httpClient = new HttpClient(new NativeMessageHandler());
            httpClient.Timeout = TimeSpan.FromSeconds(5);
        }

        public async Task<string> GetAsync(string url)
        {
            return await httpClient.GetStringAsync(url);
        }

    }
}
