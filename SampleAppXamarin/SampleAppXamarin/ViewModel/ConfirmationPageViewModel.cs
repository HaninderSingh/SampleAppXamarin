using SampleAppXamarin.DBService;
using SampleAppXamarin.Helpers;
using SampleAppXamarin.Interfaces;
using SampleAppXamarin.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleAppXamarin.ViewModel
{
    public class ConfirmationPageViewModel : BaseViewModel
    {
        public LocalDataBase LocalDB;
        public event EventHandler Navigate;
        private UserDetailModel userDetail;
        public UserDetailModel UserDetail
        {
            get { return userDetail; }
            set { userDetail = value; OnPropertyChanged("UserDetaillist"); }
        }
        public ConfirmationPageViewModel(UserDetailModel detailModel)
        {
            LocalDB = new LocalDataBase();
            UserDetail = new UserDetailModel();
            UserDetail = detailModel;
        }
        public void OnSave()
        {
            try
            {
                IsBusy = true;
                LocalDB.PutDetail(UserDetail);
                string msg = "Detail Saved";
                msg.ToToast(ToastNotificationType.Success);
                Navigate?.Invoke(this, null);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                IsBusy = true;
            }
        }
    }
}
