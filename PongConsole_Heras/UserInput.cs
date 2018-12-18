using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PongConsole_Heras
{
    static class UserInput
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        static public bool GetKeyState(Paddle paddleLeft)
        {
            if (Console.KeyAvailable)
            {
                if (GetAsyncKeyState((int)ConsoleKey.W) != 0)
                    paddleLeft.Update("up");
                if (GetAsyncKeyState((int)ConsoleKey.S) != 0)
                    paddleLeft.Update("down");

            }
            return true;
        }

        static public bool GetKeyStateR(Paddle paddleRight)
        {
            if (Console.KeyAvailable)
            {
                if (GetAsyncKeyState((int)ConsoleKey.O) != 0)
                    paddleRight.Update("up");
                if (GetAsyncKeyState((int)ConsoleKey.L) != 0)
                    paddleRight.Update("down");

            }
            return true;
        }
    }
}
