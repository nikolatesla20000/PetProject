using Microsoft.EntityFrameworkCore;
using PetProject.Data;
using PetProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPetRepository, PetRepository>();
string petShopConnectionString = builder.Configuration["ConnectionStrings:PetShopConnection"]!;
builder.Services.AddDbContext<PetContext>(options => options.UseSqlServer(petShopConnectionString));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseRouting();
app.UseStaticFiles();
app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
