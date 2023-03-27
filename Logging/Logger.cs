using System.Diagnostics;

namespace Logging
{
    public static class Logger
    {
        public static void Debug(string message)
        {
            Console.Write($"[{DateTime.UtcNow}] ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write($"Debug");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($" {message}");
        }
        
        public static void Warning(string message)
        {
            Console.Write($"[{DateTime.UtcNow}] ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write($"Warning");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($" {message}");
        }
        
        public static void Error(string message)
        {
            Console.Write($"[{DateTime.UtcNow}] ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write($"Error");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($" {message}");
        }
        
        public static void Information(string message)
        {
            Console.Write($"[{DateTime.UtcNow}] ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write($"Information");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($" {message}");
        }
    }
}
