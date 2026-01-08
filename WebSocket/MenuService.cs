using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocket
{
    public static class MenuService
    {
        public static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Check WebSockets");
            Console.WriteLine("2. Exit");
            Console.WriteLine();
        }

        public static void PrintWebSocketMenu()
        {
            Console.Clear();
            Console.WriteLine("=== WebSocket Options ===");
            Console.WriteLine("1. Check a known WebSocket");
            Console.WriteLine("2. Enter a new WebSocket");
            Console.WriteLine("3. Return to the main menu");
            Console.WriteLine();
        }

        public static int GetMenuSelection(int minOption, int maxOption)
        {
            while (true)
            {
                Console.Write($"Select an option ({minOption}-{maxOption}): ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int selection) && selection >= minOption && selection <= maxOption)
                {
                    return selection;
                }

                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void WaitForKeyPress()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
