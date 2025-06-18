namespace CarRentPlatform.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string? Mark {  get; set; }
        public string? Model { get; set; }
        public int ProdYear { get; set; }
        public string? BodyType { get; set; }
        public string? FuelType { get; set; }
        public string? Number { get; set; }
        public User? User { get; set; }
        public string? Photo { get; set; }
        public string? Status { get; set; }

        //Car_User
        public Guid OwnerId { get; set; }
        public User? Owner { get; set; }

        //navigation
        public ICollection<Rent> Rents { get; set; }
        public ICollection<Insurance> Insurances { get; set; }


    }
}
