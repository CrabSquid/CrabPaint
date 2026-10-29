using System.Drawing;
using System.Text;

namespace CrabPaint
{
    public static class Draw
    {
        private enum BorderChar
        {
            Empty = 0,
            Space = 1,

            H1 = 196,
            V1 = 179,
            NW1 = 218,
            NE1 = 191,
            SW1 = 192,
            SE1 = 217,

            H2 = 205,
            V2 = 186,
            NW2 = 201,
            NE2 = 187,
            SW2 = 200,
            SE2 = 188
        }

        public static string Decode(byte[] indices)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding cp437 = Encoding.GetEncoding(437);

            return cp437.GetString(indices);
        }

        public static string Decode(byte index)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding cp437 = Encoding.GetEncoding(437);

            if (index == 1) { return " "; }

            return cp437.GetString([index]);
        }

        public static void Box(Point start, Point end)
        {
            int left = start.X < end.X ? start.X : end.X;
            int right = start.X > end.X ? start.X : end.X;
            int up = start.Y < end.Y ? start.Y : end.Y;
            int down = start.Y > end.Y ? start.Y : end.Y;

            string top = Decode((byte)BorderChar.NW2);
            string mid = Decode((byte)BorderChar.V2);
            string bot = Decode((byte)BorderChar.SW2);

            for (int x = left; x < right; x++)
            {
                top += Decode((byte)BorderChar.H2);
                mid += Decode((byte)BorderChar.Space);
                bot += Decode((byte)BorderChar.H2);
            }

            top += Decode((byte)BorderChar.NE2);
            mid += Decode((byte)BorderChar.V2);
            bot += Decode((byte)BorderChar.SE2);

            Console.SetCursorPosition(left, up);
            Console.WriteLine(top);
            for (int y = up + 1; y < down; y++)
            {
                Console.SetCursorPosition(left, y);
                Console.WriteLine(mid);
            }
            Console.SetCursorPosition(left, down);
            Console.WriteLine(bot);
        }

        public static void WriteAll()
        {
            for (byte b = 0; b < byte.MaxValue; b++)
            {
                if (b % 16 == 0) { Console.Write("\n"); }
                Console.Write(Decode(b));
            }

            for (byte b = 0; b < 16; b++)
            {
                if (b % 16 == 0) { Console.Write("\n"); }
                Console.ForegroundColor = (ConsoleColor)b;
                Console.Write("█");
            }

            Console.Write("\n");
        }
    }
}