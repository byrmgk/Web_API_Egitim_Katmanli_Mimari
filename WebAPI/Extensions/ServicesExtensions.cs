using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore;
using Services;
using Services.Contracts;

namespace WebAPI.Extensions
{
    public static class ServicesExtensions
    {
        //TODO: IServiceCollection services genişletmek için extension method
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO: Veri Tabnı işlemi için AddDbContext eklenir. Buna da ilgili context sınıfı verilir.
            //TODO: RepositoryContext sınıfını kullanarak DbContext'i ekleyin.
            //TODO: Microsoft.EntityFrameworkCore.SqlServer NuGet paketini yükleyin.
            //TODO: SqlServer için gerekli olan bağlantı dizesini appsettings.json a ekledik.
            //TODO: IOC ye DBContext tanımını yapmış oluyoruz. (Bir DBContexte ihtiyacımız olduğunda bunun somut haline ulaşmamız için)

            //TODO: Program.cs dosyasında ctrl +x ile aldık.

            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        //TODO: Hata aldık onun için yeni servis ekledik.
        public static void ConfigureRepositoryManeger(this IServiceCollection services) => services.AddScoped<IRepositoryManger, RepositoryManager>();

        //TODO: Servis Manageri kullanabilmemiz için ekliyoruz.
        //TODO: IServiceManager karşılık IServiceManager olmuş.
        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();

        //TODO: Loger i kullanabilmemiz için ekliyoruz.
        //TODO :AddSingleton yapıyoruz çünkü loger bir defa oluşturulacak ve her yerde kullanılacak.
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerService, LoggerManager>();
    }
}
