using Common;

namespace Model
{
    public class OnlineListResult
    {
        public string username { get; set; }
        public string nickname { get; set; }
        public ClientStyle clientStyle { get; set; }
        public ClientRole clientRole { get; set; }

        public int no { get; set; }

        public bool IsCalled { get; set; }

        

       
    }
}
