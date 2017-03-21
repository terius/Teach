// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.UserInfm
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

namespace TcpConnectJson
{
  public class UserInfm
  {
    public string ip;
    public int port;
    public string name;
    public string number;
    public string role;
    public string deviceType;
    public string screenState;

    public UserInfm(string ip, int port)
    {
      this.ip = ip;
      this.port = port;
    }
  }
}
