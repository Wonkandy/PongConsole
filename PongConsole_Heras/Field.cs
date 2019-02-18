using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongConsole_Heras
{
    static class Field
    {

        public static void Draw(Vector2D size, ConsoleColor f, ConsoleColor b)
        {
            Console.Title = "Console Pong";
            Console.SetWindowSize(size.X, size.Y);
            Console.SetBufferSize(size.X, size.Y);
            Console.ForegroundColor = f;
            Console.BackgroundColor = b;
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            DrawCenterLine();
        }



        public static void DrawCenterLine()
        {
            int w = Console.WindowWidth;
            int h = Console.WindowHeight;

            for (int i = 0; i < h; i += 2)
            {
                Console.SetCursorPosition(w / 2, i);
                Console.Write("|");
            }
        }
    }
}