using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Models;

namespace CarRentPlatform.Repositories
{
    public class CarsRepository
    {
        private readonly CarRentDBContext _dbContext;

        public CarsRepository(CarRentDBContext dbContext )
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<Car>> Get()
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .OrderBy(c => c.ProdYear)
                .ToListAsync();
        }

        public async Task <Car?> GetById(int Id)
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);  
        }

        public async Task<List<Car>> GetByFilter(string? model, int? yearFrom, int? yearTo)
        {
            var query = _dbContext.Cars.AsNoTracking();
            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(c => c.Model.Contains(model));
            }
            if (yearFrom.HasValue)
            {
                query = query.Where(c => c.ProdYear >= yearFrom.Value);
            }
            if (yearTo.HasValue)
            {
                query = query.Where(c => c.ProdYear <= yearTo.Value);
            }
            return await query.OrderBy(c => c.ProdYear).ToListAsync();
        }

        public async Task<List<Car>> GetByPage(int page, int pageSize)
        {
            return await _dbContext.Cars
                    .AsNoTracking()
                    .OrderBy(c => c.ProdYear)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
        }

        public async Task Add(int id, string model, int year, string bodyType, string fuelType, 
            string? photo, string number, string status)
        {
            var newCar = new Car
            {
                Id = id,
                Model = model,
                ProdYear = year,
                BodyType = bodyType,
                FuelType = fuelType,
                Photo = photo,
                Number = number,
                Status = status,
            };
                await _dbContext.Cars.AddAsync(newCar);
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
            await _dbContext.Cars.
                Where(c => c.Id == id).
                ExecuteDeleteAsync();
        }

    }
}
