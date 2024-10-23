using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories;
using KoiFarmShop.Services;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Repositories.Repositories;
using KoiFarmShop.Services.InterfaceService;
using KoiFarmShop.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//DI
builder.Services.AddDbContext<KoiFarmShopDbContext>();
//DI repositories
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
//DI services
builder.Services.AddScoped<IRoleService, RoleService>();
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
