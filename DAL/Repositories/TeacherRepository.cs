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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _db;

        public TeacherRepository(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task<object> Delete(int id)
        {
            var techer = await _db.Teachers.FindAsync(id);
            if (techer != null)
            {
                _db.Teachers.Remove(techer);
                await _db.SaveChangesAsync();
                return techer;
            }
            return null;
        }

        public async Task<IEnumerable<Teacher>> Get()
        {
            return await _db.Teachers.ToListAsync();
        }

        public async Task<Teacher> Get(int id)
        {
            var teacher = await _db.Teachers.FindAsync(id);
            return teacher;
        }

        public async Task<object> Post(Teacher entity)
        {
            _db.Teachers.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }


        public async Task<object> Put(Teacher entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Teacher entity)
        {
            var teacher = await _db.Teachers.FindAsync(id);
            teacher.EmployeeID = entity.EmployeeID;
            teacher.SubjectID = entity.SubjectID;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
