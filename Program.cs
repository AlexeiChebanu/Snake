class Program
{
    public static int Width = 25;
    public static int Height = 15;
    static void Main(string[] args)
    {
        Start();
        Console.ReadKey(true);
    }

    static void Start()
    {
        DrawBorders();
        Console.CursorVisible = false;
        Player player = new Player(10, 10, '#', '0');
        player.Draw();

        ConsoleKey key = ConsoleKey.D;
        Eat eat = EventEat(player);

        while (true)
        {
            if (player.Head.X == eat.pixel.X && player.Head.Y == eat.pixel.Y ||
                player.Body.Any(part => part.X == eat.pixel.X && part.Y == eat.pixel.Y))
            {
                player.Grow();
                eat = EventEat(player);
            }
            if (Console.KeyAvailable)
            {
                key = ReadDirection(key);
            }

            player.ChangeDirection(key).Invoke();

            if (player.Head.X == 0 || player.Head.X == Width ||
                player.Head.Y == 0 || player.Head.Y == Height ||
                player.Body.Any(part => part.X == player.Head.X && part.Y == player.Head.Y))
            {
                break;
            }


            Thread.Sleep(200);
        }
        player.Death();
    }

    static Eat EventEat(Player player)
    {
        Eat eat = new Eat();
        do
        {
            eat.pixel.Draw();
        } while (player.Head.X == eat.pixel.X && player.Head.Y == eat.pixel.Y ||
                 player.Body.Any(part => part.X == eat.pixel.X && part.Y == eat.pixel.Y));

        return eat;
    }

    static ConsoleKey ReadDirection(ConsoleKey key)
    {
        ConsoleKey temp = Console.ReadKey(true).Key;
        switch (temp)
        {
            case ConsoleKey.W when key == ConsoleKey.S:
            case ConsoleKey.S when key == ConsoleKey.W:
            case ConsoleKey.A when key == ConsoleKey.D:
            case ConsoleKey.D when key == ConsoleKey.A:
                return key;
            case ConsoleKey.W:
            case ConsoleKey.S:
            case ConsoleKey.A:
            case ConsoleKey.D:
                key = temp;
                break;
        }

        return key;
    }
    static void DrawBorders()
    {
        for (int i = 1; i < Width; i++)
        {
            new Pixel(i, 0, '▀').Draw();
            new Pixel(i, Height, '▀').Draw();
        }

        for (int i = 1; i < Height; i++)
        {
            new Pixel(0, i, '█').Draw();
            new Pixel(Width, i, '█').Draw();
        }
    }
}
//checked
