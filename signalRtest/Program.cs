using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using signalRtest.Hubs;
using signalRtest.Models;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:7014")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithMethods("GET", "POST")
        .SetIsOriginAllowed((host) => true)
        ;
    });
});
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();    
    endpoints.MapHub<MyHub>("/MyHub");
});
//app.MapControllers();

app.Run();
