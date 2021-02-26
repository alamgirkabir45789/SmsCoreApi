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
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext _db;

        public BranchRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<object> Delete(int id)
        {
            var branch = await _db.Branches.FindAsync(id);
            if (branch != null)
            {
                _db.Branches.Remove(branch);
                await _db.SaveChangesAsync();
            }
            return branch;
        }

        public async Task<IEnumerable<Branch>> Get()
        {
            return await _db.Branches.ToListAsync();
        }

        public async Task<Branch> Get(int id)
        {
            var branch = await _db.Branches.FindAsync(id);
            return branch;
        }

        public async Task<object> Post(Branch entity)
        {
            _db.Branches.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Branch entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Branch entity)
        {
            var branch = _db.Branches.Find(id);
            branch.BranchName = entity.BranchName;
            branch.StreetAddress = entity.StreetAddress;
            branch.PostalCode = entity.PostalCode;
            branch.City = entity.City;
            branch.Country = entity.Country;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
