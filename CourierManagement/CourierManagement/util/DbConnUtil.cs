using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CourierManagement.util
{
    public class DbConnUtil
    {


            public static SqlConnection connection;

            public static SqlConnection GetConnection()
            {
                if (connection == null)
                {
                    var props = LoadProperties("Dbproperties.txt");
                    string server = props["server"];
                    string database = props["database"];

                    string connectionString = $"Server={server};Database={database};Trusted_Connection=True;";
                    connection = new SqlConnection(connectionString);
                }
                return connection;
            }

            private static Dictionary<string, string> LoadProperties(string filePath)
            {
                var dict = new Dictionary<string, string>();
                foreach (var line in File.ReadAllLines(filePath))
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                    {
                        var parts = line.Split('=');
                        if (parts.Length == 2)
                            dict[parts[0].Trim()] = parts[1].Trim();
                    }
                }
                return dict;
            }
        }
    }

