namespace CarRentPlatform.Models
{
    public class Insurance
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime ValidityPeriod { get; set; }
        public string? Company {  get; set; }

        //Car
        public Guid? CarId { get; set; }
        public Car? Car {  get; set; }
    }
}
