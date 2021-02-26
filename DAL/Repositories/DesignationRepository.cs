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
    public class DesignationRepository : IDesignationRepository
    {
        private readonly ApplicationDbContext _db;

        public DesignationRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<object> Delete(int id)
        {
            var designation = await _db.Designations.FindAsync(id);
            if (designation != null)
            {
                _db.Designations.Remove(designation);
                await _db.SaveChangesAsync();
                return designation;
            }
            return null;
        }

        public async Task<IEnumerable<Designation>> Get()
        {
            return await _db.Designations.ToListAsync();

        }

        public async Task<Designation> Get(int id)
        {
            var designation = await _db.Designations.FindAsync(id);
            return designation;
        }

        public async Task<object> Post(Designation entity)
        {
            if (_db.Designations.Any(c => c.DesignationName == entity.DesignationName))
            {
                return null;
            }
            _db.Designations.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Designation entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Designation entity)
        {
            var designation = _db.Designations.Find(id);
            designation.DesignationName = entity.DesignationName;
            designation.MinSalary = entity.MinSalary;
            designation.MaxSalary = entity.MaxSalary;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
