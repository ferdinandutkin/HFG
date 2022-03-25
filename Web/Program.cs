using System.Text.Json;
using HashCore;
using Web;
using System.Text.Json.Serialization;
using Web.AutoMapper;
using Web.Hubs;
using Web.Interfaces;
using Web.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR(e =>
{
    e.EnableDetailedErrors = true;

}).AddJsonProtocol(options =>
{
    options.PayloadSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.PayloadSerializerOptions.Converters
           .Add(new JsonStringEnumConverter());
});
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IHashStatsGenerator, HashStatsGenerator>();
builder.Services.AddScoped<IFunctionGeneratorFactory<int>, FunctionGeneratorFactory>();
builder.Services.AddScoped<IHashStatService, HashStatService>();

 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.MapControllers();
app.MapHub<GeneratorHub>("/generator");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
