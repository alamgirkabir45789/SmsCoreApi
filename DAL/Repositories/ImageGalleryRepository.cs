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
    public class ImageGalleryRepository : IImageGalleryRepository
    {
        private readonly ApplicationDbContext _db;

        public ImageGalleryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<object> Delete(int id)
        {
            var imageGallery = await _db.ImageGalleries.FindAsync(id);
            if (imageGallery != null)
            {
                _db.ImageGalleries.Remove(imageGallery);
                await _db.SaveChangesAsync();
                return imageGallery;
            }
            return null; ;
        }

        public async Task<IEnumerable<ImageGallery>> Get()
        {
            return await _db.ImageGalleries.ToListAsync();
        }

        public async Task<ImageGallery> Get(int id)
        {
            var imageGallery = await _db.ImageGalleries.FindAsync(id);
            return imageGallery;
        }

        public async Task<object> Post(ImageGallery entity)
        {
            if (_db.ImageGalleries.Any(c => c.Title == entity.Title))
            {
                return null;
            }
            _db.ImageGalleries.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(ImageGallery entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<object> Put(int id, ImageGallery entity)
        {
            var imageGallery = _db.ImageGalleries.Find(id);
            imageGallery.Title = entity.Title;
            imageGallery.ImageFile = entity.ImageFile;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
