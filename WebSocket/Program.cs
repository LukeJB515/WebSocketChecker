using System;
using System.Threading.Tasks;
using System.Net.WebSockets;

namespace WebSocket
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.Clear();
                PrintMainMenu();

                Console.Write("Select an option: ");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        await ShowWebSocketMenuAsync();
                        break;

                    case "2":
                        exitRequested = true;
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine("===WebSocket Checker===");
            Console.WriteLine("1. Check a WebSocket");
            Console.WriteLine("2. Exit");
            Console.WriteLine();
        }

        private static async Task ShowWebSocketMenuAsync()
        {
            bool returnToMainMenu = false;

            while (!returnToMainMenu)
            {
                Console.Clear();
                PrintWebSocketMenu();
                //PrintMainMenu();

                Console.Write("Select an option.");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        HandleKnownWebSocket();
                        break;

                    case "2":
                        HandleCustomWebSocket();
                        break;

                    case "3":
                        returnToMainMenu = true;
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

            await Task.CompletedTask;
        }

        private static void PrintWebSocketMenu()
        {
            Console.WriteLine("=== WebSocket Options ===");
            Console.WriteLine("1. Check a known WebSocket");
            Console.WriteLine("2. Enter a new WebSocket");
            Console.WriteLine("3. Return to main menu");
            Console.WriteLine();
        }

        private static void HandleKnownWebSocket()
        {
            bool returnToWebSocketMenu = false;

            while (!returnToWebSocketMenu)
            {
                Console.Clear();
                var knownSockets = WebSocketRegistry.GetAll();

                Console.WriteLine("=== Known WebSockets ===");
                for (int i = 0; i < knownSockets.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {knownSockets[i]}");
                }
                Console.WriteLine($"{knownSockets.Count + 1}. Return to previous menu");
                Console.WriteLine();

                Console.Write("Select a WebSocket to check: ");
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out int selection) || selection < 1 || selection > knownSockets.Count + 1)
                {
                    Console.WriteLine("Invalid selection. Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                if (selection == knownSockets.Count + 1)
                {
                    returnToWebSocketMenu = true;
                    continue;
                }

                string selectedWebSocket = knownSockets[selection - 1];

                if (WebSocketValidator.IsValidUri(selectedWebSocket, out string? errorMessage))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                }

                Console.WriteLine("");
                Console.ReadKey();
            }
        }
        
        private static void HandleCustomWebSocket()
        {
            Console.Clear();
            Console.WriteLine("Custom WebSocket entry not yet implemented.");
            Console.WriteLine();
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        //private static async Task HandleWebSocketCheckAsync()
        //{
        //    Console.Clear();
        //    Console.WriteLine("WebSocket checking not yet implemented.");
        //    Console.WriteLine();
        //    Console.WriteLine("Press any key to return to the main menu...");
        //    Console.ReadKey();

        //    await Task.CompletedTask;
        //}
    }    
}