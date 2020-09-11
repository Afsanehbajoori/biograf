using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace biograf.Databaselage
{
    static class SQL
    {
        //oprette connectiton:
        private static string ConnectionString = "Data Source=localhost;Initial Catalog=biograf; Integrated Security=SSPI;Connect Timeout=5;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static bool SqlConnectionOK()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }
       
        
        // Insert command:
        public static void insert(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.ExecuteNonQuery();
            }
        }


        //Update command:
        public static void Update(string sql)
        {
            Console.WriteLine("Update");

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlDataAdapter a = new SqlDataAdapter(sql, con))
                {
                con.Open();
                    using (SqlCommand cmd = new SqlCommand("Update Kunder set Fnavn ='" + "Jens" + "' where kundeid=1" , con))
                    {
                        a.UpdateCommand = new SqlCommand(sql, con);
                        a.UpdateCommand.ExecuteNonQuery();

                        cmd.Dispose();
                    } 
                    
                 }
      
             }

        }


        // Read command
        public static DataTable ReadTable(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                DataTable records = new DataTable();

                using (SqlDataAdapter a = new SqlDataAdapter(sql, con))
                {
                 con.Open();
                    
                }

                return records;
            }
        }

        public static void DataReader()
        {
            Console.WriteLine("DataReader");
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("Select * from Kunder", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine(reader.HasRows);

                    while (reader.Read())
                    {
                        int kundeid = reader.GetInt32(0);
                        string fnavn = reader.GetString(1);
                        string enavn = reader.GetString(2);
                        string adr = reader.GetString(3);
                        string telnumer = reader.GetString(4);
                        string kunetype = reader.GetString(5);

                        Console.WriteLine($"Id: {kundeid} Fnavn: {fnavn} Enavn: {enavn} adresse: {adr} Telnumer: {telnumer} kunetype {kunetype}");
                    }
                }

            }

        }

       //Delete command
        public static void Delete(string sql)
        {
            Console.WriteLine("Delete");

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlDataAdapter a = new SqlDataAdapter(sql, con))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Delete Kunder where kundeid=2", con))
                    {
                        a.DeleteCommand= new SqlCommand(sql, con);
                        a.DeleteCommand.ExecuteNonQuery();

                        cmd.Dispose();
                    }

                }

            }

        }

     }


}
    

