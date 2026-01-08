using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace WebSocket
{
    public static class WebSocketTester
    {
        public static async Task<WebSocketTestResult> TestConnectionAsync(Uri uri, TimeSpan timeout)
        {
            using var webSocket = new ClientWebSocket();
            using var cts = new CancellationTokenSource(timeout);

            try
            {
                await webSocket.ConnectAsync(uri, cts.Token);

                if (webSocket.State == WebSocketState.Open)
                {
                    return new WebSocketTestResult(true, "WebSocket connection established successfully.");
                    //resultMessage = "WebSocket connection established successfully.";
                    //return true;
                }

                return new WebSocketTestResult(false, $"Unexpected WebSocket state: {webSocket.State}");
                //resultMessage = $"Unexpected WebSocket state: {webSocket.State}";
                //return false;
            }
            catch (OperationCanceledException)
            {
                return new WebSocketTestResult(false, "Connection attempt timed out.");
                //resultMessage = "Connection attempt timed out.";
                //return false;
            }
            catch (WebSocketException ex)
            {
                return new WebSocketTestResult(false, $"WebSocket error: {ex.Message}");
                //resultMessage = $"WebSocket error: {ex.Message}";
                //return false;
            }
            catch (Exception ex)
            {
                return new WebSocketTestResult(false, $"Unexpected error: {ex.Message}");
                //resultMessage = $"Unexpected error: {ex.Message}";
                //return false;
            }
        }
    }
}
