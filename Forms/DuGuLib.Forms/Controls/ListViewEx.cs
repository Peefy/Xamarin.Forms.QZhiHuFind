using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    public class ListViewEx : ListView
    {

        #region ScrollBarsVisible

        public static readonly BindableProperty ScrollBarsVisibleProperty =
            BindableProperty.Create("ScrollBarsVisible",
                typeof(bool),
                typeof(ListViewEx),
                true,
                propertyChanged: null);

        public bool ScrollBarsVisible
        {
            get { return (bool)GetValue(ScrollBarsVisibleProperty); }
            set
            {
                SetValue(ScrollBarsVisibleProperty, value);
            }
        }

        #endregion

        #region CanItemsFocus

        public static readonly BindableProperty CanItemsFocusProperty =
            BindableProperty.Create("CanItemsFocusVisible",
                typeof(bool),
                typeof(ListViewEx),
                true,
                propertyChanged: null);

        public bool CanItemsFocus
        {
            get { return (bool)GetValue(CanItemsFocusProperty); }
            set
            {
                SetValue(CanItemsFocusProperty, value);
            }
        }

        #endregion

        #region RefreshColor

        public static readonly BindableProperty RefreshColorProperty =
            BindableProperty.Create("RefreshColor",
                typeof(Color),
                typeof(ListViewEx),
                Color.Default,
                propertyChanged: null);

        public Color RefreshColor
        {
            get { return (Color)GetValue(RefreshColorProperty); }
            set
            {
                SetValue(RefreshColorProperty, value);
            }
        }

        #endregion

    }
}
