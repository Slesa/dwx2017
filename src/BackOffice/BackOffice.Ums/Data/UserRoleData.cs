using System.Collections.Generic;
using System.Data.SQLite;
using BackOffice.Common.Data;
using BackOffice.Module.Ums.Models;

namespace BackOffice.Module.Ums.Data
{
    public class UserRoleData
    {
        static UserRoleData()
        {
            DataAccess.AddDemoCreator(CreateDemoData);
        }

        public static IEnumerable<UserRole> ReadUserRoles()
        {
            using (var command = new SQLiteCommand(DataAccess.Instance.Connection))
            {
                // Auslesen des zuletzt eingefügten Datensatzes.
                command.CommandText = "SELECT id, name FROM userroles";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var userRole = new UserRole() { Id = id, Name = reader[1].ToString() };
                        yield return userRole;
                    }

                    reader.Close();
                }
            }
        }

        public static void CreateDemoData()
        {
            using (var command = new SQLiteCommand(DataAccess.Instance.Connection))
            {
                // Erstellen der Tabelle, sofern diese noch nicht existiert.
                command.CommandText =
                    "CREATE TABLE IF NOT EXISTS userroles ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL);";
                command.ExecuteNonQuery();
                // Einfügen eines Test-Datensatzes.
                command.CommandText = "INSERT INTO userroles (name) VALUES('Chefkellner')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO userroles (name) VALUES('Oberkellner')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO userroles (name) VALUES('Kellner')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO userroles (name) VALUES('Saftschubse')";
                command.ExecuteNonQuery();
            }
        }

        public static UserRole Find(long id)
        {
            using (var command = new SQLiteCommand(DataAccess.Instance.Connection))
            {
                // Auslesen des zuletzt eingefügten Datensatzes.
                command.CommandText = string.Format("SELECT name FROM userroles WHERE id={0}", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var userRole = new UserRole() { Id = id, Name = reader[0].ToString() };
                        return userRole;
                    }
                    reader.Close();
                }
                return null;
            }
        }
    }
}