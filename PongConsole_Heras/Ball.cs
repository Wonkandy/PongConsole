using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongConsole_Heras
{
    class Ball
    {
        char character;
        ConsoleColor color;
        Vector2D fieldSize;
        Vector2D positionNew;
        Vector2D positionOld;
        Vector2D positionStart;
        Vector2D velocity;


        // Konstruktor:
        public Ball(char character, ConsoleColor color, Vector2D fieldSize)
        {
            this.character = character;
            this.color = color;
            this.fieldSize = fieldSize;
            // Startposition:
            positionStart = new Vector2D(fieldSize.X / 2, fieldSize.Y / 2 - 1);
            positionNew = positionStart;
            positionOld = positionStart;
            // Startgeschwindigkeitsvektor:
            velocity = new Vector2D(4, 0);
        }

        // Aktualisierung der Position:
        public void Update(Paddle paddleLeft)
        {
            positionNew = positionOld + velocity;
            // Kollision mit Spielfeldrändern:
            if (positionNew.X < 0)
            {
                positionNew.X = 0; velocity.X *= -1;
            }
            if (positionNew.X > fieldSize.X - 1)
            {
                positionNew.X = fieldSize.X - 1; velocity.X *= -1;
            }
            if (positionNew.Y < 0)
            {
                positionNew.Y = 0; velocity.Y *= -1;
            }
            if (positionNew.Y > fieldSize.Y - 1)
            {
                positionNew.Y = fieldSize.Y - 1; velocity.Y *= 1;
            }
            // Zeilenvorschub in der rechten unteren Ecke verhindern:
            if (positionNew.X == fieldSize.X - 1 && positionNew.Y == fieldSize.Y - 1)
            {
                positionNew.Y = fieldSize.Y - 2; positionNew.X = fieldSize.X - 2;
                velocity.X *= -1; velocity.Y *= -1;
            }       
        }

        //Konsolenausgabe
        public void Draw()
        {
            Console.SetCursorPosition(positionOld.X, positionOld.Y);
            Console.Write(" ");
            Console.SetCursorPosition(positionNew.X, positionNew.Y);
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(character);
            Console.ForegroundColor = foregroundColor;
            positionOld = positionNew;
        }
        

    }
}
