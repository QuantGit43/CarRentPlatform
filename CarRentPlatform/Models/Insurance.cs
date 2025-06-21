namespace CarRentPlatform.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Type { get; set; } // 
        public DateTime ValidityPeriod { get; set; } // 
        public string? Company { get; set; } // 

        // Зв'язок з авто
        public int CarId { get; set; } // 
        public Car? Car { get; set; } // 
    }
}