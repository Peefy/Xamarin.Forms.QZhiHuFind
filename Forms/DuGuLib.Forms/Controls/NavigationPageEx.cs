

using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    public class NavigationPageEx : NavigationPage
    {
        public Page RootPage { get; set; }

        public NavigationPageEx(Page page) : base(page)
        {
            RootPage = page;
        }

        public NavigationPageEx()
        {

        }

        #region MiddleTitleColor

        public static readonly BindableProperty MiddleTitleColorProperty =
            BindableProperty.Create("MiddleTitleColor",
                typeof(Color),
                typeof(NavigationPageEx),
                Color.White,
                propertyChanged: null);

        private static void MiddleTitleColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }
        /// <summary>
        /// (NavigationPageEx)设置toolbar中间文字的颜色
        /// </summary>
        public Color MiddleTitleColor
        {
            get { return (Color)GetValue(MiddleTitleColorProperty); }
            set
            {
                SetValue(MiddleTitleColorProperty, value);
            }
        }

        #endregion

        #region MiddleTitleText

        public static readonly BindableProperty MiddleTitleTextProperty =
            BindableProperty.Create("MiddleTitleText",
                typeof(string),
                typeof(NavigationPageEx),
                "日报",
                propertyChanged: null);

        private static void MiddleTitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }
        /// <summary>
        /// (NavigationPageEx)设置toolbar中间文字的内容
        /// </summary>
        public string MiddleTitleText
        {
            get { return (string)GetValue(MiddleTitleTextProperty); }
            set
            {
                SetValue(MiddleTitleTextProperty, value);
            }
        }

        #endregion

    }
}
