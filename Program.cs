using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrayerTimeApp;
using PrayerTimeApp.Apidata;
using System.Net.Http.Headers;
using System.Text.Json;

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
builder.Services.AddScoped<Data>();
builder.Services.AddScoped<timings>();
builder.Services.AddScoped<Date>();

var app = builder.Build();
app.MapGet("/", async ([FromServices]PrayerTimesService prayerTimeService) =>
{
    
    var data = await prayerTimeService.GetPrayerTimesAsync();
    Console.WriteLine(data);
    var resultat = JsonConvert.DeserializeObject<ApiResponse>(data);

    Console.WriteLine(resultat.data.timings.Dhuhr);
    Console.WriteLine(resultat.data.Date.Readable);





});


app.Run();
