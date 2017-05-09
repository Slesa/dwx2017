using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace BackOffice.Common.Data
{
    public class DataAccess
    {
        private const string DataSource = "SQLiteDemo.db";

        public static List<Action> _demoCreators;

        static DataAccess()
        {
            _demoCreators = new List<Action>();
        }

        private DataAccess()
        {
        }

        public static void AddDemoCreator(Action demoCreator)
        {
            _demoCreators.Add(demoCreator);
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
            foreach (var demoCreator in _demoCreators)
            {
                demoCreator();
            }
            //DiscountData.CreateDemoData();
            //UserRoleData.CreateDemoData();
            //UserData.CreateDemoData();
        }


    }
}