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
	public partial class RegisterPage : ContentPage
	{
        RegisterPageViewModel registerPageViewModel;
        public RegisterPage ()
		{
            try
            {
                InitializeComponent();
                registerPageViewModel = new RegisterPageViewModel();
                BindingContext = registerPageViewModel;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
			
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                if (registerPageViewModel != null)
                {
                    registerPageViewModel.OnNationality();
                    NationalityPicker.ItemsSource = registerPageViewModel.NationalityName;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}