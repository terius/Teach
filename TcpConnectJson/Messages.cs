// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.Messages
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

namespace TcpConnectJson
{
  public class Messages
  {
    public string clientStyle { get; set; }

    public string ipSend { get; set; }

    public int portSend { get; set; }

    public string ipReceive { get; set; }

    public int portReceive { get; set; }

    public string name { get; set; }

    public string number { get; set; }

    public string order { get; set; }

    public string type { get; set; }

    public string content { get; set; }

    public string time { get; set; }

    public Messages()
    {
    }

    public Messages(string ipr, int portr)
    {
      this.ipReceive = ipr;
      this.portReceive = portr;
    }

    public Messages(string ips, int ports, string ipr, int portr)
    {
      this.ipSend = ips;
      this.portSend = ports;
      this.ipReceive = ipr;
      this.portReceive = portr;
    }
  }
}
