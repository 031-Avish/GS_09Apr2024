using DoctorAppointmentApp.Contexts;
using DoctorAppointmentApp.Interfaces;
using DoctorAppointmentApp.Models;
using DoctorAppointmentApp.Repositories;
using DoctorAppointmentApp.Services;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DoctorAppointmentContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")
                ));

            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();

            builder.Services.AddScoped<IDoctorService, DoctorBasicServices>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
