using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;

namespace WebSocket
{
    public static class WebSocketRegistry
    {
        private static readonly List<string> KnownWebSockets = new()
        {
            "wss://echo.websocket.events",
            "wss://ws.ifelse.io",
            "wss://demos.kaazing.com/echo"
        };

        public static List<string> GetAll() => new(KnownWebSockets);

        public static string? GetByIndex(int index)
        {
            if (index >= 1 && index <= KnownWebSockets.Count)
                return KnownWebSockets[index - 1];
            return null;
        }
    }
}
