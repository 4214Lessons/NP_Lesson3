using System.Net;
using System.Net.Sockets;


var ipString = "127.0.0.1";
var port = 27001;


// var ipAddress = IPAddress.Parse(ipString);
   
// using var client = new TcpClient();
// client.Connect(ipAddress, port);



using var client = new TcpClient(ipString, port);


var stream = client.GetStream();
var bw = new BinaryWriter(stream);
var br = new BinaryReader(stream);


while (true)
{
    bw.Write(Console.ReadLine() ?? string.Empty);
    Console.WriteLine($"Answer: {br.ReadString()}");
}