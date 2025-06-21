namespace CarRentPlatform.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; } // 
        public string? Type { get; set; } // 
        public DateTime PaymentDate { get; set; } // 

        // Зв'язок з користувачем, що здійснив платіж
        public int UserId { get; set; } // 
        public User? User { get; set; } // 
    }
}