using System.Net.Sockets;

using var client = new TcpClient("10.2.29.93", 27001);

var serverStream = client.GetStream();
var bw = new BinaryWriter(serverStream);
var br = new BinaryReader(serverStream);

Task.Run(() =>
{
    while (true)
    {
        Console.WriteLine(br.ReadString());
    }
});

while (true)
{
    bw.Write(Console.ReadLine() ?? string.Empty);
}