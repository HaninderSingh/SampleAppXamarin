using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SampleAppXamarin.Interfaces;
using SampleAppXamarin.iOS.DBService;
using SQLite.Net;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteiOS))]
namespace SampleAppXamarin.iOS.DBService
{
    class SQLiteiOS : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "SampleApp.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;
        }
    }
}