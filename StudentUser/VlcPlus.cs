// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.VlcPlayer
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

using AxAXVLC;
using System;
using System.Threading;

namespace StudentUser
{
    public class VLCPlus
    {
        private string param = ":network-caching=300:rtsp-caching=300:no-video-title-show";
        public AxVLCPlugin2 axVLCPlugin2;
        private int Width;
        private int Height;
        private playVideoCallBackHandler rtspPlayer;
        public playFailedCallBackHandler playFailedHandler;

        public VLCPlus(AxVLCPlugin2 axVLCPlugin21)
        {
            this.axVLCPlugin2 = axVLCPlugin21;
            this.Width = axVLCPlugin21.Width;
            this.Height = axVLCPlugin21.Height;
            this.rtspPlayer = new playVideoCallBackHandler(this.playVideo);
        }

        public VLCPlus(AxVLCPlugin2 axVLCPlugin21, int width, int height)
        {
            this.axVLCPlugin2 = axVLCPlugin21;
            this.Width = width;
            this.Height = height;
            this.rtspPlayer = new playVideoCallBackHandler(this.startPlay);
        }

        public void startPlay(string rtsp)
        {
            this.axVLCPlugin2.Invoke((Delegate)this.rtspPlayer, (object)rtsp);
        }

        private void playVideo(string rtsp)
        {
            this.axVLCPlugin2.Width = this.Width;
            this.axVLCPlugin2.Height = this.Height;
            this.axVLCPlugin2.Toolbar = false;
            this.axVLCPlugin2.AllowDrop = false;
            this.axVLCPlugin2.playlist.items.clear();
            this.axVLCPlugin2.FullscreenEnabled = false;
            this.axVLCPlugin2.playlist.add(rtsp, (object)"", (object)this.param);
            try
            {
                this.axVLCPlugin2.playlist.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(1000);
            int num = 1;
            while (!this.axVLCPlugin2.playlist.isPlaying)
            {
                this.axVLCPlugin2.playlist.add(rtsp, (object)"", (object)this.param);
                this.axVLCPlugin2.playlist.next();
                this.axVLCPlugin2.playlist.items.clear();
                if (num == 100)
                {
                    this.playFailedHandler.BeginInvoke((AsyncCallback)null, (object)null);
                    this.dispose();
                    break;
                }
                ++num;
                Thread.Sleep(num * 1000);
            }
        }

        public void dispose()
        {
            if (this.axVLCPlugin2.playlist.isPlaying)
                this.axVLCPlugin2.playlist.stop();
            this.axVLCPlugin2.Dispose();
        }

        private delegate void playVideoCallBackHandler(string rtsp);

        public delegate void playFailedCallBackHandler();
    }
}
