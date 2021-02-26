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
    public class EventRepository:IEventRepository
    {
        private readonly ApplicationDbContext _db;

        public EventRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<object> Delete(int id)
        {
            var events = await _db.Events.FindAsync(id);
            if (events != null)
            {
                _db.Events.Remove(events);
                await _db.SaveChangesAsync();
                return events;
            }
            return null;
        }

        public async Task<IEnumerable<Event>> Get()
        {
            return await _db.Events.ToListAsync();

        }

        public async Task<Event> Get(int id)
        {
            var events = await _db.Events.FindAsync(id);
            return events;
        }

        public async Task<object> Post(Event entity)
        {
            if (_db.Events.Any(e => e.Title == entity.Title))
            {
                return null;
            }
            _db.Events.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Event entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Event entity)
        {
            var events = _db.Events.Find(id);
            events.Title = entity.Title;
            events.StartDate = entity.StartDate;
            events.EndDate = entity.EndDate;
            events.Color = entity.Color;
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
