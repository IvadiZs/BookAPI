
using BookAPI.Models;
using BookAPI.Repositories;
using BookAPI.Repositories.IEService;

namespace BookAPI {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BookdbContext>();
            builder.Services.AddScoped<NemzetisegInterface, NemzetisegService>();
            builder.Services.AddScoped<SzerzoInterface, SzerzoService>();
            builder.Services.AddScoped<KonyvInterface, KonyvService>();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEmailInterface, EmailService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
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