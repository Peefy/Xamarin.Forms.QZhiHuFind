using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    public class LabelEx : Label
    {
        #region MaxLines

        public static readonly BindableProperty MaxLinesProperty =
            BindableProperty.Create("MaxLines",
                typeof(int),
                typeof(LabelEx),
                5,
                propertyChanged: null);

        public int MaxLines
        {
            get { return (int)GetValue(MaxLinesProperty); }
            set
            {
                SetValue(MaxLinesProperty, value);
            }
        }

        #endregion

        #region IsHasUnderLine

        public static readonly BindableProperty IsHasUnderLineProperty =
            BindableProperty.Create("IsHasUnderLine",
                typeof(bool),
                typeof(LabelEx),
                false,
                propertyChanged: null);

        public bool IsHasUnderLine
        {
            get { return (bool)GetValue(IsHasUnderLineProperty); }
            set
            {
                SetValue(IsHasUnderLineProperty, value);
            }
        }

        #endregion

        #region IsStrikeThrough

        public static readonly BindableProperty IsStrikeThroughProperty =
            BindableProperty.Create("IsStrikeThrough",
                typeof(bool),
                typeof(LabelEx),
                false,
                propertyChanged: null);

        public bool IsStrikeThrough
        {
            get { return (bool)GetValue(IsStrikeThroughProperty); }
            set
            {
                SetValue(IsStrikeThroughProperty, value);
            }
        }

        #endregion

        #region IsDropShadow

        public static readonly BindableProperty IsDropShadowProperty =
            BindableProperty.Create("IsDropShadow",
                typeof(bool),
                typeof(LabelEx),
                false,
                propertyChanged: null);

        public bool IsDropShadow
        {
            get { return (bool)GetValue(IsDropShadowProperty); }
            set
            {
                SetValue(IsDropShadowProperty, value);
            }
        }

        #endregion

    }
}
