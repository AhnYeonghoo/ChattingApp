using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChattingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("서버 콘솔창 \n\n\n");
            TcpListener server = new TcpListener(IPAddress.Any, 9999);
            server.Start();

            TcpClient client = server.AcceptTcpClient();
            NetworkStream ns = client.GetStream();

            byte[] byteData = new byte[1024];
            ns.Read(byteData, 0, byteData.Length);

            string stringData = Encoding.Default.GetString(byteData);
            Console.WriteLine(stringData);
            server.Stop();
            ns.Close();

        }
    }
}
