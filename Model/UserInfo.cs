namespace Model
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// 1-教师 2-助教
        /// </summary>
        public int UserType { get; set; }

        public string TrueName { get; set; }
    }
}
