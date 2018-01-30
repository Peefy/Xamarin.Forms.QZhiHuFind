using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{

    public class EntryEx : Entry
    {

        #region BottomLineColor

        public static readonly BindableProperty BottomLineColorProperty =
            BindableProperty.Create("BottomLineColor",
                typeof(Color),
                typeof(EntryEx),
                Color.Default,
                propertyChanged: null);

        public Color BottomLineColor
        {
            get => (Color)GetValue(BottomLineColorProperty);
            set => SetValue(BottomLineColorProperty, value);
        }

        #endregion

    }
}
