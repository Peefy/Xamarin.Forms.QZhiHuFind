using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DuGu.XFLib.Animations
{
    public static class AnimationExtension
    {
        public static async void Animate(this VisualElement visualElement, AnimationBase animation, Action onFinishedCallback = null)
        {
            animation.Target = visualElement;
            await animation.Begin();
            onFinishedCallback?.Invoke();
        }
    }
}
