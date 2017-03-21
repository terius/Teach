using Cowboy.Sockets;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTCP
{
    public class SimpleMessageDispatcher : IAsyncTcpSocketClientMessageDispatcher
    {
       
        public delegate void ReceivedHandle(ReceieveMessage message);
        public event ReceivedHandle OnReceieveMessage;
        public SimpleMessageDispatcher()
        {
          
        }
        public async Task OnServerConnected(AsyncTcpSocketClient client)
        {
            Console.WriteLine(string.Format("TCP server {0} has connected.", client.RemoteEndPoint));
            await Task.CompletedTask;
        }

        public async Task OnServerDataReceived(AsyncTcpSocketClient client, byte[] data, int offset, int count)
        {
            int newOffset = offset;
            ReceieveMessage message = null;
            while (newOffset < (offset + count))
            {
                message = TcpHelper.CreateReceieveMessage(data, ref newOffset);
                OnReceieveMessage(message);
            }
            await Task.CompletedTask;
        }



        public async Task OnServerDisconnected(AsyncTcpSocketClient client)
        {
            Console.WriteLine(string.Format("TCP server {0} has disconnected.", client.RemoteEndPoint));
            await Task.CompletedTask;
        }
    }
}
