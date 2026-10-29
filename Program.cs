using System.Drawing;

namespace CrabPaint
{
    public static class Program
    {
        static Point s = new(4, 8);
        static Point e = new(7, 20);
        public static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                switch (args[0].ToUpperInvariant())
                {
                    case "LIST":
                        Draw.WriteAll();
                        break;
                    case "BOX":
                        if (args.Length > 4)
                        {
                            s = new(int.Parse(args[1]), int.Parse(args[2]));
                            e = new(int.Parse(args[3]), int.Parse(args[4]));
                        }
                        Draw.Box(s, e);
                        break;
                }
            }
        }
    }
}