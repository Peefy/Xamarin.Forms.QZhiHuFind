using System;
using Foundation;
using UIKit;

using Xamarin.Forms;
using DuGu.XFLib.Services;

[assembly: Dependency(typeof(DuGu.XFLib.iOS.Services.Picture))]
namespace DuGu.XFLib.iOS.Services
{
    public class Picture : IPicture
    {

        public void SavePictureToDisk(string filename, byte[] imageData)
        {
            var image = new UIImage(NSData.FromArray(imageData));
            image.SaveToPhotosAlbum((img,error)=>
            {
                if (error != null)
                    System.Console.WriteLine(error.ToString());
            });
        }
    }
}
