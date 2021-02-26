using Microsoft.EntityFrameworkCore;
using SmsCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Designation> Designations { get; set;}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmpJobHistory> EmpJobHistories { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ImageGallery> ImageGalleries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<SClass> SClasses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentRegistration>  StudentRegistrations { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }



            modelBuilder.Entity<City>().HasData(
                new City { CityID=1,CityName="Chittagong" },
                new City { CityID = 2, CityName = "Dhaka" },
                new City { CityID = 3, CityName = "Barishal" }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryID = 1, CountryName = "Bangladesh" },
                new Country { CountryID = 2, CountryName = "Pakistan" },
                new Country { CountryID = 3, CountryName = "Australia" }

            );
        }
    }
}
