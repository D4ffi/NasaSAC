using NasaSpaceAppChallenge.Models;
using NasaSpaceAppChallenge.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<NeoApi>(builder.Configuration.GetSection("NeoApi"));
builder.Services.AddHttpClient<INeoRequest, NeoRequest>(client =>
{
    var config = builder.Configuration.GetSection("NeoApi").Get<NeoApi>();
    if (config != null)
    {
        client.BaseAddress = new Uri(config.BaseUrl);
    }
} );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();