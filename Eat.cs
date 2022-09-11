public class Eat
{
    static Random random = new Random();
    public Pixel pixel { get; }

    public Eat()
    {
        pixel = new Pixel(random.Next(1, Program.Width - 1), random.Next(1, Program.Height - 1), '+');
    }
}