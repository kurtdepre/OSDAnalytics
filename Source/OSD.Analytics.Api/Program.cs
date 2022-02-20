using OSD.Analytics.Infrastructure.DBContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OSD.Analytics.Core.Repositories;
using OSD.Analytics.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "OSD Analytics WebApi",
            Description = "An Simple WebApi that will provider recording of OSD information in a DB, for later Analysis",
         //   TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Kurt Depre",
                Url = new Uri("https://github.com/kurtdepre/OSDAnalytics"),
                Email = "Info@kdesolutions.be"


            },
            License = new OpenApiLicense
            {
                Name = "Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International Public License",
                Url = new Uri("https://raw.githubusercontent.com/kurtdepre/OSDAnalytics/main/License.txt")
            },
            
        });
        options.EnableAnnotations();
    }



    );
builder.Services.AddDbContext<OSDAnalyticsDBContext>(options => options.UseSqlServer(builder.Configuration["DBConnection"]));
//builder.Services.AddDbContext<OSDAnalyticsDBContext>(options => options.UseInMemoryDatabase("OSDAnalytics"));
builder.Services.AddScoped<IOSDAnalyticsReadWriteRepository, OSDAnalyticsRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocumentTitle = "OSD Analytics Api Documentation";

    });
}

app.UseHttpsRedirection();
app.UseRouting();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

