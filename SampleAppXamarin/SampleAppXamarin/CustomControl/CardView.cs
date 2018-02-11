using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SampleAppXamarin.CustomControl
{
    public class CardView : Frame
    {
        public CardView()
        {
            Padding = 0;
            CornerRadius = 8;
            if (Device.RuntimePlatform == Device.iOS)
            {
                HasShadow = false;
            }
        }
    }
}
