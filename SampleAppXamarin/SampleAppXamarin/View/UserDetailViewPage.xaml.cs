using SampleAppXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleAppXamarin.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetailViewPage : ContentPage
	{
        UserDetailViewModel userDetailViewModel;
        public UserDetailViewPage ()
		{
			InitializeComponent ();
            userDetailViewModel = new UserDetailViewModel();
            BindingContext = userDetailViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
               if(userDetailViewModel != null)
                {
                    userDetailViewModel.OnUserlist();
                    Userlist.ItemsSource = userDetailViewModel.UserDetaillist;
               }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}