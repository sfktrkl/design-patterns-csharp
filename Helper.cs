namespace DesignPatterns
{
    partial class Helper
    {
        public static void Run(string message, Action action)
        {
            Console.WriteLine(message);
            Console.WriteLine("-----");
            action();
            Console.WriteLine("-----");
            Console.WriteLine("");
        }
    }
}