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
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<object> Delete(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> Get(int id)
        {
            var student = await _db.Students.FindAsync(id);
            return student;
        }

        public async Task<object> Post(Student entity)
        {
            if (_db.Students.Any(c => c.Roll == entity.Roll))
            {
                return null;
            }
            _db.Students.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Student entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<object> Put(int id, Student entity)
        {
            var student = _db.Students.Find(id);
            student.StudentRegistrationID = entity.StudentRegistrationID;
            student.SessionID = entity.SessionID;
            student.SClassID = entity.SClassID;
            student.SectionID = entity.SectionID;
            student.PaymentID = entity.PaymentID;
            student.Roll = entity.Roll;
            
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
