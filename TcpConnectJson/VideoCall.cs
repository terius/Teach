// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.VideoCall
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

using System;

namespace TcpConnectJson
{
  public class VideoCall
  {
    private bool _isMakeCall = false;
    private string _serverIp = (string) null;
    private string _ipAnswerCall = (string) null;
    private string _ipMakeCall = (string) null;
    private VlcPlayer _player = (VlcPlayer) null;
    private string _camera = (string) null;
    private string _role = (string) null;
    private string _param = (string) null;
    private string _videoNameSelf = (string) null;
    private int _portAnswerCall;
    private int _portMakeCall;
    private ClientConnectTcp _clientConnect;
    private Ffmpeg _ffmpeg;

    public VideoCall(ClientConnectTcp ConnectTcp, string serverIP, string ipSelf, int portSelf, string ipReceive, int portReceive, VlcPlayer vplayer, string camera, string userRole)
    {
      this._clientConnect = ConnectTcp;
      this._serverIp = serverIP;
      this._ipMakeCall = ipSelf;
      this._portMakeCall = portSelf;
      this._ipAnswerCall = ipReceive;
      this._portAnswerCall = portReceive;
      this._player = vplayer;
      this._camera = camera;
      this._role = userRole;
      this._videoNameSelf = this.createNameByIpPort(ipSelf, portSelf);
      this._ffmpeg = new Ffmpeg();
      this._param = " -f dshow -i video=\"" + this._camera + "\" -framerate 18 -g 36 -s 240*180 -threads 16 -bufsize 2000k -vcodec libx264 -x264opts bframes=3:b-adapt=0 -preset:v ultrafast -tune:v zerolatency -f rtsp rtsp://" + this._serverIp + "/" + this._videoNameSelf + ".sdp";
    }

    public void makeCall_A()
    {
      this._ffmpeg.beginExecute(this._param);
      this._isMakeCall = true;
      if (this._clientConnect == null || !this._clientConnect._tcpConnectState)
        return;
      this._clientConnect.BeginSendMessage(new Messages()
      {
        clientStyle = this._role,
        order = "STUREQUIREVIDEOCALL",
        ipSend = this._ipMakeCall,
        portSend = this._portMakeCall,
        ipReceive = this._ipAnswerCall,
        portReceive = this._portAnswerCall,
        time = DateTime.Now.ToString(),
        content = "rtsp://" + this._serverIp + "/" + this._videoNameSelf + ".sdp"
      });
    }

    public void acceptCall_B(string rtspAddressRequireCall)
    {
      if (this._isMakeCall)
        return;
      this._ffmpeg.beginExecute(this._param);
      if (this._clientConnect != null && this._clientConnect._tcpConnectState)
        this._clientConnect.BeginSendMessage(new Messages()
        {
          clientStyle = this._role,
          order = "STUACCEPTVIDEOCALL",
          ipSend = this._ipMakeCall,
          portSend = this._portMakeCall,
          ipReceive = this._ipAnswerCall,
          portReceive = this._portAnswerCall,
          time = DateTime.Now.ToString(),
          content = "rtsp://" + this._serverIp + "/" + this._videoNameSelf + ".sdp"
        });
      this._player.startPlay(rtspAddressRequireCall);
    }

    public void refuseCall_B()
    {
      this._clientConnect.BeginSendMessage(new Messages()
      {
        clientStyle = this._role,
        order = "STUREFUSEVIDEOCALL",
        ipSend = this._ipMakeCall,
        portSend = this._portMakeCall,
        ipReceive = this._ipAnswerCall,
        portReceive = this._portAnswerCall,
        time = DateTime.Now.ToString()
      });
    }

    public void makeCallSuccess_A(string rtsp)
    {
      if (!this._isMakeCall || this._player == null)
        return;
      this._player.startPlay(rtsp);
    }

    public void stopVideoCall()
    {
      if (this._clientConnect != null && this._clientConnect._tcpConnectState)
      {
        this._clientConnect.BeginSendMessage(new Messages()
        {
          clientStyle = this._role,
          order = "STUSTOPVIDEOCALL",
          ipSend = this._ipMakeCall,
          portSend = this._portMakeCall,
          ipReceive = this._ipAnswerCall,
          portReceive = this._portAnswerCall,
          time = DateTime.Now.ToString()
        });
        this.disposeVideoCall_AB();
      }
      this._isMakeCall = false;
    }

    public void disposeVideoCall_AB()
    {
      if (this._ffmpeg != null)
        this._ffmpeg.dispose();
      if (this._player == null)
        return;
      this._player.dispose();
    }

    private string createNameByIpPort(string ip, int port)
    {
      string[] strArray = ip.Split('.');
      string str = "";
      if (strArray.Length > 0)
      {
        for (int index = 0; index < strArray.Length; ++index)
          str += strArray[index];
      }
      return str + port.ToString();
    }
  }
}
