using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class HiveNetworkClient : MonoBehaviour
{
    public static HiveNetworkClient Instance;
    public string serverUrl = "ws://localhost:3000";

    private ClientWebSocket socket;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
 
    async void Start()
    {
        await Connect();
    }

    private async Task Connect()
    {
        socket = new ClientWebSocket();
        try
        {
            Debug.Log("Connect: " + serverUrl);
            await socket.ConnectAsync(new Uri(serverUrl), CancellationToken.None);
            Debug.Log("Connected to server");

            // Handshake
            SendText("{\"type\":\"handshake\",\"payload\":\"HI_FROM_UNITY\"}");

            _ = ReceiveLoop();
        }
        catch (Exception ex)
        {
            Debug.LogError("Connection Error: " + ex.Message);
        }
    }

    private async Task ReceiveLoop()
    {
        var buffer = new byte[1024];
        while (socket.State == WebSocketState.Open)
        {
            var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                Debug.LogWarning("Server closed connection");
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "bye", CancellationToken.None);
            }
            else
            {
                string msg = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Debug.Log("Received: " + msg);
            }
        }
    }

    public async void SendText(string message)
    {
        if (socket == null || socket.State != WebSocketState.Open)
        {
            Debug.LogWarning("Connection not open");
            return;
        }

        byte[] bytes = Encoding.UTF8.GetBytes(message);
        await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        Debug.Log("Sent: " + message);
    }

    private async void OnApplicationQuit()
    {
        if (socket != null && socket.State == WebSocketState.Open)
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Unity closed", CancellationToken.None);
    }
}
