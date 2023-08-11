using MeasurementsWebAPI.DataAccess;
using MeasurementsWebAPI.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using MeasurementsWebAPI.BusinessLogic.Models;
using MeasurementsWebAPI.BusinessLogic.Interfaces;
using MeasurementsWebAPI.BusinessManager;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace MeasurementsWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add logging

            // Add services to the container.
            builder.Services.AddDbContext<MeasurementsDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MeasurementsDBContext")));

            builder.Services.AddScoped<IAtmRepository,AtmRepository>();
            builder.Services.AddScoped<IAtmBusinessManager, AtmBusinessManager>();
            
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseCors(policy =>
                policy.WithOrigins("https://localhost:7006", "http://localhost:5216")
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType));

            app.UseHttpsRedirection();            

            app.UseRouting();

            app.UseAuthorization();

            app.MapGet("/", () => "Please Redirect to /api/v1/atm");

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}