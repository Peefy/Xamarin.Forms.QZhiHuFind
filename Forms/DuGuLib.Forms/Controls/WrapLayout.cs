using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    /// <summary>
    /// New WrapLayout
    /// </summary>
    /// <author>Jason Smith</author>
    public class WrapLayout : Layout<View>
    {
        Dictionary<View, SizeRequest> layoutCache = new Dictionary<View, SizeRequest>();

        /// <summary>
        /// Backing Storage for the Spacing property
        /// </summary>
        public static readonly BindableProperty SpacingProperty =
            BindableProperty.Create<WrapLayout, double>(w => w.Spacing, 5,
                propertyChanged: (bindable, oldvalue, newvalue) => ((WrapLayout)bindable).layoutCache.Clear());

        /// <summary>
        /// Spacing added between elements (both directions)
        /// </summary>
        /// <value>The spacing.</value>
        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public WrapLayout()
        {
            VerticalOptions = HorizontalOptions = LayoutOptions.FillAndExpand;
        }

        protected override void OnChildMeasureInvalidated()
        {
            base.OnChildMeasureInvalidated();
            layoutCache.Clear();
        }

        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {

            double lastX;
            double lastY;
            var layout = NaiveLayout(widthConstraint, heightConstraint, out lastX, out lastY);

            return new SizeRequest(new Size(lastX, lastY));
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            double lastX, lastY;
            var layout = NaiveLayout(width, height, out lastX, out lastY);

            foreach (var t in layout)
            {
                var offset = (int)((width - t.Last().Item2.Right) / 2);
                foreach (var dingus in t)
                {
                    var location = new Rectangle(dingus.Item2.X + x + offset, dingus.Item2.Y + y, dingus.Item2.Width, dingus.Item2.Height);
                    LayoutChildIntoBoundingRegion(dingus.Item1, location);
                }
            }
        }

        private List<List<Tuple<View, Rectangle>>> NaiveLayout(double width, double height, out double lastX, out double lastY)
        {
            double startX = 0;
            double startY = 0;
            double right = width;
            double nextY = 0;

            lastX = 0;
            lastY = 0;

            var result = new List<List<Tuple<View, Rectangle>>>();
            var currentList = new List<Tuple<View, Rectangle>>();

            foreach (var child in Children)
            {
                SizeRequest sizeRequest;
                if (!layoutCache.TryGetValue(child, out sizeRequest))
                {
                    layoutCache[child] = sizeRequest = child.GetSizeRequest(double.PositiveInfinity, double.PositiveInfinity);
                }

                var paddedWidth = sizeRequest.Request.Width + Spacing;
                var paddedHeight = sizeRequest.Request.Height + Spacing;

                if (startX + paddedWidth > right)
                {
                    startX = 0;
                    startY += nextY;

                    if (currentList.Count > 0)
                    {
                        result.Add(currentList);
                        currentList = new List<Tuple<View, Rectangle>>();
                    }
                }

                currentList.Add(new Tuple<View, Rectangle>(child, new Rectangle(startX, startY, sizeRequest.Request.Width, sizeRequest.Request.Height)));

                lastX = Math.Max(lastX, startX + paddedWidth);
                lastY = Math.Max(lastY, startY + paddedHeight);

                nextY = Math.Max(nextY, paddedHeight);
                startX += paddedWidth;
            }
            result.Add(currentList);
            return result;
        }
    }
}
