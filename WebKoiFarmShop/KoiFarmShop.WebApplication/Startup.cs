using KoiFarmShop.Repositories;
using KoiFarmShop.Repositories.Interface;
using KoiFarmShop.Services;
using KoiFarmShop.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Thêm các dịch vụ cần thiết
        services.AddScoped<INewsRepositories, NewsRepositories>();
        services.AddScoped<ICommentNewsRepositories, CommentNewsRepositories>();

        services.AddScoped<INewsServices, NewsServices>();
        services.AddScoped<ICommentNewsServices, CommentNewsServices>();

        services.AddControllers(); // Nếu bạn sử dụng API
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Cấu hình middleware nếu cần thiết (ví dụ xử lý lỗi)
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Map các controllers
        });
    }
}
