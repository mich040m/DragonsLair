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

            //Test to ShowScore Method
            Controller controller = new Controller();
            controller.ShowScore("Vinter Turnering");
        }

        void Run()
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
