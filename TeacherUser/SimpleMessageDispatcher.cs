using Cowboy.Sockets;
using Model;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherUser
{
    public class SimpleMessageDispatcher : IAsyncTcpSocketClientMessageDispatcher
    {
        private Form _form;
        public delegate void ReceivedHandle(ReceieveMessage message);
        public event ReceivedHandle OnReceieveMessage;
        public SimpleMessageDispatcher(Form form)
        {
            this._form = form;
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
