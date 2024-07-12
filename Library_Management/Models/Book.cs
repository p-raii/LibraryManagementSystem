namespace Library_Management.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public bool Avability  { get; set; }
        public string BookPhoto { get; set; }
    }
}
