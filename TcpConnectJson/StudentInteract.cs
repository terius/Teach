// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.StudentInteract
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

using System;

namespace TcpConnectJson
{
  public class StudentInteract
  {
    private Ffmpeg _ffmpeg = (Ffmpeg) null;
    private string audio = (string) null;
    private string _serverIp = (string) null;
    private string _ipSelf = (string) null;
    private string _rtspAddress = (string) null;
    private ClientConnectTcp _clientConnect;
    private int _portSelf;

    public StudentInteract(ClientConnectTcp ConnectTcp, string serverIP, string ipSelf, int portSelf)
    {
      this._clientConnect = ConnectTcp;
      this._serverIp = serverIP;
      this._ipSelf = ipSelf;
      this._portSelf = portSelf;
    }

    public StudentInteract(ClientConnectTcp ConnectTcp, string serverIP, string ipSelf, int portSelf, string audioName)
    {
      this._clientConnect = ConnectTcp;
      this._serverIp = serverIP;
      this._ipSelf = ipSelf;
      this._portSelf = portSelf;
      this.audio = audioName;
    }

    public void acceptInteractOrder()
    {
      this._rtspAddress = this.pushRtspStream(this._serverIp, this._ipSelf, this._portSelf);
      if (this._clientConnect == null || !this._clientConnect._tcpConnectState)
        return;
      this._clientConnect.BeginSendMessage(new Messages()
      {
        clientStyle = "STUDENT",
        order = "STUPREPAREFORINTERACT",
        ipSend = this._ipSelf,
        portSend = this._portSelf,
        time = DateTime.Now.ToString(),
        content = this._rtspAddress
      });
    }

    private string pushRtspStream(string ipServer, string ipSelf, int portSelf)
    {
      string nameByIpPort = this.createNameByIpPort(ipSelf, portSelf);
      string para = " -f gdigrab -i desktop -framerate 6 -g 36 -s 1000*750 -vcodec libx264 -x264opts bframes=3:b-adapt=0 -bufsize 2000k -threads 16 -preset:v ultrafast -tune:v zerolatency -f rtsp rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
      if (this.audio != null)
        para = " -f gdigrab -i desktop -i audio=\"" + this.audio + "\" -framerate 6 -g 240 -s 800*600 -acodec mp2 -ab 128k -vcodec libx264 -x264opts bframes=3:b-adapt=0 -bufsize 2000k -threads 16 -preset:v ultrafast -tune:v zerolatency -f rtsp rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
      this._ffmpeg = new Ffmpeg();
      this._ffmpeg.beginExecute(para);
      return "rtsp://" + ipServer + "/" + nameByIpPort + ".sdp";
    }

    public void stopPushRtsp()
    {
      if (this._ffmpeg == null)
        return;
      this._ffmpeg.dispose();
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
