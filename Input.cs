namespace CrabPaint
{
    public static class Input
    {
        public static void MouseEnable() { Console.Write("\e[?1000h"); }
        public static void MouseDisable() { Console.Write("\e[?1000l"); }
        public static void MouseMotion() { Console.Write("\e[?1003h"); }
        public static void MouseExtended() { Console.Write("\e[?1006h"); }
    }
}