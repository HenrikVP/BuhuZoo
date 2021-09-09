using BuhuZoo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuhuZoo
{
    class Sql
    {
        public int? Insert(Animal animal)
        {

        //public int Id { get; set; }
        //public string Name { get; set; }
        //public Gender Gender { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public Color Color { get; set; }
        //public string Race { get; set; }

        // Prepare a proper parameterized query 
        string sql = "INSERT INTO animal ([name], gender, DateOfBirth, color, race) " +
                "OUTPUT INSERTED.id " +
                "VALUES(@name, @gender, @DateOfBirth, @color, @race) ";

            // Create the connection (and be sure to dispose it at the end)
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection to the database. 
                    // This is the first critical step in the process.
                    // If we cannot reach the db then we have connectivity problems
                    cnn.Open();

                    // Prepare the command to be executed on the db
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        // Create and set the parameters values 
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = person.Name;
                        cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = person.Dob;

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
