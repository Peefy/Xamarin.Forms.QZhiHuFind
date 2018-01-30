using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace QZhiHuFind.Droid
{
    [Activity(Label = "Q发现知乎",
        Icon = "@drawable/icon",
        MainLauncher = true,
        NoHistory = true,
        Theme = "@style/Theme.Splash",
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            InvokeMainActivity();
        }

        /// <summary>
        /// 启动工作的Activity
        /// </summary>
        private void InvokeMainActivity()
        {
            var mainActivityIntent = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivityIntent);
            this.Finish();
        }
    }
}