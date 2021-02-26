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
    public class NoticeRepositoy : INoticeRepository
    {
        private readonly ApplicationDbContext _db;
        public NoticeRepositoy(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<object> Delete(int id)
        {
            var notice = await _db.Notices.FindAsync(id);
            if (notice != null)
            {
                _db.Notices.Remove(notice);
                await _db.SaveChangesAsync();
                return notice;
            }
            return null;
        }

        public async Task<IEnumerable<Notice>> Get()
        {
            return await _db.Notices.ToListAsync();

        }

        public async Task<Notice> Get(int id)
        {
            var notice = await _db.Notices.FindAsync(id);
            return notice;
        }

        public async Task<object> Post(Notice entity)
        {
            if (_db.Notices.Any(n => n.Title == entity.Title))
            {
                return null;
            }
            _db.Notices.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Notice entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<object> Put(int id, Notice entity)
        {
            var notice = _db.Notices.Find(id);
            notice.Title = entity.Title;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
