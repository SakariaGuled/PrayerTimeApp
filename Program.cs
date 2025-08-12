using Microsoft.AspNetCore.Mvc;
using PrayerTimeApp;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);



// Register named HttpClient with default settings
builder.Services.AddHttpClient("PrayerTimeApi", client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
});

// Register ApiHelper so it can be injected
builder.Services.AddScoped<ApiHelper>();
builder.Services.AddScoped<PrayerTimesService>();

var app = builder.Build();
app.MapGet("/", async ([FromServices]PrayerTimesService prayerTimeService) =>
{
    
    var data = await prayerTimeService.GetPrayerTimesAsync();
    return Results.Content(data, "application/json");
    
});


app.Run();
