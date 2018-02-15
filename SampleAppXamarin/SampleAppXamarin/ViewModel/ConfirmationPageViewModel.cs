using SampleAppXamarin.DBService;
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
                LocalDB.PutDetail(UserDetail);
                Navigate?.Invoke(this, null);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
