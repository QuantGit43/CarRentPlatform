using CarRentPlatform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Configurations
{
    public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder.HasKey(i => i.Id);

            // Зв'язок з автомобілем (Insurance -> Car)
            builder.HasOne(i => i.Car)
                   .WithMany(c => c.Insurances)
                   .HasForeignKey(i => i.CarId)
                   .OnDelete(DeleteBehavior.Cascade); // При видаленні авто, його страховки видаляються автоматично
        }
    }
}