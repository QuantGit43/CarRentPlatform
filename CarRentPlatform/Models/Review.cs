namespace CarRentPlatform.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public User? sender { get; set; }
        public User? receiver { get; set; }

        //Sender
        public Guid? SenderId { get; set; }
        public User? Sender { get; set; }

        //Receiver
        public Guid? ReceiverId {  get; set; }
        public User? Receiver { get; set; }
    }
}
