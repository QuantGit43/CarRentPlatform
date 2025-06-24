using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Models;

namespace CarRentPlatform.Repositories
{
    public class CarsRepository
    {
        private readonly CarRentDBContext _dbContext;

        public CarsRepository(CarRentDBContext dbContext )
        {
            dbContext = _dbContext;
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

        public async Task<List<Car>> GetByFilter(string? brand, string? model, int? yearFrom, int? yearTo)
        {
            var query = _dbContext.Cars.AsNoTracking();
            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(c => c.Mark.Contains(brand));
            }
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

        public async Task<Car> Add(Car car)
        {

            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync();
            return car;
        }

        //public async Task<Car?> Update(Car car)
        //{
        //    _dbContext.Cars.Update(car);
        //}
    }
}
