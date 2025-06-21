namespace CarRentPlatform.Models
{
    public class Review
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }

        // Відправник відгуку
        public int SenderId { get; set; }
        public User Sender { get; set; }

        // Отримувач відгуку
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
    }
}