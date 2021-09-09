using BuhuZoo.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BuhuZoo.Controllers
{
    class Sql
    {
        const string connectionString = "Data Source=.;Initial Catalog=BuhuzooDB;Integrated Security=True";
        public static int? Insert(Animal animal)
        {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public Gender Gender { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public Color Color { get; set; }
        //public string Race { get; set; }

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
