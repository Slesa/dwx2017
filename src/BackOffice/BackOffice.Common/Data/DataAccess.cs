using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace BackOffice.Common.Data
{
    public class DataAccess
    {
        private const string DataSource = "SQLiteDemo.db";
        public static List<Action> DemoCreators;

        static DataAccess()
        {
            DemoCreators = new List<Action>();
        }

        private DataAccess()
        {
        }


        private static DataAccess _instance;

        public static DataAccess Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataAccess();
                    var createDemo = !File.Exists(DataSource);
                    _instance.OpenDatabase();
                    if (createDemo)
                        _instance.CreateDemoData();
                }
                return _instance;
            }
        }

        public SQLiteConnection Connection { get; set; }

        private void OpenDatabase()
        {
            Connection = new SQLiteConnection();
            Connection.ConnectionString = "Data Source=" + DataSource;
            Connection.Open();
        }


        private void CreateDemoData()
        {
            foreach (var creator in DemoCreators)
            {
                creator();
            }
            //UserRoleData.CreateDemoData();
            //UserData.CreateDemoData();
        }


    }
}