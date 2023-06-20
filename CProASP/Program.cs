using CProASP.Interfaces.ServicesInterface;
using CProASP.Services.RegisterObjects;
using CProASP.Services.RegisterObjects.ChangObjects;

namespace CProASP
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


            builder.Services.AddSingleton<ITransportRegister, TransportRegister>();
            //builder.Services.AddSingleton<ITransportAdd, TransportAdd>();
            //builder.Services.AddSingleton<ITransportGet, TransportGet>();
            builder.Services.AddTransient<ITransportChang, TransportChang>();


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