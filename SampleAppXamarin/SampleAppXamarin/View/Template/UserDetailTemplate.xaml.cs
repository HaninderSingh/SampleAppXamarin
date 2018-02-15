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
	public partial class UserDetailTemplate : ContentView
	{
        UserDetailViewModel userDetailViewModel;
        public UserDetailTemplate ()
		{
            try
            {
                InitializeComponent();
              //  userDetailViewModel = new UserDetailViewModel();
                //    BindingContext = userDetailViewModel;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
		}
	}
}