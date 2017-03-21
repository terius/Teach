namespace Common
{
    public enum CommandType
    {
        Send_UserLogin = 1,
        Rece_UserLogin = 2,
        Send_OnlineList = 3,
        Send_ScreenInteract=7,
        Lock_Screen_Request=11,
        Stop_Lock_Screen_Request = 12
    }

    /// <summary>
    /// 设备类型
    /// </summary>
    public enum ClientStyle
    {
        
        PC = 1,
        Android = 2
    }

    /// <summary>
    /// 登陆用户类型
    /// </summary>
    public enum ClientRole
    {
        Teacher = 1,
        Assistant = 2,
        Student = 3
    }
}
