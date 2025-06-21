namespace CarRentPlatform.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; } // 
        public string? Email { get; set; } // 
        public string? Type { get; set; } // 
        public double Rating { get; set; } // 
        public string? DriverLicense { get; set; } // 

        // Навігаційні властивості для зв'язків
        public ICollection<Car> Cars { get; set; } = new List<Car>(); // Авто, що належать користувачу
        public ICollection<Rent> Rents { get; set; } = new List<Rent>(); // Оренди, оформлені користувачем
        public ICollection<Payment> Payments { get; set; } = new List<Payment>(); // Платежі користувача
    }
}