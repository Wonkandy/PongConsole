using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongConsole_Heras
{
    static class Field
    {
        public static void Draw(Vector2D size, ConsoleColor foreColor, ConsoleColor backColor)
        {
            Console.Title = "Console Pong Heras";
            Console.SetWindowSize(size.X, size.Y);
            Console.SetBufferSize(size.X, size.Y);
            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backColor;
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            DrawCenterLine();
        }

        public static void DrawCenterLine()
        {
            int width = Console.WindowWidth / 2;
            int height = Console.WindowHeight;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            
        }


    }
}
