using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Tort.Models;

namespace Tort.Data
{
    public class MainDBContext
    {
        string connectionString;

        public MainDBContext(string _connectionstring)
        {
            connectionString = _connectionstring;
        }

        public List<User> LoadDataGrid()
        {
            var user = new List<User>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using(NpgsqlCommand command = new NpgsqlCommand("",connection))
                {

                    using(NpgsqlDataReader reader = command.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            user.Add(new User
                            {
                                User_id = reader.GetInt32(0),
                                User_Name = reader.GetString(1),
                                User_FirstName = reader.GetString(2),
                                User_LastName = reader.GetString(3),
                                User_Login = reader.GetString(4),
                                User_Role = reader.GetInt32(5),
                                Password = reader.GetString(6),
                                User_Email = reader.GetString(7),
                            });

                        }
                    }



                   
                }
            }
            return user;
        }
    }
}
