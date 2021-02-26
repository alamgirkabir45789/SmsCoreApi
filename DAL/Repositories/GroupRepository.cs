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
    public class GroupRepository:IGroupRepository
    {
        private readonly ApplicationDbContext _db;

        public GroupRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<object> Delete(int id)
        {
            var group = await _db.Groups.FindAsync(id);
            if (group != null)
            {
                _db.Groups.Remove(group);
                await _db.SaveChangesAsync();
                return group;
            }
            return null;
        }

        public async Task<IEnumerable<Group>> Get()
        {
            return await _db.Groups.ToListAsync();

        }

        public async Task<Group> Get(int id)
        {
            var group = await _db.Groups.FindAsync(id);
            return group;
        }


        public async Task<object> Post(Group entity)
        {
            if (_db.Groups.Any(c => c.GroupName == entity.GroupName))
            {
                return null;
            }
            _db.Groups.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Group entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Group entity)
        {
            var group = _db.Groups.Find(id);
            group.GroupName = entity.GroupName;
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}

