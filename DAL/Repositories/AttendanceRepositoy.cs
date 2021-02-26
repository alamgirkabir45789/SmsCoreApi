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
    public class AttendanceRepositoy : IAttendanceRepository
    {
        private readonly ApplicationDbContext _db;

        public AttendanceRepositoy(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<object> Delete(int id)
        {
            var attendance = await _db.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _db.Attendances.Remove(attendance);
                await _db.SaveChangesAsync();
                return attendance;
            }
            return null;
        }

        public async Task<IEnumerable<Attendance>> Get()
        {
            return await _db.Attendances.ToListAsync();

        }

        public async Task<Attendance> Get(int id)
        {
            var attendance = await _db.Attendances.FindAsync(id);
            return attendance;
        }

        public async Task<object> Post(Attendance entity)
        {
            if (_db.Attendances.Any(a => a.AttendDate == entity.AttendDate))
            {
                return null;
            }
            _db.Attendances.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Attendance entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Attendance entity)
        {
            var attendance = _db.Attendances.Find(id);
            attendance.AttendDate = entity.AttendDate;
            attendance.Status = entity.Status;
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
