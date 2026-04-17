using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using System.Reflection;

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

            builder.Services.AddControllers();
            //(options =>
            //{
            //    options.Filters.Add<ValidateStudentFilter>();
            //});

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "School API",
                    Version = "v1",
                    Description = "API pour gérer les étudiants, enseignants et salles de classe.",
                    Contact = new OpenApiContact
                    { Name = "Corentin Z", Url = new Uri("https://www.corentinz.fr") },
                    License = new OpenApiLicense
                    { Name = "GNU v3", Url = new Uri("https://www.gnu.org/licenses/quick-guide-gplv3.pdf") }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                setup.IncludeXmlComments(xmlPath);
            });


            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins("http://localhost:8000")
                        .WithMethods("GET");
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors();
            app.MapControllers();
            app.Run();
        }
    }
}
