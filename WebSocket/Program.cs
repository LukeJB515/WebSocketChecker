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
                //Console.Clear();
                MenuService.PrintMainMenu();
                int choice = MenuService.GetMenuSelection(1, 2);

                switch (choice)
                {
                    case 1:
                        await ShowWebSocketMenuAsync();
                        break;

                    case 2:
                        exitRequested = true;
                        break;
                }

                //Console.Write("Select an option: ");
                //string? input = Console.ReadLine();

                //switch (input)
                //{
                //    case "1":
                //        await ShowWebSocketMenuAsync();
                //        break;

                //    case "2":
                //        exitRequested = true;
                //        break;

                //    default:
                //        Console.WriteLine("Invalid selection. Press any key to continue...");
                //        Console.ReadKey();
                //        break;
                //}
            }
        }
                
        private static async Task ShowWebSocketMenuAsync()
        {
            bool returnToMainMenu = false;

            while (!returnToMainMenu)
            {
                //Console.Clear();
                MenuService.PrintWebSocketMenu();
                int choice = MenuService.GetMenuSelection(1, 3);
                //PrintMainMenu();

                //Console.Write("Select an option.");
                //string? input = Console.ReadLine();

                //switch (input)
                switch (choice)
                {
                    case 1:
                        await HandleKnownWebSocketAsync();
                        break;

                    case 2:
                        await HandleCustomWebSocketAsync();
                        break;

                    case 3:
                        returnToMainMenu = true;
                        break;

                    //default:
                    //    Console.WriteLine("Invalid selection. Press any key to continue...");
                    //    Console.ReadKey();
                    //    break;
                }
            }

            //await Task.CompletedTask;
        }

        private static async Task HandleKnownWebSocketAsync()
        {
            var knownSockets = WebSocketRegistry.GetAll();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Known WebSockts ===");

                for (int i = 0; i < knownSockets.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {knownSockets[1]}");
                }

                Console.WriteLine($"{knownSockets.Count + 1}. Return");
                Console.WriteLine();

                int choice = MenuService.GetMenuSelection(1, knownSockets.Count + 1);

                if (choice == knownSockets.Count + 1)
                    return;

                string selected = knownSockets[choice - 1];

                if (!WebSocketValidator.IsValidUri(selected, out string error))
                {
                    MenuService.ShowMessage(error);
                    MenuService.WaitForKeyPress();
                    continue;
                }

                var result = await WebSocketTester.TestConnectionAsync(
                    new Uri(selected),
                    TimeSpan.FromSeconds(5));

                Console.WriteLine(result.Success ? "SUCCESS" : "FAILURE");
                Console.WriteLine(result.Message);
                MenuService.WaitForKeyPress();
            }
        }

        private static async Task HandleCustomWebSocketAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Enter Custom WebSocket ===");
            Console.Write("WebSocket URI: ");
            string? input = Console.ReadLine();

            if (!WebSocketValidator.IsValidUri(input!, out string error))
            {
                MenuService.ShowMessage(error);
                MenuService.WaitForKeyPress();
                return;
            }

            var result = await WebSocketTester.TestConnectionAsync(
                new Uri(input!),
                TimeSpan.FromSeconds(5));

            Console.WriteLine(result.Success ? "SUCCESS" : "FAILURE");
            Console.WriteLine(result.Message);
            MenuService.WaitForKeyPress();
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine("===WebSocket Checker===");
            Console.WriteLine("1. Check a WebSocket");
            Console.WriteLine("2. Exit");
            Console.WriteLine();
        }

        private static void PrintWebSocketMenu()
        {
            Console.WriteLine("=== WebSocket Options ===");
            Console.WriteLine("1. Check a known WebSocket");
            Console.WriteLine("2. Enter a new WebSocket");
            Console.WriteLine("3. Return to main menu");
            Console.WriteLine();
        }

        //private static async Task HandleKnownWebSocket()
        //{
        //    bool returnToWebSocketMenu = false;

        //    while (!returnToWebSocketMenu)
        //    {
        //        Console.Clear();
        //        var knownSockets = WebSocketRegistry.GetAll();

        //        Console.WriteLine("=== Known WebSockets ===");
        //        for (int i = 0; i < knownSockets.Count; i++)
        //        {
        //            Console.WriteLine($"{i + 1}. {knownSockets[i]}");
        //        }
        //        Console.WriteLine($"{knownSockets.Count + 1}. Return to previous menu");
        //        Console.WriteLine();

        //        Console.Write("Select a WebSocket to check: ");
        //        string? input = Console.ReadLine();

        //        if (!int.TryParse(input, out int selection) || selection < 1 || selection > knownSockets.Count + 1)
        //        {
        //            Console.WriteLine("Invalid selection. Press any key to try again...");
        //            Console.ReadKey();
        //            continue;
        //        }

        //        if (selection == knownSockets.Count + 1)
        //        {
        //            returnToWebSocketMenu = true;
        //            continue;
        //        }

        //        string selectedWebSocket = knownSockets[selection - 1];

        //        if (WebSocketValidator.IsValidUri(selectedWebSocket, out string? errorMessage))
        //        {
        //            Console.WriteLine($"\nSelected WebSocket: {selectedWebSocket}");
        //            Console.WriteLine("Validating connectivity...");

        //            Uri uri = new Uri(selectedWebSocket);

        //            var result = await WebSocketTester.TestConnectionAsync(uri, TimeSpan.FromSeconds(5));
        //            bool success = result.Success;
        //            string resultMessage = result.Message;

        //            Console.WriteLine();
        //            Console.WriteLine(success ? "SUCCESS" : "FAILURE");
        //            Console.WriteLine(resultMessage);
        //        }
        //        else
        //        {
        //            Console.WriteLine($"\nError: {errorMessage}");
        //        }

        //        Console.WriteLine("");
        //        Console.ReadKey();
        //    }
        //}
        
        //private static async Task HandleCustomWebSocket()
        //{
        //    Console.Clear();
        //    Console.WriteLine("=== Enter a Custom WebSocket ===");
        //    Console.Write("WebSocket URI: ");
        //    string? input = Console.ReadLine();

        //    if (!WebSocketValidator.IsValidUri(input!, out string? errorMessage))
        //    {
        //        Console.WriteLine($"\nYou entered: {input}");
        //        Console.WriteLine("WebSocket URI is valid.");
        //        Console.WriteLine("\n[Future: Here we will test connectivity]");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"\nError: {errorMessage}");
        //        Console.WriteLine("\nPress any key to return...");
        //        Console.ReadKey();
        //        return;
        //    }

        //    Uri uri = new Uri(input!);

        //    Console.WriteLine("\nValidating connectivity...");

        //    var result = await WebSocketTester.TestConnectionAsync(uri, TimeSpan.FromSeconds(5));
        //    bool success = result.Success;
        //    string resultMessage = result.Message;

        //    Console.WriteLine();
        //    Console.WriteLine(success ? "SUCCESS" : "FAILURE");
        //    Console.WriteLine(resultMessage);

        //    Console.WriteLine("Press any key to return...");
        //    Console.ReadKey();
        //}

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