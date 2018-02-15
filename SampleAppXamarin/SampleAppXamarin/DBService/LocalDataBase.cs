using SampleAppXamarin.Interfaces;
using SampleAppXamarin.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SampleAppXamarin.DBService
{
    public class LocalDataBase
    {
        public SQLiteConnection LocalStoreConnection { get; private set; }
        public LocalDataBase()
        {
            try
            {
                LocalStoreConnection = DependencyService.Get<ISqlite>().GetConnection();
                LocalStoreConnection.CreateTable<UserDetailModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                throw;
            }
        }
        public void PutDetail(UserDetailModel SMS)
        {
            try
            {
                LocalStoreConnection.Insert(SMS);
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }

        }
        
        public List<UserDetailModel> GetDetail()
        {
            var notes = LocalStoreConnection.Table<UserDetailModel>();
            return notes.ToList();
        }
        
        public void ClearTableDetail()
        {
            LocalStoreConnection.DeleteAll<UserDetailModel>();

        }
    }
}