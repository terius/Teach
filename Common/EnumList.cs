namespace Common
{
    public enum CommandType
    {
        UserLogin = 1,
        UserLoginRes = 2,
        OnlineList = 3,
        BeginCall = 5,
        EndCall = 6,
        ScreenInteract = 7,
        StopScreenInteract = 8,
        Quiet = 9,
        StopQuiet = 10,
        LockScreen = 11,
        StopLockScreen = 12,
        PrivateChat = 13,
        GroupChat = 14,
        CreateTeam = 15,
        TeamChat = 16,
        OneUserLogIn = 17,
        UserLoginOut = 18,
        StudentCall = 19
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

    public enum ChatType
    {
        PrivateChat,
        GroupChat,
        TeamChat
    }
}
