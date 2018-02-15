using System.IO;
using SampleAppXamarin.Droid.DBService;
using SampleAppXamarin.Interfaces;
using SQLite.Net;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAndroid))]
namespace SampleAppXamarin.Droid.DBService
{
    class SQLiteAndroid : ISqlite
    {
        public SQLiteAndroid()
        {
             
        }
        public SQLiteConnection GetConnection()
        {
            var fileName = "SampleApp.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
    }
}