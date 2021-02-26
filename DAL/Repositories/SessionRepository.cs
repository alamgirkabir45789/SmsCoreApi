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
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _db;

        public SessionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<object> Delete(int id)
        {
            var session = await _db.Sessions.FindAsync(id);
            if (session != null)
            {
                _db.Sessions.Remove(session);
                await _db.SaveChangesAsync();
                return session;
            }
            return null;
        }

        public async Task<IEnumerable<Session>> Get()
        {
            return await _db.Sessions.ToListAsync();
        }

        public async Task<Session> Get(int id)
        {
            var session = await _db.Sessions.FindAsync(id);
            return session;
        }

        public async Task<object> Post(Session entity)
        {
            if (_db.Sessions.Any(c => c.SessionYear == entity.SessionYear))
            {
                return null;
            }
            _db.Sessions.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Session entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Session entity)
        {
            var session = _db.Sessions.Find(id);
            session.SessionYear = entity.SessionYear;
            session.StartDate = entity.StartDate; 
            session.EndDate = entity.EndDate;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
