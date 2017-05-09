using System.Collections.Generic;
using System.Data.SQLite;
using BackOffice.Common.Data;
using BackOffice.Module.Pms.Models;

namespace BackOffice.Module.Pms.Data
{
    public class DiscountData
    {
        static DiscountData()
        {
            DataAccess.AddDemoCreator(CreateDemoData);
        }

        public static IEnumerable<Discount> ReadDiscounts()
        {
            using (var command = new SQLiteCommand(DataAccess.Instance.Connection))
            {
                command.CommandText = "SELECT id, name, rate, isabs, usesale, useorder FROM discounts";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var discount = new Discount() { Id = id, Name = reader[1].ToString(), Rate = reader.GetDecimal(2), IsAbsolute = reader.GetBoolean(3), UseForSale = reader.GetBoolean(4), UseForOrders = reader.GetBoolean(5)};
                        yield return discount;
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
                    "CREATE TABLE IF NOT EXISTS discounts (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL, rate REAL, isabs BOOLEAN, usesale BOOLEAN, useorder BOOLEAN);";
                command.ExecuteNonQuery();
                // Einfügen eines Test-Datensatzes.
                command.CommandText = "INSERT INTO discounts (name, rate, isabs, usesale, useorder) VALUES('Barverkauf', 0.95, 0, 1, 0)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO discounts (name, rate, isabs, usesale, useorder) VALUES('Mengenrabatt', 0.9, 0, 0, 1)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO discounts (name, rate, isabs, usesale, useorder) VALUES('Stammkunde', 0.1, 1, 0, 1)";
                command.ExecuteNonQuery();
            }
        }
    }
}