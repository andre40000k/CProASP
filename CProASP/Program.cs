using CProASP.Filter;
using CProASP.Interfaces.BaseInterfaces;
using CProASP.Interfaces.RepositoryInterface;
using CProASP.Interfaces.ServicesInterface;
using CProASP.MiniDateBase.EFCore;
using CProASP.Repository;
using CProASP.Services.RegisterObjects;
using CProASP.Services.RegisterObjects.ChangObjects;
using CProASP.Transport.Transport;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

namespace CProASP
{
    public class Program 
    {
        public static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(System.IO.Path.Combine(
                    Directory.GetCurrentDirectory(), "logs", "diagnostics.txt"),
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 10 * 1024 * 1024,
                    retainedFileCountLimit: 2,
                    rollOnFileSizeLimit: true,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1))
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();

            builder
                .Configuration
                .AddUserSecrets<ApplicationContext>()                
                .Build();

            

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                var conectionString = builder
                .Configuration
                .GetConnectionString("CProASP");

                options.UseSqlServer(conectionString);                
            });

            builder.Services.AddControllers(
            //    x =>
            //{
            //    x.Filters.Add(typeof(LogFilterAttribute));
            //}
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // new 

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {  Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                    },
                  new string[] { }
                }
               });
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    var secret = builder.Configuration.GetValue<string>("Auth:Secret")!;
                    var issuer = builder.Configuration.GetValue<string>("Auth:Issuer")!;
                    var audience = builder.Configuration.GetValue<string>("Auth:Audience")!;
                    var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = mySecurityKey
                    };
                });

            builder.Services.AddAuthorization();

            // new

            builder.Services.AddTransient<ITransportService, TransportService>();
            builder.Services.AddTransient<ITransportRepository, DataBaseTransportRepository>();
            //builder.Services.AddSingleton<ITransportAdd, TransportAdd>();
            //builder.Services.AddSingleton<ITransportGet, TransportGet>();
            //builder.Services.AddTransient<ITransportChang, TransportChang>();


            var app = builder.Build();

          
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // new
            app.UseAuthentication();
            // new

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
                    var service = requstDelegate.RequestServices.GetService<ITransportService>();
                    var transport = service.GetTranspoert(id);
                    if (transport == null) return Results.BadRequest("No content");
                    return Results.Ok(transport);

                })
                .WithName("Test")
                .WithOpenApi();

            app.MapPost("/v3/AddTransport/{baseTransport}",
               (HttpContext requstDelegate, BaseTransport baseTransport) =>
               {
                   var service = requstDelegate.RequestServices.GetService<ITransportService>();
                   service.AddTransport(baseTransport);
                   return Results.Ok();
               })
               .WithName("Test1")
               .WithOpenApi();

            app.Run();

        }
    }
}