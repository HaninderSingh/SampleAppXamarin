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
                try
                {
                    InitializeComponent();
                    registerPageViewModel = new RegisterPageViewModel();
                    BindingContext = registerPageViewModel;
                    this.entryFirstName.Completed += (object sender, EventArgs e) => this.entryLastName.Focus();
                    this.entryLastName.Completed += (object sender, EventArgs e) => this.ContactNoEntry.Focus();
                    this.ContactNoEntry.Completed += (object sender, EventArgs e) => this.emailEntry.Focus();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
              
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