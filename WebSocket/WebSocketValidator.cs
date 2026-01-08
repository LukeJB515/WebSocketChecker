using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocket
{
    public static class WebSocketValidator
    {
        public static bool IsValidUri(string uriString, out string? errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(uriString))
            {
                errorMessage = "WebSocket URI cannot be empty.";
                return false;
            }

            if (!Uri.TryCreate(uriString, UriKind.Absolute, out Uri? uri))
            {
                errorMessage = "Invalid URI format.";
                return false;
            }

            if (uri.Scheme != "ws" && uri.Scheme != "wss")
            {
                errorMessage = "WebSocket URI must start with ws:// or wss://";
                return false;
            }

            return true;
        }
    }
}
