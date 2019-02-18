using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongConsole_Heras
{
    class Game
    {
        private Vector2D fieldSize = new Vector2D(80, 25);
        private ConsoleColor foreColor = ConsoleColor.White;
        private ConsoleColor backColor = ConsoleColor.Black;
        private int loopTime = 90;

        private Ball ball;
        private char ballCharacter = '■';
        private ConsoleColor ballColor = ConsoleColor.White;

        private char paddleCharacter = '█';
        private int paddleSize = 4, paddleSpeed = 1, paddleOffset = 6;

        private Paddle paddleLeft;
        private ConsoleColor paddleLeftColor = ConsoleColor.White;

        private Paddle paddleRight;
        private ConsoleColor paddleRightColor = ConsoleColor.White;

        private int playerLeftScore = 0, playerRightScore = 0;

        private int newBallDelay = 1500;

        private bool runGameLoop = true;

        public Game()
        {
            Field.Draw(fieldSize, foreColor, backColor);
            ball = new Ball(ballCharacter, ballColor, fieldSize);

            paddleLeft = new Paddle(paddleCharacter, paddleLeftColor, fieldSize, new Vector2D(paddleOffset - 1, (fieldSize.Y - paddleSize) / 2), paddleSize, paddleSpeed);
            paddleRight = new Paddle(paddleCharacter, paddleRightColor, fieldSize, new Vector2D(fieldSize.X - paddleOffset, (fieldSize.Y - paddleSize) / 2), paddleSize, paddleSpeed);
        }

        public void Run()
        {
            DateTime t0 = DateTime.Now, t1;
            Vector2D ballPosition;
            GameStartScreen();
            while (runGameLoop)
            {
                t1 = DateTime.Now;
                int ms = (t1.Millisecond - t0.Millisecond + 1000) % 1000;
                if (ms > loopTime)
                {
                    t0 = t1;
                    runGameLoop = UserInput.GetKeyState(paddleLeft, paddleRight);

                    Field.DrawCenterLine();
                    DrawScores();

                    ball.Update(paddleLeft, paddleRight);
                    ballPosition = ball.Draw();

                    if (ballPosition.X == 0)
                    {
                        playerRightScore++;
                        NewBall();
                    }
                    if (ballPosition.X == fieldSize.X - 1)
                    {
                        playerLeftScore++;
                        NewBall();
                    }

                    paddleLeft.Draw();
                    paddleRight.Draw();
                }
            }
            GameEndScreen();
        }

        public void DrawScores()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = paddleLeftColor;
            Console.SetCursorPosition(paddleOffset - 1 + (fieldSize.X / 2 - paddleOffset) / 2, 1);
            Console.Write(playerLeftScore);
            Console.ForegroundColor = paddleRightColor;
            Console.SetCursorPosition(fieldSize.X / 2 + (fieldSize.X / 2 - paddleOffset) / 2, 1);
            Console.Write(playerRightScore);
            Console.ForegroundColor = foregroundColor;
        }

        private void NewBall()
        {
            ball.Color = ConsoleColor.Red;
            ball.Draw();
            ball.Color = ballColor;
            System.Threading.Thread.Sleep(newBallDelay);
            DrawScores();
            paddleLeft.Reset();
            paddleLeft.Draw();
            paddleRight.Reset();
            paddleRight.Draw();
            ball.Reset();
            ball.Draw();
            System.Threading.Thread.Sleep(newBallDelay);
        }

        private void GameEndScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(fieldSize.X / 2 - 5, fieldSize.Y / 2);
            Console.Write("Game Ended");
            Console.SetCursorPosition(fieldSize.X / 2 - 5, fieldSize.Y / 2 + 1);
            Console.Write(playerLeftScore + " : " + playerRightScore);
        }

        private void GameStartScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(fieldSize.X / 2 - 6, fieldSize.Y / 2);
            Console.Write("Console Pong");
            Console.SetCursorPosition(fieldSize.X / 2 - 8, fieldSize.Y / 2 + 1);
            Console.Write("Maximilian Heras");
            Console.SetCursorPosition(fieldSize.X / 2 - 10, fieldSize.Y / 2 + 2);
            Console.Write("Press Enter to start");
            Console.Read();
            Console.Clear();
        }
    }
}