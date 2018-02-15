using SampleAppXamarin.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleAppXamarin.ViewModel
{
    public class MasterPageViewModel : BaseViewModel
    {
        public Command NavigationCommand { get; set; }
        public MasterPageViewModel()
        {
            NavigationCommand = new Command((value) => Navigation(value));
        }
        private void Navigation(object value)
        {
            try
            {
                IsBusy = true;
                MasterDetailPage MasterDetailPage = (Application.Current.MainPage as MasterDetailPage);
                NavigationPage navPage = MasterDetailPage.Detail as NavigationPage;
                MasterDetailPage.IsPresented = false;
                switch (value)
                {
                    case "1":
                        navPage.PushAsync(new RegisterPage());
                        break;
                    case "2":
                        navPage.PushAsync(new UserDetailViewPage());
                        break;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
