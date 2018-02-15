using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using MessageBar;
using SampleAppXamarin.Interfaces;
using SampleAppXamarin.iOS.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastNotifier))]
namespace SampleAppXamarin.iOS.Services
{
    public class ToastNotifier : IToastNotifier
    {
        static MessageBarStyleSheet _styleSheet;

        public static void Init()
        {
            _styleSheet = new MessageBarStyleSheet();
        }

        public Task<bool> Notify(ToastNotificationType type, string title, string description, TimeSpan duration,
            object context = null)
        {
            MessageType msgType = MessageType.Info;

            switch (type)
            {
                case ToastNotificationType.Error:
                case ToastNotificationType.Warning:
                    msgType = MessageType.Error;
                    break;

                case ToastNotificationType.Success:
                    msgType = MessageType.Success;
                    break;
            }

            var taskCompletionSource = new TaskCompletionSource<bool>();
            MessageBarManager.SharedInstance.ShowMessage(title, description, msgType,
                b => taskCompletionSource.TrySetResult(b));
            return taskCompletionSource.Task;
        }

        public void HideAll()
        {
            MessageBarManager.SharedInstance.HideAll();
        }
    }
}
