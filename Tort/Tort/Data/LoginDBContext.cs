using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Tmds.DBus.Protocol;

namespace Tort.Data
{
    internal class LoginDBContext
    {
        string connectionString ;
        
        public LoginDBContext(string _connectionString)
        {
           connectionString = _connectionString;
        }

        public bool Login(string loginUser, string passwordUser)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("select authenticate_user(@p_username,@p_password)", conn))
                {
                    command.CommandType = CommandType.Text;

                    NpgsqlParameter Plogin = new NpgsqlParameter
                    {
                        ParameterName = "p_username",
                        NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text,
                        Value = loginUser,
                        Direction = ParameterDirection.Input

                    };
                    command.Parameters.Add(Plogin);

                    NpgsqlParameter password = new NpgsqlParameter
                    {
                        ParameterName = "p_password",
                        NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text,
                        Value = passwordUser,
                        Direction = ParameterDirection.Input

                    };
                    command.Parameters.Add(password);

                   
                    object result = command.ExecuteScalar();


                    if (result != null && result != DBNull.Value)
                    {
                        return (bool)result;
                    }
                    else
                    {

                        return false;
                    }


                }
            }
        }
    }
}


