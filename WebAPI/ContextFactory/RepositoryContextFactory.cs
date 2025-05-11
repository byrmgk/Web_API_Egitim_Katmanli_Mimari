using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EfCore;

namespace WebAPI.ContextFactory
{
    //TODO: RepositoryContextFactory classına IDesignTimeDbContextFactory <RepositoryContext> interface'ini implement et
    //TODO: IDesignTimeDbContextFactory istediği için CreateDbContext metodunu override et
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        //TODO: CreateDbContext oluşturmamızı istiyor. 
        //TODO: Neden ???
        //TODO: Biz DbContext istiyor isek. 2 şeye ihityacımız var 1- Configuratin 2- DbContextOptions 
        public RepositoryContext CreateDbContext(string[] args)
        {
            //TODO: ConfigurationBuilder nesnesini alıyoruz.
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            //TODO: DbContextOptionsBuilder nesnesini alıyoruz.
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                prj =>prj.MigrationsAssembly("WebAPI"));
            //TODO:sqlConnection ifadesi appsettings.json dosyasındaki connection string'i alıyoruz.
            //TODO: prj => prj.MigrationsAssembly("WebApi") ifadesi ile migration'ları WebApi projesine yönlendiriyoruz.

            return new RepositoryContext(builder.Options);
        }
    }    
}
