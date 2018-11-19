using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsLair
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
            Controller controller = new Controller();
            controller.ScheduleNewRound("Vinter Turnering");

            TournamentLib.Round r = new TournamentLib.Round();
        }

        void Run()
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
