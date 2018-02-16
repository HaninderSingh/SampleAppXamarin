using SampleAppXamarin.Model;
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
    public partial class ConfirmationPage : ContentPage
    {
        ConfirmationPageViewModel confirmationPageViewModel;
        UserDetailModel UserDetailModel;
        public event EventHandler Navigate;
        public ConfirmationPage(RegisterPageViewModel register)
        {
            try
            {
                InitializeComponent();
                UserDetailModel = new UserDetailModel()
                {
                    FirstName = register.firstName,
                    LastName = register.lastName,
                    ContactNo = register.contact,
                    Email = register.emailAddress,
                    Maritalstatus = register.maritialstatus,
                    Nationality = register.nationality,
                    Sex = register.sex,
                };
                confirmationPageViewModel = new ConfirmationPageViewModel(UserDetailModel);
                BindingContext = confirmationPageViewModel.UserDetail;
                confirmationPageViewModel.Navigate += NavigateToUserDetailPage;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void SaveClicked(object sender, EventArgs e)
        {
            try
            {
                confirmationPageViewModel.OnSave();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void CancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void NavigateToUserDetailPage(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new MasterDetailPage()
                {
                    Master = new MasterPage() { Title = "User Detail" },
                    Detail = new NavigationPage(new UserDetailViewPage())

                });
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
       }
    }
}