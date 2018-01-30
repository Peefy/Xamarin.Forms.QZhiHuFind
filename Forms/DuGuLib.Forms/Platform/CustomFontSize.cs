using System;

using Xamarin.Forms;

namespace DuGu.XFLib.Platform
{
    public static class CustomFontSize
    {
        public static double LittleSize
        {
            get 
            {
                switch(Device.RuntimePlatform)
                {
                    case Device.Android:
                        return 12;
                    case Device.iOS:
                        return 11;
                    case Device.UWP:
                        return 12;
                    case Device.WinPhone:
                        return 12;
                    default:
                        return 12;
                }
            }
        }

		public static double MidMediumSize
		{
			get
			{
				switch (Device.RuntimePlatform)
				{
					case Device.Android:
						return 14;
					case Device.iOS:
						return 12;
                    case Device.UWP:
						return 14;
					case Device.WinPhone:
						return 14;
					default:
						return 13;
				}
			}
		}

		public static double MediumSize
		{
			get
			{
				switch (Device.RuntimePlatform)
				{
					case Device.Android:
						return 16;
					case Device.iOS:
						return 14;
                    case Device.UWP:
						return 16;
					case Device.WinPhone:
						return 16;
					default:
						return 15;
				}
			}
		}

		public static double LargeSize
		{
			get
			{
				switch (Device.RuntimePlatform)
				{
					case Device.Android:
						return 18;
					case Device.iOS:
						return 16;
                    case Device.UWP:
						return 18;
					case Device.WinPhone:
						return 18;
					default:
						return 17;
				}
			}
		}

		public static double LargerSize
		{
			get
			{
				switch (Device.RuntimePlatform)
				{
					case Device.Android:
						return 20;
					case Device.iOS:
						return 18;
                    case Device.UWP:
						return 20;
					case Device.WinPhone:
						return 20;
					default:
						return 19;
				}
			}
		}

		public static double BigSize
		{
			get
			{
				switch (Device.RuntimePlatform)
				{
					case Device.Android:
						return 24;
					case Device.iOS:
						return 20;
                    case Device.UWP:
						return 24;
					case Device.WinPhone:
						return 24;
					default:
						return 22;
				}
			}
		}

		public static double ExtraBigSize
		{
			get
			{
				switch (Device.RuntimePlatform)
				{
					case Device.Android:
						return 32;
					case Device.iOS:
						return 24;
                    case Device.UWP:
						return 32;
					case Device.WinPhone:
						return 32;
					default:
						return 28;
				}
			}
		}

    }
}
