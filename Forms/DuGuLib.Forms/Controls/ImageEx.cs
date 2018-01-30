using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    public class ImageEx : Image
    {
        #region ColorFilter

        public static readonly BindableProperty ColorFilterProperty =
            BindableProperty.Create("ColorFilter",
                typeof(Color),
                typeof(ImageEx),
                Color.Default,
                propertyChanged: null);

        public Color ColorFilter
        {
            get { return (Color)GetValue(ColorFilterProperty); }
            set
            {
                SetValue(ColorFilterProperty, value);
            }
        }

        #endregion

    }
}
