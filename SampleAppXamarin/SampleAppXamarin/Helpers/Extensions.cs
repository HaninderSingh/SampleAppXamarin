using SampleAppXamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SampleAppXamarin.Helpers
{
    public static partial class Extensions
    {
        public static void ToToast(this string message, ToastNotificationType type = ToastNotificationType.Info, string title = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var toaster = DependencyService.Get<IToastNotifier>();
                toaster.Notify(type, title ?? type.ToString().ToUpper(), message, TimeSpan.FromSeconds(2.5f));
            });
        }
    }
}
