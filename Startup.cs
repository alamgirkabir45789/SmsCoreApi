using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmsCoreApi.DAL.Interfaces;
using SmsCoreApi.DAL.Repositories;
using SmsCoreApi.Data;
using SmsCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbCon")));

            services.AddTransient<IRepository<City>, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IDesignationRepository, DesignationRepository>();
            services.AddTransient<INoticeRepository, NoticeRepositoy>();
            services.AddTransient<ISClassRepository, SClassRepositoy>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<IImageGalleryRepository, ImageGalleryRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepositoy>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<ISectionRepository, SectionRepositoy>();
            services.AddTransient<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepositoy>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
