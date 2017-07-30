using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace StudentUDP
{
    class Program
    {
        static UdpClient uClient;
        static void Main(string[] args)
        {
            //  CreateUDPReceive();
            // CreateUDPConnect();
            CreateUDP();
            TestSend();
            Console.ReadKey();
        }
        static string romoteip;
        static int romoteport;
        private static void TestSend()
        {
            while (true)
            {
                string str = Console.ReadLine();
                var bt = Encoding.UTF8.GetBytes(str);
                uClient.Send(bt, bt.Length, romoteip, romoteport);

            }
        }

        private static void CreateUDPReceive()
        {
            Thread t = new Thread(new ThreadStart(CreateUDPServer));
            t.IsBackground = true;
            t.Start();
        }


        static IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        private static void CreateUDPServer()
        {

            var receieveUdpClient = new UdpClient(10888);


            Byte[] receiveBytes = receieveUdpClient.Receive(ref RemoteIpEndPoint);
            var str = Encoding.UTF8.GetString(receiveBytes);

        }

        private static void CreateUDPConnect()
        {
            Thread t = new Thread(new ThreadStart(CreateUDP));
            t.IsBackground = true;
            t.Start();
        }

        private static void CreateUDP()
        {
            IPEndPoint fLocalIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            uClient = new UdpClient(fLocalIPEndPoint);
            uint IOC_IN = 0x80000000;
            uint IOC_VENDOR = 0x18000000;
            uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
            uClient.Client.IOControl((int)SIO_UDP_CONNRESET, new byte[] { Convert.ToByte(false) }, null);
            //  uClient = new UdpClient(10888);
            // var remoteEP = new IPEndPoint(IPAddress.Parse("118.184.18.254"), 10888);
            UdpBeginGetRece();
        //    uClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);
            var bt = Encoding.UTF8.GetBytes("STUDENT");
            //118.184.18.254
            uClient.Send(bt, bt.Length, "118.184.18.254", 10888);
            //while (true)
            //{
            //    Byte[] receiveBytes = uClient.Receive(ref RemoteIpEndPoint);
            //    var str = Encoding.UTF8.GetString(receiveBytes);
            //    Console.WriteLine(str);
            //    if (str.Contains(":"))
            //    {
            //        romoteip = str.Substring(1, str.LastIndexOf(":") - 1);
            //        romoteport = Convert.ToInt32(str.Substring(str.LastIndexOf(":") + 1));
            //    }

            //    Thread.Sleep(200);

            //}

        }

        private static void UdpBeginGetRece()
        {
            Thread t = new Thread(new ThreadStart(ReceiveCallback));
            t.IsBackground = true;
            t.Start();
        }

        private static void ReceiveCallback()
        {

            byte[] fData = null;
            while (true)
            {
                IPEndPoint remoteIPE = new IPEndPoint(IPAddress.Any, 0);
                fData = uClient.Receive(ref remoteIPE);//UDP接收数据  
                string fContent = Encoding.UTF8.GetString(fData);
                Console.WriteLine(fContent);
                if (fContent.Contains(":"))
                {
                    romoteip = fContent.Substring(1, fContent.LastIndexOf(":") - 1);
                    romoteport = Convert.ToInt32(fContent.Substring(fContent.LastIndexOf(":") + 1));
                }

                //if (btRec.Length > 0 && remoteIPE.Address == ServerIPE.Address)//只处理特定的服务端的数据  
                //{
                //    System.Windows.Forms.MessageBox.Show("res");
                //}
                //else
                //{
                //}

            }


            //try
            //{
            //    if (uClient.Client != null)
            //    {
            //        IPEndPoint fClientIPEndPoint = null;
            //        byte[] fData = uClient.EndReceive(ar, ref fClientIPEndPoint);
            //        if (fData.Length > 0)
            //        {//数据接收成功,放入缓存
            //            string fContent = Encoding.UTF8.GetString(fData);
            //            Console.WriteLine(fContent);
            //            if (fContent.Contains(":"))
            //            {
            //                romoteip = fContent.Substring(1, fContent.LastIndexOf(":") - 1);
            //                romoteport = Convert.ToInt32(fContent.Substring(fContent.LastIndexOf(":") + 1));
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //finally
            //{
            //    try
            //    {
            //        uClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }
            //}
        }
    }
}
