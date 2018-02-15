using Newtonsoft.Json;
using SampleAppXamarin.DBService;
using SampleAppXamarin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppXamarin.ViewModel
{
    public class UserDetailViewModel : BaseViewModel
    {
        public event EventHandler Navigate;
        public LocalDataBase LocalDB;
        private List<UserDetailModel> userDetaillist;
        public List<UserDetailModel> UserDetaillist
        {
            get { return userDetaillist; }
            set { userDetaillist = value; OnPropertyChanged("UserDetaillist"); }
        }

        public UserDetailViewModel()
        {
            LocalDB = new LocalDataBase();
            UserDetaillist = new List<UserDetailModel>();
        }
        public async Task GetDetailFromSql()
        {
            try
            {
                IsBusy = true;
                UserDetaillist = LocalDB.GetDetail();
                if (UserDetaillist.Count == 0)
                    OnUserlist();
                Navigate?.Invoke(this, null);
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
        public void OnUserlist()
        {
            var assembly = typeof(UserDetailViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("SampleAppXamarin.Resource.Detail.json");
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                UserDetaillist = JsonConvert.DeserializeObject<List<UserDetailModel>>(json);
            }
        }
    }
}
