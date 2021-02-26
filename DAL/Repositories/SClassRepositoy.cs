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
    public class SClassRepositoy : ISClassRepository
    {
        private readonly ApplicationDbContext _db;
        public SClassRepositoy(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<object> Delete(int id)
        {
            var sclass = await _db.SClasses.FindAsync(id);
            if (sclass != null)
            {
                _db.SClasses.Remove(sclass);
                await _db.SaveChangesAsync();
                return sclass;
            }
            return null;
        }

        public async Task<IEnumerable<SClass>> Get()
        {
            return await _db.SClasses.ToListAsync();

        }

        public async Task<SClass> Get(int id)
        {
            var sclass = await _db.SClasses.FindAsync(id);
            return sclass;
        }

        public async Task<object> Post(SClass entity)
        {
            if (_db.SClasses.Any(n => n.ClassName == entity.ClassName))
            {
                return null;
            }
            _db.SClasses.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<object> Put(SClass entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<object> Put(int id, SClass entity)
        {
            var sclass = _db.SClasses.Find(id);
            sclass.ClassName = entity.ClassName;
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
