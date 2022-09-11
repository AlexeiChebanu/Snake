public class Pixel
{
    public int X { get; }
    public int Y { get; }

    public char Symbol { get; }

    public Pixel(int x, int y, char symbol)
    {
        X = x;
        Y = y;
        Symbol = symbol;
    }

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(Symbol);
    }

    public void Clear()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(' ');
    }
}