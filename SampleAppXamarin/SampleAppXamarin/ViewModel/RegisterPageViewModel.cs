using Newtonsoft.Json;
using SampleAppXamarin.DBService;
using SampleAppXamarin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace SampleAppXamarin.ViewModel
{
    public class RegisterPageViewModel : BaseViewModel
    {
        public event EventHandler Navigate;
        private List<NationalityModel> nationalitylist;
        public List<NationalityModel> Nationalitylist
        {
            get { return nationalitylist; }
            set { nationalitylist = value; OnPropertyChanged("Nationalitylist"); }
        }
        private List<UserDetailModel> userDetaillist;
        public List<UserDetailModel> UserDetaillist
        {
            get { return userDetaillist; }
            set { userDetaillist = value; OnPropertyChanged("UserDetaillist"); }
        }
        private List<string> nationalityName;
        public List<string> NationalityName
        {
            get { return nationalityName; }
            set { nationalityName = value; OnPropertyChanged("NationalityName"); }
        }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string contact { get; set; }
        public string nationality { get; set; }
        public string maritialstatus { get; set; }
        public string sex { get; set; }
        public Command RegisterCommand { get; set; }

        public RegisterPageViewModel()
        {
            Nationalitylist = new List<NationalityModel>();
            NationalityName = new List<string>();
            UserDetaillist = new List<UserDetailModel>();
            RegisterCommand = new Command(() => OnRegisterDetail());
        }

        private void OnRegisterDetail()
        {
            try
            {
                UserDetailModel userDetailModel = new UserDetailModel()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    ContactNo = contact,
                    Email = emailAddress,
                    Nationality = nationality,
                    Maritalstatus = maritialstatus,
                    Sex = sex
                };
                userDetaillist.Add(userDetailModel);
                Navigate?.Invoke(this, null);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void OnNationality()
        {
            var assembly = typeof(UserDetailViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("SampleAppXamarin.Resource.Country.json");
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                Nationalitylist = JsonConvert.DeserializeObject<List<NationalityModel>>(json);
                foreach (var item in Nationalitylist)
                {
                    NationalityModel nationality = new NationalityModel()
                    {
                        Nationality = item.Nationality
                    };
                    NationalityName.Add(nationality.Nationality);
                }
            }
        }
    }
}
