using Entities;
using Microsoft.EntityFrameworkCore;

using Repositories.Dbcontexts;
namespace RestaurantApi.Extensions;

public static class ServerExtension
{
    public static void ConfigureDatabase(this IServiceCollection services,IConfiguration config){
        services.AddDbContext<RepositoryDbContext>(options=>{
            options.UseSqlite(config.GetConnectionString("SqliteConnectionString"),
            prj=>prj.MigrationsAssembly("RestaurantApi"));
        });
    }
}