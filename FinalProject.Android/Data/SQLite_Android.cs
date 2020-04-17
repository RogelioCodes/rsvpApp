using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FinalProject.Data;
using FinalProject.Droid.Data;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace FinalProject.Droid.Data
{
    public class SQLite_Android : ISQLite
    {//references https://www.youtube.com/watch?v=nFkwRuTG8eM&list=PLV916idiqLvcKS1JY3S3jHWx9ELGJ1cJB&index=5  at 6:03 in the video
        public SQLite_Android() {}
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}