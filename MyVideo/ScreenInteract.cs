using DirectShowLib;
using Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyVideo
{
    public class ScreenInteract
    {
       
        private Ffmpeg _ffmpeg = null;
        private string _rtspAddress = null;
        private bool isBeginScreenInteract = false;
        // private ClientConnectTcp _clientConnect;
        private string _serverIp;
        private string _ipSelf;
        private int _portSelf;
        //  private int widthPixel;
        //  private int heightPixel;

        readonly string RTSPserverIP = System.Configuration.ConfigurationManager.AppSettings["RTSPserverIP"];
        public ScreenInteract(string serverIP, string ipSelf, int portSelf)
        {
            _serverIp = serverIP;
            _ipSelf = ipSelf;
            _portSelf = portSelf;
        }



        public string beginScreenInteract()
        {
            if (isBeginScreenInteract)
            {
                stopScreenInteract();
            }
            this._rtspAddress = this.pushRtspStream(this._serverIp, this._ipSelf, this._portSelf);

            this.isBeginScreenInteract = true;
            return this._rtspAddress;
        }

        public string beginVideoInteract()
        {
            if (isBeginScreenInteract)
            {
                stopScreenInteract();
            }
            _rtspAddress = pushVideoByFFmpeg(_serverIp, _ipSelf, _portSelf);

            isBeginScreenInteract = true;
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

        private string GetResolution()
        {
            var resolution = Screen.PrimaryScreen.Bounds;
            return resolution.Width + "*" + resolution.Height;
        }

        private string GetVideoName()
        {
            var capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            StringBuilder sb = new StringBuilder();
            foreach (var item in capDevices)
            {
                return item.Name;
            }
            return "";
        }

        private string pushRtspStream(string ipServer, string ipSelf, int portSelf)
        {
            var para = GetFFMpegParaAndUrl(ipServer, ipSelf, portSelf);
            var mic = GetMicName();
            var url = "-f gdigrab -i desktop ";
            if (!string.IsNullOrWhiteSpace(mic))
                url += " -f dshow -i audio=\"" + mic + "\" -acodec mp2 -ab 128k";
            url += para[1];
            Loger.LogMessage("视频命令:" + url);
            this._ffmpeg = new Ffmpeg();
            this._ffmpeg.beginExecute(url);
            // var rtsp = "rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
            return para[0];
        }

        private string[] GetFFMpegParaAndUrl(string ipServer, string ipSelf, int portSelf)
        {
            if (!string.IsNullOrWhiteSpace(RTSPserverIP))
            {
                ipServer = RTSPserverIP;
            }
            string nameByIpPort = createNameByIpPort(ipSelf, portSelf);
            var rtspUrl = "rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
            string para = " -framerate 15 -g 36 -s " + GetResolution() +" -vcodec libx264 -x264opts bframes=3:b-adapt=0 -bufsize 2000k -threads 16 -preset:v ultrafast -tune:v zerolatency -f rtsp rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
            return new string[] { rtspUrl, para };
        }

        private string pushVideoByFFmpeg(string ipServer, string ipSelf, int portSelf)
        {
            var para = GetFFMpegParaAndUrl(ipServer, ipSelf, portSelf);
            var video = GetVideoName();
            if (string.IsNullOrWhiteSpace(video))
            {
                throw new Exception("未找到摄像头");
            }
            var url = "-f dshow -i video=\"" + video + "\"";
            var mic = GetMicName();
            if (!string.IsNullOrWhiteSpace(video))
            {
                url += ":audio =\"" + mic + "\" -acodec mp2 -ab 128k";
            }
            url += para[1];
            Loger.LogMessage("视频命令:" + url);
            this._ffmpeg = new Ffmpeg();
            this._ffmpeg.beginExecute(url);
            return para[0];
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


    public class Ffmpeg
    {
        private Process myProcess = null;

        public event MessageReceivedEventHandler MessageReceived;

        public void execute(string para)
        {
            try
            {
                this.myProcess = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo("ffmpeg.exe", para);
                this.myProcess.StartInfo = processStartInfo;
                processStartInfo.UseShellExecute = false;
                processStartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;//  Application.StartupPath;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardInput = true;
                this.myProcess.Start();
                StreamReader standardOutput = this.myProcess.StandardOutput;
                this.myProcess.WaitForExit();
                while (!standardOutput.EndOfStream)
                    this.MessageReceived.BeginInvoke(standardOutput.ReadLine(), (AsyncCallback)null, (object)null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void beginExecute(string para)
        {
            try
            {
                new Thread(() =>
                {
                    this.myProcess = new Process();
                    ProcessStartInfo processStartInfo = new ProcessStartInfo("ffmpeg.exe", para);
                    this.myProcess.StartInfo = processStartInfo;
                    processStartInfo.UseShellExecute = false;
                    processStartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    processStartInfo.CreateNoWindow = true;
                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.RedirectStandardInput = true;
                    this.myProcess.Start();
                    StreamReader standardOutput = this.myProcess.StandardOutput;
                    this.myProcess.WaitForExit();
                    while (!standardOutput.EndOfStream)
                        this.MessageReceived.BeginInvoke(standardOutput.ReadLine(), (AsyncCallback)null, (object)null);
                }).Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void dispose()
        {
            if (this.myProcess.HasExited)
                return;
            this.myProcess.Refresh();
            this.myProcess.CloseMainWindow();
            this.myProcess.Kill();
            this.myProcess.Dispose();
            this.myProcess.Close();
        }

        public delegate void MessageReceivedEventHandler(string msg);
    }
}
