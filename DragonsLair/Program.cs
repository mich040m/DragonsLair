using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DragonsLair
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program myProgram = new Program();
            //myProgram.Run();
            Controller controller = new Controller();
            controller.ScheduleNewRound("Vinter Turnering");
        }

        void Run()
        {
            Menu menu = new Menu();
            menu.Show();
            SqlConnection connection = new SqlConnection(@"Server=EALSQL1.eal.local;Database=A_DB23_2018;Trusted_Connection = yes");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM TableName", connection);
        }
    }
}
