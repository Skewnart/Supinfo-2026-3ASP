
using DAL;
using Microsoft.EntityFrameworkCore;

namespace SchoolAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //SchoolContext context = new SchoolContext(connectionString);
            //context.Database.EnsureCreated();

            builder.Services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.

            builder.Services.AddControllers();
            //(options =>
            //{
            //    options.Filters.Add<ValidateStudentFilter>();
            //});

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
