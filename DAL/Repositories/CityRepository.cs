using Microsoft.EntityFrameworkCore;
using SmsCoreApi.DAL.Interfaces;
using SmsCoreApi.Data;
using SmsCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.DAL.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<object> Delete(int id)
        {
            var city = await _db.Cities.FindAsync(id);
            if (city != null)
            {
                _db.Cities.Remove(city);
                await _db.SaveChangesAsync();
                return city;
            }
            return null;
        }

        public async Task<IEnumerable<City>> Get()
        {
            return await _db.Cities.ToListAsync();

        }

        public async Task<City> Get(int id)
        {
            var city = await _db.Cities.FindAsync(id);
            return city;
        }

        public async Task<object> Post(City entity)
        {
            if (_db.Cities.Any(c => c.CityName == entity.CityName))
            {
                return null;
            }
            _db.Cities.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(City entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, City entity)
        {
            var city = _db.Cities.Find(id);
            city.CityName = entity.CityName;
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}

