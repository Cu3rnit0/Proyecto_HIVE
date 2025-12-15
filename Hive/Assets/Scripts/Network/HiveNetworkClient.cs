using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class HiveNetworkClient : MonoBehaviour
{
    public static HiveNetworkClient Instance;

    [Header("HIVE Server")]
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

    private async void Start()
    {
        await Connect();
    }

    async Task Connect()
    {
        socket = new ClientWebSocket();

        try
        {
            Debug.Log("Conectando a HIVE Server...");
            await socket.ConnectAsync(new Uri(serverUrl), CancellationToken.None);
            Debug.Log("Conectado a HIVE Server");

            SendMessageToServer("HELLO_FROM_UNITY");

            _ = ReceiveLoop();
        }
        catch (Exception e)
        {
            Debug.LogError("Error de conexión: " + e.Message);
        }
    }

    async Task ReceiveLoop()
    {
        var buffer = new byte[1024];

        while (socket.State == WebSocketState.Open)
        {
            var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                Debug.Log("Servidor cerró la conexión");
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
            }
            else
            {
                string msg = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Debug.Log("Mensaje recibido: " + msg);
            }
        }
    }

    public async void SendMessageToServer(string message)
    {
        if (socket == null || socket.State != WebSocketState.Open) return;

        byte[] data = Encoding.UTF8.GetBytes(message);
        await socket.SendAsync(new ArraySegment<byte>(data), WebSocketMessageType.Text, true, CancellationToken.None);

        Debug.Log("Enviado: " + message);
    }

    private async void OnApplicationQuit()
    {
        if (socket != null && socket.State == WebSocketState.Open)
        {
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Unity closed", CancellationToken.None);
        }
    }
}
