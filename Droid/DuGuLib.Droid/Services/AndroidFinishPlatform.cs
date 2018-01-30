using Android.Content;

using Xamarin.Forms;

using DuGu.XFLib.Services;

[assembly: Dependency(typeof(DuGu.XFLib.Droid.Services.AndroidFinishPlatform))]
namespace DuGu.XFLib.Droid.Services
{
    public class AndroidFinishPlatform : IAndroidFinish
    {
		public void SleepButNotFinish()
		{
			Intent intent = new Intent(Intent.ActionMain);
			intent.SetFlags(ActivityFlags.NewTask);
			intent.AddCategory(Intent.CategoryHome);
			Forms.Context.StartActivity(intent);
		}
    }
}
