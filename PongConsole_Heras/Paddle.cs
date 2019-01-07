using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongConsole_Heras
{
    class Paddle
    {
        //Felder
        char character;
        ConsoleColor color;
        Vector2D fieldSize;
        Vector2D positionNew;
        Vector2D positionOld;
        Vector2D positionStart;
        private int size;
        public int Size { get { return size; } }
        int speed;

        public Vector2D Position { get { return positionNew; } }

        //Konstruktor & Methoden
        public Paddle(char character, int size, ConsoleColor color, Vector2D position, int speed, Vector2D fieldSize)
        {
            this.character = character;
            if (size < 3) size = 3;
            this.size = size;
            this.color = color;
            positionStart = position;
            positionNew = positionStart;
            positionOld = positionStart;
            this.speed = speed;
            this.fieldSize = fieldSize;
        }

        public void Update(string move)
        {
            switch (move)
            {
                case "up":
                    positionNew = new Vector2D(positionOld.X, positionOld.Y - speed);
                    if (positionNew.Y < 0) positionNew.Y = 0;
                    break;
                case "down":
                    positionNew = new Vector2D(positionOld.X, positionOld.Y + speed);
                    if (positionNew.Y > (fieldSize.Y -size)) positionNew.Y = fieldSize.Y - size;
                    break;
            }
        }

        public void Draw()
        {
            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(positionOld.X, positionOld.Y + i);
                Console.Write(" ");
            }
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(positionNew.X, positionNew.Y + i);
                Console.Write(character);
            }
            Console.ForegroundColor = foregroundColor;
            positionOld = positionNew;
        }

        public void Reset()
        {
            positionNew = positionStart;
        }

    }
}
