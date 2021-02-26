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
    public class SectionRepositoy : ISectionRepository
    {
        private readonly ApplicationDbContext _db;

        public SectionRepositoy(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<object> Delete(int id)
        {
            var section = await _db.Sections.FindAsync(id);
            if (section != null)
            {
                _db.Sections.Remove(section);
                await _db.SaveChangesAsync();
                return section;
            }
            return null;
        }

        public async Task<IEnumerable<Section>> Get()
        {
            return await _db.Sections.ToListAsync();

        }

        public async Task<Section> Get(int id)
        {
            var section = await _db.Sections.FindAsync(id);
            return section;
        }

        public async Task<object> Post(Section entity)
        {
            if (_db.Sections.Any(s => s.SectionName == entity.SectionName))
            {
                return null;
            }
            _db.Sections.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Section entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Section entity)
        {
            var section = _db.Sections.Find(id);
            section.SectionName = entity.SectionName;       
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
