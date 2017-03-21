// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.ScreenMonitor
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

using System;

namespace TcpConnectJson
{
  public class ScreenMonitor
  {
    private VlcPlayer _player = (VlcPlayer) null;
    private Ffmpeg _ffmpeg = (Ffmpeg) null;
    private bool isTeacher = false;
    private ClientConnectTcp _clientConnect;
    private string _serverIp;
    private string _ipSelf;
    private int _portSelf;
    private ScreenMonitor.playVideoCallBackHandler rtspPlayer;

    public ScreenMonitor(ClientConnectTcp ConnectTcp, string serverIP, string ipSelf, int portSelf)
    {
      this._clientConnect = ConnectTcp;
      this._serverIp = serverIP;
      this._ipSelf = ipSelf;
      this._portSelf = portSelf;
    }

    public void requireMonitorVideo_A(string ipReceive, int portReceive)
    {
      if (this._clientConnect != null && this._clientConnect._tcpConnectState)
        this._clientConnect.BeginSendMessage(new Messages()
        {
          clientStyle = "TEACHER",
          order = "TECREQUIREMONITORVIDEO",
          ipSend = this._ipSelf,
          portSend = this._portSelf,
          ipReceive = ipReceive,
          portReceive = portReceive,
          time = DateTime.Now.ToString()
        });
      this.isTeacher = true;
    }

    public void acceptMonitorVideo_B(string ipReceive, int portReceive)
    {
      if (this.isTeacher)
        return;
      string str = this.pushRtspStream(this._serverIp, this._ipSelf, this._portSelf);
      if (this._clientConnect != null && this._clientConnect._tcpConnectState)
        this._clientConnect.BeginSendMessage(new Messages()
        {
          clientStyle = "STUDENT",
          order = "STUALREADYPUSHVIDEO",
          ipSend = this._ipSelf,
          portSend = this._portSelf,
          ipReceive = ipReceive,
          portReceive = portReceive,
          time = DateTime.Now.ToString(),
          content = str
        });
    }

    public void stopMonitorOrder_A(string ipReceive, int portReceive)
    {
      if (this._clientConnect != null && this._clientConnect._tcpConnectState)
        this._clientConnect.BeginSendMessage(new Messages()
        {
          clientStyle = "TEACHER",
          order = "TECSTOPMONITORVIDEO",
          ipSend = this._ipSelf,
          portSend = this._portSelf,
          ipReceive = ipReceive,
          portReceive = portReceive,
          time = DateTime.Now.ToString()
        });
      this.isTeacher = false;
    }

    public void stopPushVideo_B()
    {
      if (this._ffmpeg == null)
        return;
      this._ffmpeg.dispose();
    }

    private string pushRtspStream(string ipServer, string ipSelf, int portSelf)
    {
      string nameByIpPort = this.createNameByIpPort(ipSelf, portSelf);
      string para = " -f gdigrab -i desktop -framerate 6 -g 36 -s 800*600 -vcodec libx264 -x264opts bframes=3:b-adapt=0 -bufsize 2000k -threads 16 -preset:v ultrafast -tune:v zerolatency -f rtsp rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
      this._ffmpeg = new Ffmpeg();
      this._ffmpeg.beginExecute(para);
      return "rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
    }

    private void playRtspStream(string rtspAddress)
    {
      if (this._player == null)
        return;
      this._player.startPlay(rtspAddress);
    }

    private void playRtsp(string rtspAddress)
    {
      this._player.startPlay(rtspAddress);
    }

    private string createNameByIpPort(string ip, int port)
    {
      string[] strArray = ip.Split('.');
      string str = "monitor";
      if (strArray.Length > 0)
      {
        for (int index = 0; index < strArray.Length; ++index)
          str += strArray[index];
      }
      return str + port.ToString();
    }

    private delegate void playVideoCallBackHandler(string rtsp);
  }
}
