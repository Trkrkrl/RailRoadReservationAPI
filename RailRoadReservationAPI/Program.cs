using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RailwayReservation.Business.DependencyResolver.Autofac;
using RailwayReservation.Core.DependecyResolvers;
using RailwayReservation.Core.Extensions;
using RailwayReservation.Core.Utilities.IoC;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });
//----




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RailRoadReservationAPI", Version = "v1.0" });
});

builder.Services.AddDependencyResolvers(new ICoreModule[]//servicecollectionextension istiyor
          {
                new CoreModule()

          }
          );

// DiKKAT Buradan sonra build li kod bulunamaz
var app = builder.Build();



// Configure the HTTP request pipeline.



app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
