using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories;
using KoiFarmShop.Services;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Repositories.Repositories;
using KoiFarmShop.Services.InterfaceService;
using KoiFarmShop.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//DI
builder.Services.AddDbContext<KoiFarmShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});
//DI repositories
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IKoiCateRepository, KoiCateRepository>();
builder.Services.AddScoped<IKoiRepository, KoiRepository>();
builder.Services.AddScoped<ICmtKoiRepository, CmtKoiRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICmtBlogRepository, CmtBlogRepository>();
builder.Services.AddScoped<INewRepository, NewsRepository>();
builder.Services.AddScoped<ICmtNewsRepository, CmtNewsRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
//DI services
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IKoiCateService, KoiCateService>();
builder.Services.AddScoped<IKoiService, KoiService>();
builder.Services.AddScoped<ICmtKoiService, CmtKoiService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICmtBlogService, CmtBlogService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<ICmtNewsService, CmtNewsService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();



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
