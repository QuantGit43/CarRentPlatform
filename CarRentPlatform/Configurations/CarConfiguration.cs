using CarRentPlatform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            // Встановлюємо первинний ключ
            builder.HasKey(c => c.Id);

            // 1. Налаштовуємо зв'язок "один-до-багатьох" з таблицею Users
            // Тепер ми чітко вказуємо, що навігаційна властивість - це "Owner"
            builder.HasOne(car => car.Owner)
                   .WithMany(user => user.Cars)
                   .HasForeignKey(car => car.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict); // Забороняємо видаляти користувача, якщо у нього є авто

            // 2. Налаштовуємо зв'язок "один-до-багатьох" з таблицею Rents
            builder.HasMany(car => car.Rents)
                   .WithOne(rent => rent.Car)
                   .HasForeignKey(rent => rent.CarId)
                   .OnDelete(DeleteBehavior.Restrict); // Забороняємо видаляти авто, якщо є історія оренд

            // 3. Налаштовуємо зв'язок "один-до-багатьох" з таблицею Insurances
            builder.HasMany(car => car.Insurances)
                   .WithOne(insurance => insurance.Car)
                   .HasForeignKey(insurance => insurance.CarId)
                   .OnDelete(DeleteBehavior.Cascade); // Дозволяємо каскадне видалення страховок при видаленні авто
        }
    }
}