using System.Net.Sockets;

var ipString = "127.0.0.1";
var port = 27001;

using var client = new TcpClient(ipString, port);

var serverStream = client.GetStream();

var fileStream = new FileStream("Emin-Matata.jpg", FileMode.Create, FileAccess.Write);
serverStream.CopyTo(fileStream);
fileStream.Flush();