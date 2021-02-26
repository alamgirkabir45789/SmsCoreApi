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
    public class PaymentRepository: IPaymentRepository
    {
        private readonly ApplicationDbContext _db;

        public PaymentRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<object> Delete(int id)
        {
            var payment = await _db.Payments.FindAsync(id);
            if (payment != null)
            {
                _db.Payments.Remove(payment);
                await _db.SaveChangesAsync();
                return payment;
            }
            return null;
        }

        public async Task<IEnumerable<Payment>> Get()
        {
            return await _db.Payments.ToListAsync();

        }

        public async Task<Payment> Get(int id)
        {
            var payment = await _db.Payments.FindAsync(id);
            return payment;
        }

        public async Task<object> Post(Payment entity)
        {
            if (_db.Payments.Any(e => e.PaymentID == entity.PaymentID))
            {
                return null;
            }
            _db.Payments.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Payment entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Payment entity)
        {
            var payment = _db.Payments.Find(id);
            payment.Total = entity.Total;
            payment.Paid = entity.Paid;
            payment.PaymentDate = entity.PaymentDate;
            payment.StudentRegistration = entity.StudentRegistration;
            payment.PaymentType = entity.PaymentType;
            payment.Students = entity.Students;
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}