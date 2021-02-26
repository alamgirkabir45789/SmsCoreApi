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
    public class EmployeeRepositoy : IEmployeeRepository
    {

        private readonly ApplicationDbContext _db;

        public EmployeeRepositoy(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<object> Delete(int id)
        {
            var employee = await _db.Employees.FindAsync(id);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
                await _db.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<Employee> Get(int id)
        {
            var employee = await _db.Employees.FindAsync(id);
            return employee;
        }

        public async Task<object> Post(Employee entity)
        {
            if (_db.Employees.Any(c => c.EmployeeName == entity.EmployeeName)) 
            {
                return null;
            }
            _db.Employees.Add(entity);
            await _db.SaveChangesAsync();
            return entity;

        }

        public async Task<object> Put( Employee entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id,Employee entity)
        {
            var employee = _db.Employees.Find(id);
            employee.EmployeeName = entity.EmployeeName;
            employee.Gender = entity.Gender;
            employee.Email = entity.Email;
            employee.DateOfBirth = entity.DateOfBirth;
            employee.Religion = entity.Religion;
            employee.MaritalStatus = entity.MaritalStatus;
            employee.Phone = entity.Phone;
            employee.Address = entity.PostalCode;
            employee.City = entity.City;
            
            employee.Country = entity.Country;
            employee.Designation = entity.Designation;
            employee.Salary = entity.Salary;
            employee.EmployeeImage = entity.EmployeeImage;
            employee.NID = entity.NID;
            employee.Qualification = entity.Qualification;
            employee.Branch = entity.Branch;
            employee.HireDate = entity.HireDate;
            employee.IsActive = entity.IsActive;
                
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
