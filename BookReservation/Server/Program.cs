using BookReservation.Data;
using BookReservation.Server.Services.Abstract;
using BookReservation.Server.Services.Concrete;
using BookReservation.Server.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//--------------
builder.Services.ConfigureMapping();

builder.Services.ServiceIntegrationData();

builder.Services.AddScoped<IBookService, BookService>();
//--------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
