using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocket
{
    public sealed class WebSocketTestResult
    {
        public bool Success { get; }
        public string Message { get; }

        public WebSocketTestResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
