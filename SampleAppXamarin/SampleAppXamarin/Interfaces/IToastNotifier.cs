using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppXamarin.Interfaces
{
    public interface IToastNotifier
    {
        //void Show(string message);
        Task<bool> Notify(ToastNotificationType type, string title, string description, TimeSpan duration, object context = null);

        void HideAll();
    }
    public enum ToastNotificationType
    {
        Info,
        Success,
        Error,
        Warning,
    }
}
