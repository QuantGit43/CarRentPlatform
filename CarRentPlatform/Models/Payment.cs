namespace CarRentPlatform.Models
{
    public class Payment
    {
        public Guid Id { get; set; }  
        public decimal Amount { get; set; }
        public string? Type {  get; set; }
        
        //User
        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
