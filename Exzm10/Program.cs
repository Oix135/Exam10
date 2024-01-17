namespace Exzm10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            _ = new Calculator(logger);
        }
    }
}
