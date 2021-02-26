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
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _db;

        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<object> Delete(int id)
        {
            var country = await _db.Countries.FindAsync(id);
            if (country != null)
            {
                _db.Countries.Remove(country);
                await _db.SaveChangesAsync();
                return country;
            }
            return null; ;
        }

        public async Task<IEnumerable<Country>> Get()
        {
            return await _db.Countries.ToListAsync();
        }

        public async Task<Country> Get(int id)
        {
            var country = await _db.Countries.FindAsync(id);
            return country;
        }

        public async Task<object> Post(Country entity)
        {
            if (_db.Countries.Any(c => c.CountryName == entity.CountryName))
            {
                return null;
            }
            _db.Countries.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Country entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Country entity)
        {
            var country = _db.Countries.Find(id);
            country.CountryName = entity.CountryName;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
