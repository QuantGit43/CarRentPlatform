using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
           builder.HasKey(r => r.Id);

            builder.
                HasOne(r => r.User)
                .WithMany(c => c.Cars);
        }
    }
}
