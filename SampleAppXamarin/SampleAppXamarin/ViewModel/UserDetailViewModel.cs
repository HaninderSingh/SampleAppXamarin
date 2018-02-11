using Newtonsoft.Json;
using SampleAppXamarin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SampleAppXamarin.ViewModel
{
    public class UserDetailViewModel : BaseViewModel
    {
        private List<UserDetailModel> userDetaillist;
        public List<UserDetailModel> UserDetaillist
        {
            get { return userDetaillist; }
            set { userDetaillist = value; OnPropertyChanged("UserDetaillist"); }
        }

        public UserDetailViewModel()
        {
            UserDetaillist = new List<UserDetailModel>();
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
