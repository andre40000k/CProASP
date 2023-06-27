using CProASP.Interfaces.BaseInterfaces;
using CProASP.Interfaces.ServicesInterface;
using CProASP.Services.RegisterObjects;
using CProASP.Services.RegisterObjects.ChangObjects;
using CProASP.Transport;

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

            app.Use(async (contex, next) =>
            {
                try
                {
                    Console.WriteLine("Body of reqest: {0}", contex.Request.Body.ToString());
                    await next();
                    Console.WriteLine("Underlying conection: {0}", contex.Connection.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Message: {0}\n" +
                        "Date: {1}\n" +
                        "Stack: {2}",
                        ex.Message, ex.Data, ex.StackTrace);
                }
                
            });

            app.MapControllers();

            app.MapGet("/v2/Transport/{id}",
                (HttpContext requstDelegate, int id) =>
                {
                    throw new NotImplementedException();
                    var check = int.TryParse(requstDelegate.GetRouteValue("id")!.ToString(), out id);
                    if (check == false) return Results.BadRequest("Only numbers!!!");
                    var service = requstDelegate.RequestServices.GetService<ITransportRegister>();
                    var transport = service.GetTranspoert(id);
                    if (transport == null) return Results.BadRequest("No content");
                    return Results.Ok(transport);

                })
                .WithName("Test")
                .WithOpenApi();

            app.MapPost("/v3/AddTransport/{baseTransport}",
               (HttpContext requstDelegate, BaseTransport baseTransport) =>
               {
                   var service = requstDelegate.RequestServices.GetService<ITransportRegister>();
                   service.AddTransport(baseTransport);
                   return Results.Ok();
               })
               .WithName("Test1")
               .WithOpenApi();

            app.Run();

        }
    }
}