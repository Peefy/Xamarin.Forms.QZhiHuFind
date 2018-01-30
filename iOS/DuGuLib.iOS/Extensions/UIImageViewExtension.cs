using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace DuGu.XFLib.iOS.Extensions
{
	public static class UIImageViewExtension
	{
		public static void SetFormsImageSourceButNotUrl(this UIImageView imageView, ImageSource source)
		{
			string path;
            Func<CancellationToken, Task<Stream>> stream;
			var type = source.JudgeImageType(out path,out stream);
			if (type == ImageSourceType.None)
			{
                imageView.Image = null;
			}
            else if (type == ImageSourceType.Stream)
            {
                imageView.Image = null;
            }
			else if (type == ImageSourceType.Url)
			{
                imageView.Image = null;
			}
			else if (type == ImageSourceType.Filepath)
			{
                imageView.Image = new UIImage(path);
			}
            else if(type == ImageSourceType.CompileResource)
            {
			    imageView.Image = new UIImage(path);
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
