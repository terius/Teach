using Cowboy.Sockets;
using Helpers;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTCP
{
    public class TcpHelper
    {
        public static byte[] CreateSendMessageByte<T>(SendMessage<T> message) where T : class, new()
        {
            string jsonString = JsonHelper.SerializeObj(message.Data) + "\0";
            byte[] dataBytes = Encoding.UTF8.GetBytes(jsonString);
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            byte[] timeBytes = Encoding.UTF8.GetBytes(time);
            var actionBytes = BitConverter.GetBytes(message.Action);
            var lengthByte = BitConverter.GetBytes(dataBytes.Length + timeBytes.Length + actionBytes.Length);// StringHelper.ConvertIntToByteArray4(dataBytes.Length + 18, ref buf);

            List<byte> byteSource = new List<byte>();
            byteSource.AddRange(lengthByte);
            byteSource.AddRange(timeBytes);
            byteSource.AddRange(actionBytes);
            byteSource.AddRange(dataBytes);
            return byteSource.ToArray();
        }

        public static ReceieveMessage CreateReceieveMessage(byte[] data, ref int newOffset)
        {
            ReceieveMessage message = new ReceieveMessage();
            int tempOffset = newOffset;
            var lenBytes = new byte[4];
            Array.Copy(data, tempOffset, lenBytes, 0, 4);
            message.Length = BitConverter.ToInt32(lenBytes, 0);

            tempOffset += 4;
            var timeBytes = new byte[14];
            Array.Copy(data, tempOffset, timeBytes, 0, 14);
            message.TimeStamp = Encoding.UTF8.GetString(timeBytes);

            tempOffset += 14;
            var actionBytes = new byte[4];
            Array.Copy(data, tempOffset, actionBytes, 0, 4);
            message.Action = BitConverter.ToInt32(actionBytes, 0);

            tempOffset += 4;
            var dataLength = message.Length - 18;
            var dataBytes = new byte[dataLength];
            Array.Copy(data, tempOffset, dataBytes, 0, dataLength);
            message.DataStr = Encoding.UTF8.GetString(dataBytes);
            newOffset += message.Length + 4;
            return message;
            //    LoginResult info = JsonHelper.DeserializeObj<LoginResult>(datas);


        }



        public static async Task SendMessage<T>(SendMessage<T> message, AsyncTcpSocketClient client) where T : class, new()
        {
            var messageByte = CreateSendMessageByte(message);
            if (messageByte == null || messageByte.Length <= 0)
            {
                throw new Exception("发送消息长度错误");
            }
            if (client != null)
            {
                await client.SendAsync(messageByte);
            }
            else
            {
                throw new Exception("客户端TCP未初始化");
            }
        }
    }
}
