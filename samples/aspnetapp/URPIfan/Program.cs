using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using URPIfan.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<RaspiTemperatureController>();
builder.Services.AddSingleton<ITaskHelper, TaskHelper>();
builder.Services.AddSingleton<ITaskCancellationHelper, TaskCancellationHelper>();

ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<ITemperatureProvider, DevTemperatureProvider>();
    builder.Services.AddSingleton<IFanController, DevFanController>();
}
else
{
    builder.Services.AddSingleton<ITemperatureProvider, RaspiTemperatureProvider>();
    builder.Services.AddSingleton<IFanController, RaspiFanController>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
