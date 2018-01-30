using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    /// <summary>
    /// Creates a button with text and an image.
    /// The image can be on the left, above, on the right or below the text.
    /// </summary>
    public class ImageButton : Button
    {
        /// <summary>
        /// Backing field for the Image property.
        /// </summary>
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
            "Source", typeof(ImageSource), typeof(ImageButton),
            null,
            BindingMode.OneWay,
            null,
            (bindable, oldvalue, newvalue) => ((VisualElement)bindable).ToString());

        /// <summary>
        /// Backing field for the Image property.
        /// </summary>
        public static readonly BindableProperty DisabledSourceProperty = BindableProperty.Create(
            "DisabledSource", typeof(ImageSource), typeof(ImageButton),
            null,
            BindingMode.OneWay,
            null,
            (bindable, oldvalue, newvalue) => ((VisualElement)bindable).ToString());

        /// <summary>
        /// Backing field for the image width property.
        /// </summary>
        public static readonly BindableProperty ImageWidthRequestProperty =
            BindableProperty.Create(
                "ImageWidthRequest", typeof(int), typeof(ImageButton), default(int));

        /// <summary>
        /// Backing field for the image height property.
        /// </summary>
        public static readonly BindableProperty ImageHeightRequestProperty =
            BindableProperty.Create(
                "ImageHeightRequest", typeof(int), typeof(ImageButton), default(int));

        /// <summary>
        /// Backing field for the orientation property.
        /// </summary>
        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create(
                "Orientation", typeof(ImageOrientation), typeof(ImageButton), ImageOrientation.ImageToLeft);

        /// <summary>
        /// Backing field for the tint color property.
        /// </summary>
        public static readonly BindableProperty ImageTintColorProperty =
            BindableProperty.Create(
                "ImageTintColor", typeof(Color), typeof(ImageButton), Color.Transparent);

        /// <summary>
        /// Backing field for the disbaled tint color property.
        /// </summary>
        public static readonly BindableProperty DisabledImageTintColorProperty =
            BindableProperty.Create(
                "DisabledImageTintColor", typeof(Color), typeof(ImageButton), Color.Transparent);

        /// <summary>
        /// Gets or sets the ImageSource to use with the control.
        /// </summary>
        /// <value>
        /// The Source property gets/sets the value of the backing field, SourceProperty.
        /// </value>
        [TypeConverter(typeof(ImageSourceConverter))]
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets the ImageSource to use with the control.
        /// </summary>
        /// <value>
        /// The Source property gets/sets the value of the backing field, SourceProperty.
        /// </value>
        [TypeConverter(typeof(ImageSourceConverter))]
        public ImageSource DisabledSource
        {
            get { return (ImageSource)GetValue(DisabledSourceProperty); }
            set { SetValue(DisabledSourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets The orientation of the image relative to the text.
        /// </summary> 
        /// <value>
        /// The Orientation property gets/sets the value of the backing field, OrientationProperty.
        /// </value> 
        public ImageOrientation Orientation
        {
            get { return (ImageOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// Gets or sets the requested height of the image.  If less than or equal to zero than a 
        /// height of 50 will be used.
        /// </summary>
        /// <value>
        /// The ImageHeightRequest property gets/sets the value of the backing field, ImageHeightRequestProperty.
        /// </value> 
        public int ImageHeightRequest
        {
            get { return (int)GetValue(ImageHeightRequestProperty); }
            set { SetValue(ImageHeightRequestProperty, value); }
        }

        /// <summary>
        /// Gets or sets the requested width of the image.  If less than or equal to zero than a 
        /// width of 50 will be used.
        /// </summary>
        /// <value>
        /// The ImageHeightRequest property gets/sets the value of the backing field, ImageHeightRequestProperty.
        /// </value> 
        public int ImageWidthRequest
        {
            get { return (int)GetValue(ImageWidthRequestProperty); }
            set { SetValue(ImageWidthRequestProperty, value); }
        }

        /// <summary>
        /// Gets or sets the tint color of the image 
        /// </summary>
        /// <value>
        /// The ImageTintColor property gets/sets the value of the backing field, ImageTintColorProperty.
        /// </value> 
        public Color ImageTintColor
        {
            get { return (Color)GetValue(ImageTintColorProperty); }
            set { SetValue(ImageTintColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the tint color of the image when the button is disabled
        /// </summary>
        /// <value>
        /// The DisabledImageTintColor property gets/sets the value of the backing field, DisabledImageTintColorProperty.
        /// </value> 
        public Color DisabledImageTintColor
        {
            get { return (Color)GetValue(DisabledImageTintColorProperty); }
            set { SetValue(DisabledImageTintColorProperty, value); }
        }
    }
    /// <summary>
    /// Specifies where the image will occur relative to the text on a
    /// </summary>
    public enum ImageOrientation
    {
        /// <summary>
        /// The image to left
        /// </summary>
        ImageToLeft = 0,
        /// <summary>
        /// The image on top
        /// </summary>
        ImageOnTop = 1,
        /// <summary>
        /// The image to right
        /// </summary>
        ImageToRight = 2,
        /// <summary>
        /// The image on bottom
        /// </summary>
        ImageOnBottom = 3,
        /// <summary>
        /// The image centered
        /// </summary>
        ImageCentered = 4
    }

}
