using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Models;

namespace CarRentPlatform.Repositories
{
    public class UsersRepository
    {
        private readonly CarRentDBContext _dbContext;

        public UsersRepository(CarRentDBContext dbContext )
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<User>> Get()
        {
            return await _dbContext.Users
                .AsNoTracking()
                .OrderBy(u => u.Id)
                .ToListAsync();
        }

        public async Task <User?> GetById(int Id)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == Id);  
        }

        public async Task<List<User>> GetByFilter(string? name, string email, double rating, string? Type)
        {
            var query = _dbContext.Users.AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(u => u.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(u => u.Email.Contains(email));
            }

            if (rating > 0)
            {
                query = query.Where(u => u.Rating >= rating);
            }
            if (!string.IsNullOrEmpty(Type))
            {
                query = query.Where(u => u.Type == Type);
            }
            return await query.ToListAsync();
           
        }

        public async Task<List<User>> GetByPage(int page, int pageSize)
        {
            return await _dbContext.Users
                    .AsNoTracking()
                    .OrderBy(c => c.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
        }

        public async Task Add(int id, string name, string email, double rating, string type, string driversLicense)
        {
            var newUser = new User
            {
                Id = id,
                Name = name,
                Email = email,
                Rating = rating,
                Type = type,
                DriverLicense = driversLicense
            };
                await _dbContext.Users.AddAsync(newUser);
                await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, string model, int year, string bodyType, string fuelType, 
            string? photo, string number, string status)
        {
            await _dbContext.Cars
                .Where(c=> c.Id == id)
                .ExecuteUpdateAsync(c =>
                 c.SetProperty(c => c.Model, model).
                 SetProperty (c=> c.ProdYear, year).
                 SetProperty(c=> c.BodyType, bodyType).
                 SetProperty(c => c.FuelType, fuelType).
                 SetProperty(c => c.Photo, photo).
                 SetProperty(c => c.Number, number).
                 SetProperty(c=> c.Status, status));
        }

        public async Task Delete(int id)
        {
            await _dbContext.Users.
                Where(u => u.Id == id).
                ExecuteDeleteAsync();
        }

    }
}
