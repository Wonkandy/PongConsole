﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongConsole_Heras
{
    class Game
    {
        //Felder
        private Vector2D fieldSize = new Vector2D(80, 25);
        private ConsoleColor fieldForeColor = ConsoleColor.Green;
        private ConsoleColor fieldBackColor = ConsoleColor.Black;

        private int loopTime = 90;
        private Ball ball;
        private char ballCharacter = '■';
        private ConsoleColor ballColor = ConsoleColor.Green;
        private char paddleCharacter = '█';
        private int paddleSize = 4;
        private int paddleSpeed = 1;
        private int paddleOffset = 6;
        private Paddle paddleLeft;
        private Paddle paddleRight;
        private ConsoleColor paddleLeftColor = ConsoleColor.Green;
        
        //Konstruktor
        public Game()
        {
            //Spielfeld zeichnen
            Field.Draw(fieldSize, fieldForeColor, fieldBackColor);
            // Ball instanziieren: 
            ball = new Ball(ballCharacter, ballColor, fieldSize);
            paddleLeft = new Paddle(paddleCharacter, paddleSize, paddleLeftColor, new Vector2D(paddleOffset - 1, (fieldSize.Y - paddleSize) / 2), paddleSpeed, fieldSize);
            paddleRight = new Paddle(paddleCharacter, paddleSize, paddleLeftColor, new Vector2D(fieldSize.X - paddleOffset, (fieldSize.Y - paddleSize) / 2), paddleSpeed, fieldSize);

        }

        public void Run()
        {
            /*int x = Console.WindowWidth / 2;
            int y = 0;
            Console.SetCursorPosition(x, y);
            Console.Write("■");*/

            DateTime t0, t1;
            t0 = DateTime.Now;

            //Game Loop:
            while (true)
            {
                t1 = DateTime.Now;
                int ms = (t1.Millisecond - t0.Millisecond + 1000) % 1000;
                if (ms > loopTime)
                {
                    t0 = t1;
                    UserInput.GetKeyState(paddleLeft);
                    UserInput.GetKeyStateR(paddleRight);
                    ball.Update(paddleLeft);
                    Field.DrawCenterLine();
                    ball.Draw();
                    paddleLeft.Draw();
                    paddleRight.Draw();


                    /*Field.DrawCenterLine();
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                    if (y < Console.WindowHeight - 1) y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("■");*/
                }
            }
        }
    }
}
