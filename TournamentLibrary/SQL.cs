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
            string Connectionstring = "user id = testbase4; " +
                                       "password=Op4G2H01~!9i;" +
                                       "server=den1.mssql8.gear.host;";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connectionstring;


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
            string Connectionstring = "user id = testbase4; " +
                                      "password=Op4G2H01~!9i;" +
                                      "server=den1.mssql8.gear.host;";


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connectionstring;

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
                SqlCommand command1 = new SqlCommand("INSERT INTO " + "MATCHES " + "VALUES (" + "'" + a + "'" + "'" + b + "'" + "'" + c + "'" +");", conn);
                command1.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static void InsertFirstOpponent(string name, string table)
        {
            string Connectionstring = "user id = testbase4; " +
                                      "password=Op4G2H01~!9i;" +
                                      "server=den1.mssql8.gear.host;";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connectionstring;


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
                SqlCommand command1 = new SqlCommand("INSERT INTO " + table + "(FirstOpponent) " + " VALUES (" + "'" + name + "'" + ");", conn);
                command1.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void InsertSecondOpponent(string name, string table)
        {
            string Connectionstring = "user id = testbase4; " +
                                      "password=Op4G2H01~!9i;" +
                                      "server=den1.mssql8.gear.host;";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connectionstring;


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
                SqlCommand command1 = new SqlCommand("INSERT INTO " + table + "(SecondOpponent) " + " VALUES (" + "'" + name + "'" + ");", conn);
                command1.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void InsertWinningTeam(string name, string table)
        {
            string Connectionstring = "user id = testbase4; " +
                                      "password=Op4G2H01~!9i;" +
                                      "server=den1.mssql8.gear.host;";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connectionstring;


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
                SqlCommand command1 = new SqlCommand("INSERT INTO " + table + "(Winner) " + " VALUES (" + "'" + name + "'" + ");", conn);
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
