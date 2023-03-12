using System.Net;
using System.Net.Sockets;

var clients = new HashSet<TcpClient>();

var ip = IPAddress.Parse("10.2.29.93");
var port = 27001;


var listener = new TcpListener(ip, port);

listener.Start(10);

while (true)
{
    var client = listener.AcceptTcpClient();
    Console.WriteLine($"{client.Client.RemoteEndPoint} connected...");
    clients.Add(client);

    Task.Run(() =>
    {
        var clientStream = client.GetStream();
        var br = new BinaryReader(clientStream);

        var readString = string.Empty;
        var userIPEndPoint = string.Empty;
        var index = 0;

        Console.ForegroundColor = (ConsoleColor)(Random.Shared.Next(15) + 1);

        while (true)
        {
            readString = br.ReadString();
            // Console.WriteLine($"{clientStream.Socket.RemoteEndPoint} - {readString}");

            index = readString.IndexOf(' ');
            userIPEndPoint = readString.Substring(0, index);

            var destination = clients.FirstOrDefault(c => c.Client.RemoteEndPoint?.ToString() == userIPEndPoint);

            var bw = new BinaryWriter(destination!.GetStream());
            bw.Write($"{clientStream.Socket.RemoteEndPoint} - {readString.Substring(index + 1)}");
        }
    });
}