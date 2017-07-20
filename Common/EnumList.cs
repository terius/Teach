namespace Common
{
    /// <summary>
    /// 命令字
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// 用户登陆
        /// </summary>
        UserLogin = 1,
        /// <summary>
        /// 用户登陆返回信息
        /// </summary>
        UserLoginRes = 2,
        /// <summary>
        /// 在线列表
        /// </summary>
        OnlineList = 3,
        /// <summary>
        /// 开始点名
        /// </summary>
        BeginCall = 5,
        /// <summary>
        /// 结束点名
        /// </summary>
        EndCall = 6,
        /// <summary>
        /// 开始屏幕广播
        /// </summary>
        ScreenInteract = 7,
        /// <summary>
        /// 结束屏幕广播
        /// </summary>
        StopScreenInteract = 8,
        /// <summary>
        /// 屏幕肃静
        /// </summary>
        Quiet = 9,
        /// <summary>
        /// 结束屏幕肃静
        /// </summary>
        StopQuiet = 10,
        /// <summary>
        /// 开始锁屏
        /// </summary>
        LockScreen = 11,
        /// <summary>
        /// 结束锁屏
        /// </summary>
        StopLockScreen = 12,
        /// <summary>
        /// 私聊
        /// </summary>
        PrivateChat = 13,
        /// <summary>
        /// 所有人对话
        /// </summary>
        GroupChat = 14,
        /// <summary>
        /// 创建群组
        /// </summary>
        CreateTeam = 15,
        /// <summary>
        /// 群聊（分组聊天）
        /// </summary>
        TeamChat = 16,
        /// <summary>
        /// 一个用户登陆进来
        /// </summary>
        OneUserLogIn = 17,
        /// <summary>
        /// 用户登出
        /// </summary>
        UserLoginOut = 18,
        /// <summary>
        /// 学生提交点名
        /// </summary>
        StudentCall = 19,
        StudentInMainForm = 20,
        /// <summary>
        /// 开始学生演示
        /// </summary>
        CallStudentShow = 21,
        ///// <summary>
        ///// 学生启动演示
        ///// </summary>
        //StudentBeginShow = 22,
        /// <summary>
        /// 停止学生演示
        /// </summary>
        StopStudentShow = 23,
        ///// <summary>
        ///// 视频直播
        ///// </summary>
        //VideoInteract = 24,
        ///// <summary>
        ///// 结束视频直播
        ///// </summary>
        //StopVideoInteract = 25,
        /// <summary>
        /// 禁止私聊
        /// </summary>
        ForbidPrivateChat=26,
        /// <summary>
        /// 允许私聊
        /// </summary>
        AllowPrivateChat = 27,
        /// <summary>
        /// 禁止群聊
        /// </summary>
        ForbidTeamChat=28,
        /// <summary>
        /// 允许群聊
        /// </summary>
        AllowTeamChat = 29,
        /// <summary>
        /// 教师端登录
        /// </summary>
        TeacherLoginIn=80,
        /// <summary>
        /// 教师端登出
        /// </summary>
        TeacherLoginOut = 81
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

    /// <summary>
    /// 聊天信息类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        ///  文字
        /// </summary>
        String,
        /// <summary>
        /// 下载链接
        /// </summary>
        Link
    }
}
