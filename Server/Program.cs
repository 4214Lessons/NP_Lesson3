using System.Net;
using System.Net.Sockets;


var ip = IPAddress.Parse("127.0.0.1");
var port = 27001; 

var listener = new TcpListener(ip, port);

listener.Start(10);

Console.WriteLine($"{listener.Server.LocalEndPoint} listening...");
var client = listener.AcceptTcpClient();
Console.WriteLine($"{client.Client.RemoteEndPoint} connected...");

var clientStream = client.GetStream();



var filePath = @$"C:\Users\{Environment.UserName}\Desktop\hakuna-matata.jpg";

// Way 1
var bytes = File.ReadAllBytes(filePath);
clientStream.Write(bytes, 0, bytes.Length);


// Way 2
// FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
// fs.CopyTo(clientStream);
// fs.Flush();

Console.WriteLine("Completed");
Console.ReadLine();