using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PongConsole_Heras
{
    static class UserInput
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        static public bool GetKeyState(Paddle paddleLeft, Paddle paddleRight)
        {
            if (Console.KeyAvailable)
            {
                if (GetAsyncKeyState((int)ConsoleKey.W) != 0)
                    paddleLeft.Update("up");
                if (GetAsyncKeyState((int)ConsoleKey.S) != 0)
                    paddleLeft.Update("down");
                if (GetAsyncKeyState((int)ConsoleKey.O) != 0)
                    paddleRight.Update("up");
                if (GetAsyncKeyState((int)ConsoleKey.L) != 0)
                    paddleRight.Update("down");
                if (GetAsyncKeyState((int)ConsoleKey.Escape) != 0)
                    return false;
            }
            return true;
        }
    }
}