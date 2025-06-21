namespace CarRentPlatform.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; } // 
        public DateTime FinishDate { get; set; } // 
        public decimal Price { get; set; } // 
        public string? Status { get; set; } // 

        // Зв'язки
        public int CarId { get; set; } // Зовнішній ключ 
        public Car Car { get; set; } // Навігаційна властивість 

        public int UserId { get; set; } // Зовнішній ключ 
        public User User { get; set; } // Навігаційна властивість 
    }
}