namespace Model
{
    public class SendMessage<T> where T : class, new()
    {
        // public int Length { get; set; }
        //  public string TimeStamp { get; set; }

        public T Data { get; set; }

        public int Action { get; set; }
    }

    public class ReceieveMessage
    {
        public int Length { get; set; }
        public string TimeStamp { get; set; }

        public string DataStr { get; set; }

        public int Action { get; set; }
    }
}
