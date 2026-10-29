using System.Diagnostics.CodeAnalysis;

namespace CrabPaint
{
    public struct Pixel(char glyph, ConsoleColor foreground, ConsoleColor backGround)
    {
        public char Glyph = glyph;
        public ConsoleColor ForeGround = foreground;
        public ConsoleColor BackGround = backGround;


        //Overrides

        //Equality
        public static bool operator ==(Pixel left, Pixel right) 
            => left.Glyph == right.Glyph && 
            left.ForeGround == right.ForeGround &&
            left.BackGround == right.BackGround;

        public static bool operator !=(Pixel left, Pixel right) 
            => left.Glyph != right.Glyph || 
            left.ForeGround != right.ForeGround ||
            left.BackGround != right.BackGround;

        public override readonly string ToString()
        {
            return Glyph.ToString();
        }

        public override readonly bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is Pixel pixel && pixel == this;
        }

        public override readonly int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}