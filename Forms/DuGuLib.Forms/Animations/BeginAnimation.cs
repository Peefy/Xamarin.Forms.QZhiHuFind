using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DuGu.XFLib.Animations
{
    class BeginAnimation : TriggerAction<VisualElement>
    {
        public AnimationBase Animation { get; set; }

        protected override async void Invoke(VisualElement sender)
        {
            if (Animation != null)
                await Animation.Begin();
        }
    }
}
