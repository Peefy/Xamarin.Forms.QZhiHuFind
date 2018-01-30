
using Android.Content;
using Android.Net;
using Java.IO;

using Xamarin.Forms;

using DuGu.XFLib.Services;
using System;

[assembly: Dependency(typeof(DuGu.XFLib.Droid.Services.Picture))]
namespace DuGu.XFLib.Droid.Services
{
    public class Picture : IPicture
    {
        public void SavePictureToDisk(string filename, byte[] imageData)
        {
            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory
                             (Android.OS.Environment.DirectoryDcim);
            var pictures = dir.AbsolutePath;
            var name = filename + ".jpg";
            var filePath = System.IO.Path.Combine(pictures, name);
            try
            {
                System.IO.File.WriteAllBytes(filePath,imageData);
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new File(filePath)));
                Forms.Context.SendBroadcast(mediaScanIntent);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
    }
}
