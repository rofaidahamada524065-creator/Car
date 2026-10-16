
using Car.Data;
using Car.Mapping;
using Car.Repos.Impelementation;
using Car.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Car
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
            builder.Services.AddDbContext<AppDbcontext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
            builder.Services.AddAutoMapper(typeof(AllProfail));
            builder.Services.AddScoped(typeof(IGenaricRepo<>), typeof(GenaricRepo<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IVehicleCustom, VehicleCustom>();
            builder.Services.AddScoped<ICatigoryCustom, CatigoryCustom>();
            builder.Services.AddScoped<ICustomerRepo, CustomerCustom>();
            builder.Services.AddScoped<IEmpeloyyCustom, EmpeloyyCustom>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
