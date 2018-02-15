using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;

namespace SampleAppXamarin.Interfaces
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
