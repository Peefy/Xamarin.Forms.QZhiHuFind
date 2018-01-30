using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Java.Net;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Graphics;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace DuGu.XFLib.Droid.Extensions
{
	public static class ImageViewExtension
	{
        public static void SetFormsImageSourceButNotUrl(this ImageView imageView,ImageSource source)
		{
            string path;
            Func<CancellationToken, Task<Stream>> stream;
            var type = source.JudgeImageType(out path,out stream);
            if(type == ImageSourceType.None)
            {
                imageView.SetImageResource(17170445);
            }
            else if(type == ImageSourceType.Url)
            {
                imageView.SetImageResource(17170445);
            }
            else if (type == ImageSourceType.Filepath)
            {
                if (path != null)
                    imageView.SetImageDrawable(Forms.Context.Resources.GetDrawable(path));
            }
			else if (type == ImageSourceType.CompileResource)
			{
				if (path != null)
					imageView.SetImageDrawable(Forms.Context.Resources.GetDrawable(path));
			}
		}

	}

	public static class ImageSourceExtension
	{
		public static ImageSourceType Type { get; set; }

		private static void PropertyInit()
		{
			Type = ImageSourceType.None;
		}

		public static ImageSourceType JudgeImageType(this ImageSource source, out string path,
													out Func<CancellationToken, Task<Stream>> stream)
		{
			PropertyInit();
			stream = null;
			var uriImageSource = source as UriImageSource;
            if (uriImageSource != null)
            {
                var uri_temp = uriImageSource.Uri;
                var uri = (uri_temp != null) ? uri_temp.OriginalString : null;
                if (string.IsNullOrEmpty(uri))
                {
                    path = null;
                    return ImageSourceType.None;
                }
                Type = ImageSourceType.Url;
                path = uri;
                return Type;
            }
            var fileImageSource = source as FileImageSource;
            if (fileImageSource != null)
            {
                if (string.IsNullOrWhiteSpace(fileImageSource.File))
                {
                    path = null;
                    return ImageSourceType.None;
                }
                if (!string.IsNullOrWhiteSpace(System.IO.Path.GetDirectoryName(fileImageSource.File)) &&
                    System.IO.File.Exists(fileImageSource.File))
                {
                    Type = ImageSourceType.Filepath;
                    path = fileImageSource.File;
                    return Type;
                }
                Type = ImageSourceType.CompileResource;
                path = fileImageSource.File;
                return Type;
            }
            var streamImageSource = source as StreamImageSource;
            if (streamImageSource != null)
            {
                Type = ImageSourceType.Stream;
                path = "Stream";
                stream = streamImageSource.Stream;
                return Type;
            }
            path = null;
            return Type;
        }

	}

	public enum ImageSourceType
	{
		None,
		Url = 3,
		Filepath = 10,
		ApplicationBundle,
		CompileResource,
		Stream = 20,
	}

}
