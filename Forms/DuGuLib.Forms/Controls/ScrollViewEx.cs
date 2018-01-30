using System;

using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    public class ScrollViewEx : ScrollView
    {
		#region ScrollBarsVisible

		public static readonly BindableProperty ScrollBarsVisibleProperty =
			BindableProperty.Create("ScrollBarsVisible",
                typeof(bool), typeof(ScrollViewEx),true,
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
	}
}
