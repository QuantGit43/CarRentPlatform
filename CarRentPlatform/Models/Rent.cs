namespace CarRentPlatform.Models
{
    public class Rent
    {
        public Guid Id  { get; set; }
        public Car? Car { get; set; }
        public User? User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public decimal Price { get; set; }
        public string? Status { get; set; }
    }
}
