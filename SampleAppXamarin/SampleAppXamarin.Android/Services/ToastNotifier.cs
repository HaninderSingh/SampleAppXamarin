using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SampleAppXamarin.Droid.Services;
using SampleAppXamarin.Interfaces;
using Xamarin.Forms;
[assembly: Dependency(typeof(ToastNotifier))]
namespace SampleAppXamarin.Droid.Services
{
    public class ToastNotifier : IToastNotifier
    {
        public Task<bool> Notify(ToastNotificationType type, string title, string description, TimeSpan duration, object context = null)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            Android.Widget.Toast.MakeText(Forms.Context, description, ToastLength.Short).Show();
            return taskCompletionSource.Task;
        }

        public void HideAll()
        {
        }
    }
}