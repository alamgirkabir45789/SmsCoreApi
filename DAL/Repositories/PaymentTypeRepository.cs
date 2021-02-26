using SmsCoreApi.DAL.Interfaces;
using SmsCoreApi.Data;
using SmsCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SmsCoreApi.DAL.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {

        private readonly ApplicationDbContext _db;

        public PaymentTypeRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<object> Delete(int id)
        {
            var paymentType = await _db.PaymentTypes.FindAsync(id);
            if (paymentType != null)
            {
                _db.PaymentTypes.Remove(paymentType);
                await _db.SaveChangesAsync();
                return paymentType;
            }
            return null;
        }

        public async Task<IEnumerable<PaymentType>> Get()
        {
            return await _db.PaymentTypes.ToListAsync();
        }

        public async Task<PaymentType> Get(int id)
        {
            var paymentType = await _db.PaymentTypes.FindAsync(id);
            return paymentType;
        }

        public async Task<object> Post(PaymentType entity)
        {
            if(_db.PaymentTypes.Any(c=>c.TypeName==entity.TypeName))
            {
                return null;
            }
            _db.PaymentTypes.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put( PaymentType entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id,PaymentType entity)
        {
            var paymentType = _db.PaymentTypes.Find(id);
            paymentType.TypeName = entity.TypeName;
            paymentType.Amount = entity.Amount;

            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
