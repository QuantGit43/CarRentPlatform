namespace CarRentPlatform.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Type {  get; set; }

        //navigation
        public ICollection<Car> Cars { get; set; }
        public ICollection<Rent> Rents { get; set; }
        public ICollection<Payment> Payments{ get; set; }
    }
}
