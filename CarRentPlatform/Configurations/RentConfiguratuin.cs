using CarRentPlatform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Configurations
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public override void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(r => r.Id);

            // Встановлюємо тип даних для грошової одиниці в базі даних
            builder.Property(r => r.Price).HasColumnType("decimal(18, 2)");

            // Зв'язок з автомобілем (Rent -> Car)
            builder.HasOne(r => r.Car)
                   .WithMany(c => c.Rents)
                   .HasForeignKey(r => r.Car.Id)
                   .OnDelete(DeleteBehavior.Restrict); // Забороняємо видаляти авто, якщо є історія оренд

            // Зв'язок з користувачем (Rent -> User) вже налаштовано у UserConfiguration,
            // але для повноти його можна залишити і тут. EF Core обробить це коректно.
        }
    }
}