using BuhuZoo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BuhuZoo.Controllers
{
    class AnimalCRUD
    {
        const string connectionString =
            "Data Source=.;" +
            "Initial Catalog=BuhuzooDB;" +
            "Integrated Security=True";

        public List<Animal> Select(int zooKeeperId)
        {
            List<Animal> animalList = new List<Animal>();
            string sql =$@"
SELECT animal.id, animal.[Name], animal.Race, animal.Color, animal.DateOfBirth, animal.Gender
FROM ZooKeeperAnimal
JOIN animal ON Animal.Id = ZooKeeperAnimal.AnimalId
WHERE ZooKeeperAnimal.ZooKeeperId = {zooKeeperId}";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        animalList.Add(
                            new Animal()
                            {
                                Id = (int)reader[0],
                                Name = (string)reader[1],
                                Gender = (Gender)Enum.Parse(typeof(Gender), reader[2].ToString()),
                                DateOfBirth = (DateTime)reader[3],
                                Color = (Color)Enum.Parse(typeof(Color), reader[4].ToString()),
                                Race = (string)reader[5]
                            });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR:" + ex.GetType() + ex.Message);
                    return null;
                }
            }
            return animalList;
        }

        public List<Animal> Select()
        {
            List<Animal> animalList = new List<Animal>();
            string sql = $"SELECT id, [name], gender, DateOfBirth, Color, Race FROM Animal";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        animalList.Add(
                            new Animal()
                            {
                                Id = (int)reader[0],
                                Name = (string)reader[1],
                                Gender = (Gender)Enum.Parse(typeof(Gender), reader[2].ToString()),
                                //Gender = (Gender)reader[2],
                                DateOfBirth = (DateTime)reader[3],
                                Color = (Color)Enum.Parse(typeof(Color), reader[4].ToString()),
                                Race = (string)reader[5]
                            });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR:" + ex.GetType() + ex.Message);
                    return null;
                }
            }
            return animalList;
        }
        public static int? Insert(Animal animal)
        {
            string sql = "INSERT INTO Animal ([name], gender, DateOfBirth, color, race) " +
                    "OUTPUT INSERTED.id " +
                    "VALUES(@name, @gender, @DateOfBirth, @color, @race) ";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = animal.Name;
                        cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = animal.Gender;
                        cmd.Parameters.Add("@color", SqlDbType.NVarChar).Value = animal.Color;
                        cmd.Parameters.Add("@race", SqlDbType.NVarChar).Value = animal.Race;
                        cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = animal.DateOfBirth;

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
