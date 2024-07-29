namespace Library_Management.Models
{
    public class Lend
    {
        public int Id { get; set; }
        public int Bid { get; set; }
        public int Sid { get; set; }
        public DateOnly Issue_date { get; set; }
        public DateOnly Return_date { get; set; }

        public string Status { get; set; }


    }
}
