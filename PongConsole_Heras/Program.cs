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
            Field.Draw(new Vector2D(80,25), ConsoleColor.Red, ConsoleColor.White);
            Console.ReadLine();


        }
    }
}
