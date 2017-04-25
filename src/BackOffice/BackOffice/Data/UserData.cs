using System.Collections.Generic;
using System.Data.SQLite;
using BackOffice.Models;

namespace BackOffice.Data
{
    public class UserData
    {
        public static IEnumerable<User> ReadUsers()
        {
            using (var command = new SQLiteCommand(DataAccess.Instance.Connection))
            {
                command.CommandText = "SELECT id, name, userrole FROM users";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var userRole = UserRoleData.Find(reader.GetInt64(2));
                        var user = new User() { Id = id, Name = reader[1].ToString(), UserRole = userRole };
                        yield return user;
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
                    "CREATE TABLE IF NOT EXISTS users ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL, passwd VARCHAR(16), userrole INTEGER NOT NULL);";
                command.ExecuteNonQuery();
                // Einfügen eines Test-Datensatzes.
                command.CommandText = "INSERT INTO users (name, userrole) VALUES('Captain Picard', 1)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO users (name, userrole) VALUES('Lt Commander Riker', 2)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO users (name, userrole) VALUES('Lt Worf', 3)";
                command.ExecuteNonQuery();
            }
        }
    }
}