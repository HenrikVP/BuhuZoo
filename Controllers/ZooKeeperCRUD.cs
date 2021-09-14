using BuhuZoo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BuhuZoo.Controllers
{
    class ZooKeeperCRUD
    {
        private string connectionString;

        public ZooKeeperCRUD() { }
        public ZooKeeperCRUD(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //const string connectionString =
        //    "Data Source=.;" +
        //    "Initial Catalog=BuhuzooDB;" +
        //    "Integrated Security=True";

        public List<ZooKeeper> Select()
        {
            List<ZooKeeper> zooKeeperList = new List<ZooKeeper>();
            string sql = $"SELECT id, [name], gender, DateOfBirth, Email FROM ZooKeeper";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        zooKeeperList.Add(
                            new ZooKeeper()
                            {
                                Id = (int)reader[0],
                                Name = (string)reader[1],
                                Gender = (Gender)Enum.Parse(typeof(Gender), reader[2].ToString()),                              
                                DateOfBirth = (DateTime)reader[3],
                                Email = reader[4].ToString(),
                                AnimalList = new AnimalCRUD().Select((int)reader[0])
                            });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR:" + ex.GetType() + ex.Message);
                    return null;
                }
            }
            return zooKeeperList;
        }

        public int? Insert(ZooKeeper zooKeeper)
        {
            string sql = "INSERT INTO zooKeeper ([name], gender, DateOfBirth, email) " +
                    "OUTPUT INSERTED.id " +
                    "VALUES(@name, @gender, @DateOfBirth, @email) ";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = zooKeeper.Name;
                        cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = zooKeeper.Gender;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = zooKeeper.Email;
                        cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = zooKeeper.DateOfBirth;

                        var id = cmd.ExecuteScalar();
                        return (int?)id;
                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    Console.WriteLine("ERROR:" + ex.Message);
                    return null;
                }
            }
        }

    }
}
