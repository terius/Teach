// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.ScreenInteract
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

//using DirectShowLib;
using DirectShowLib;
using Helpers;
using System;
using System.Management;

namespace MyTCP
{
    public class ScreenInteract
    {
        private string audio = (string)null;
        private Ffmpeg _ffmpeg = (Ffmpeg)null;
        private string _rtspAddress = (string)null;
        private bool isBeginScreenInteract = false;
        // private ClientConnectTcp _clientConnect;
        private string _serverIp;
        private string _ipSelf;
        private int _portSelf;
        private int widthPixel;
        private int heightPixel;







        public ScreenInteract(string serverIP, string ipSelf, int portSelf)
        {

            this._serverIp = serverIP;
            this._ipSelf = ipSelf;
            this._portSelf = portSelf;
        }

        public ScreenInteract(string serverIP, string ipSelf, int portSelf, string audioName)
        {
            this._serverIp = serverIP;
            this._ipSelf = ipSelf;
            this._portSelf = portSelf;
            this.audio = audioName;
        }

        public string beginScreenInteract()
        {
            this._rtspAddress = this.pushRtspStream(this._serverIp, this._ipSelf, this._portSelf);

            this.isBeginScreenInteract = true;
            return this._rtspAddress;
        }

        public void stopScreenInteract()
        {
            if (!this.isBeginScreenInteract)
                return;
            this._ffmpeg.dispose();
            this.isBeginScreenInteract = false;
        }

        private string GetMicName()
        {
            var capDevices = DsDevice.GetDevicesOfCat(FilterCategory.AudioInputDevice);

            foreach (var item in capDevices)
            {
                if (item.Name.Contains("麦克风"))
                {
                    return item.Name;
                }
            }
            return "";
        }

        private string pushRtspStream(string ipServer, string ipSelf, int portSelf)
        {
            ipServer = "192.168.100.16";
          //  this.audio = "Default WaveOut Device";
            string nameByIpPort = this.createNameByIpPort(ipSelf, portSelf);
            string mic = GetMicName();
            if (!string.IsNullOrWhiteSpace(mic))
            {
                mic = string.Format("-f dshow -i audio=\"{0}\"", mic);
            }
            mic = "";
            var rtspUrl = "rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
          //  rtspUrl = "videos\\" + DateTime.Now.ToString("HHmmssfff") + ".mpg";
          //  string para = string.Format("-f gdigrab -i desktop {1}  -s 1920*1080 -vcodec libx264 -framerate 10  {0}", rtspUrl, mic);
              string para = " -f gdigrab -i desktop -framerate 6 -g 36 -s 1280*760 -vcodec libx264 -x264opts bframes=3:b-adapt=0 -bufsize 2000k -threads 16 -preset:v ultrafast -tune:v zerolatency -f rtsp rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
            if (this.audio != null)
                para = " -f gdigrab -i desktop -i audio=\"" + this.audio + "\" -framerate 6 -g 240 -s 1024*768 -acodec mp2 -ab 128k -vcodec libx264 -x264opts bframes=3:b-adapt=0 -bufsize 2000k -threads 16 -preset:v ultrafast -tune:v zerolatency -f rtsp rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
            this._ffmpeg = new Ffmpeg();
            this._ffmpeg.beginExecute(para);
           // var rtsp = "rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
            return rtspUrl;
        }

        private string createNameByIpPort(string ip, int port)
        {
            string[] strArray = ip.Split('.');
            string str = "interact";
            if (strArray.Length > 0)
            {
                for (int index = 0; index < strArray.Length; ++index)
                    str += strArray[index];
            }
            return str + port.ToString();
        }
    }
}
