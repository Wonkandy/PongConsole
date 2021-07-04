using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongConsole_Heras
{
    class Vector2D
    {

        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }


        public Vector2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2D operator + (Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }
    }
}
