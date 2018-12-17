using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongConsole_Heras
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetWindowSize(100, 50);
            new Game().Run();
            Console.ReadLine();
        }
    }
}
