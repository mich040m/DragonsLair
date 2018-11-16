using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TournamentLib
{
    public class SQL
    {
        public static void InsertToTable (string navn, string tabel)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=den1.mssql7.gear.host;" +
            "Initial Catalog=database125;" +
            "User id=database125;" +
            "Password=Ls0oY5-6vVs_;";


            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            try
            {
                SqlCommand command1 = new SqlCommand("INSERT INTO " + tabel + " VALUES (" + "'" + navn + "'"+ ");", conn);
                command1.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }
        public static void InsertToMatches(string a, string b, string c)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=den1.mssql7.gear.host;" +
            "Initial Catalog=database125;" +
            "User id=database125;" +
            "Password=Ls0oY5-6vVs_;";

            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            try
            {
                SqlCommand command1 = new SqlCommand("INSERT INTO " + "MATCHES" + " VALUES (" + "'" + a + "'" + "'" + b + "'" + "'" + c + "'" +");", conn);
                command1.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }


    }
}
