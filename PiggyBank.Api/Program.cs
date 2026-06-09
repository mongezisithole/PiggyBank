using PiggyBank.Core.Extensions;
using PiggyBank.Data.Extensions;
using System.Reflection;

namespace PiggyBank.Api
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
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddDataRepositories(builder.Configuration);
            builder.Services.AddCoreServices();

            

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigins",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:8080") 
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowOrigins");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
