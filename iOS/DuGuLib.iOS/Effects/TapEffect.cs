﻿using System;
using System.Diagnostics;
using DuGu.XFLib.iOS.Effects;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(TapEffect), "TapEffect")]
namespace DuGu.XFLib.iOS.Effects
{
	public class TapEffect : PlatformEffect
	{

		private MyTap Reg;

		protected override void OnAttached()
		{
			this.Reg = new MyTap();
			this.Container.AddGestureRecognizer(this.Reg);
		}

		protected override void OnDetached()
		{
			this.Container.RemoveGestureRecognizer(this.Reg);
			this.Reg.Dispose();
		}

		public class RadialGradientLayer : CALayer
		{

			[Export("center")]
			public CGPoint Center { get; set; }

			[Export("radius")]
			public nfloat Radius { get; set; }


			public RadialGradientLayer()
			{
                
			}

			//MUST
			[Export("initWithLayer:")]
			public RadialGradientLayer(CALayer other) : base(other)
			{
			}

			public override void DrawInContext(CGContext ctx)
			{
				base.DrawInContext(ctx);
				//Debug.WriteLine($"---{this.Radius}");

				//每四个一组 表示一个颜色 ｛r,g,b,a ,r,g,b,a｝
				//var components = new nfloat[] { 1, 1, 1, 1, 1, 1, 1, 0 };
                var colors = new CGColor[] 
                { 
                    new CGColor(0.49f, 0.49f, 0.49f, 0.5f), 
                    new CGColor(0.78f, 0.78f, 0.78f, 0.2f),
				};

				//表示渐变的开始位置
				var locations = new nfloat[] { 0f, 1f };

				var startCenter = this.Center;//new CGPoint(100, 100);

				var endCenter = this.Center;//new CGPoint(100, 100);

				nfloat startRadius = 0f;
				//nfloat endRadius = (nfloat)Math.Min(this.Frame.Width, this.Frame.Height) / 1.3f;
				nfloat endRadius = this.Radius;

				using (var colorSpace = CGColorSpace.CreateDeviceRGB())
				using (var gradient = new CGGradient(colorSpace, colors, locations))
				{
					ctx.DrawRadialGradient(gradient,
										   startCenter,
										   startRadius,
										   endCenter,
										   endRadius,
										   CGGradientDrawingOptions.DrawsAfterEndLocation);
				}
			}

			//MUST
			[Export("needsDisplayForKey:")]
			static bool NeedsDisplayForKey(NSString key)
			{
				switch (key.ToString())
				{
					case "radius":
					case "center":
						return true;
					default:
						return CALayer.NeedsDisplayForKey(key);
				}
			}


			public override void Clone(CALayer other)
			{
				var o = (RadialGradientLayer)other;
				Radius = o.Radius;
				Center = o.Center;
				base.Clone(other);
			}
		}



		public class MyTap : UITapGestureRecognizer
		{

			private RadialGradientLayer Layer = null;

			private void SetAni(float from, float to, double duration = 0.3)
			{
				this.Layer.RemoveAnimation("radius");
				using (var ani = CABasicAnimation.FromKeyPath("radius"))
				{
					ani.Duration = duration;
					ani.From = NSNumber.FromNFloat(from);
					ani.To = NSNumber.FromFloat(to);
					//ani.SetTo(NSNumber.FromFloat(to));
					ani.AutoReverses = false;
					ani.RepeatCount = 1;
					//http://www.jianshu.com/p/02c341c748f9
					ani.RemovedOnCompletion = false;
                    ani.FillMode = CAFillMode.Backwards;

					ani.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
					this.Layer.AddAnimation(ani, "radius");
				}
			}

			public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
			{
				base.TouchesBegan(touches, evt);

				if (this.Layer == null)
				{
					this.Layer = new RadialGradientLayer();
					this.Layer.Frame = new CGRect(0, 0, this.View.Frame.Width, this.View.Frame.Height);

                    this.View.Layer.FillMode = CAFillMode.Forwards;
					this.View.Layer.AddSublayer(this.Layer);

				}

				var t = (UITouch)touches.AnyObject;
				var point = t.LocationInView(this.View);
				this.Layer.Center = point;

				this.SetAni(0, 200);
			}

			public override bool CanPreventGestureRecognizer(UIGestureRecognizer preventedGestureRecognizer)
			{
				return false;
			}

			public override void TouchesEnded(Foundation.NSSet touches, UIEvent evt)
			{
				base.TouchesEnded(touches, evt);
				if (this.Layer != null)
				{
					//this.Layer.RemoveFromSuperLayer();
					//this.SetAni(200, 0);
				}
			}

			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
				if (disposing && this.Layer != null)
				{
					this.Layer.Dispose();
					this.Layer = null;
				}
			}
		}
	}
}
