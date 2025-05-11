using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EfCore.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    //TODO: internal erişim belirleyicini public olarak değiştirin.
    //TODO: WebAPI projemizdeki var olan Repositories/RepositoryContext class'ını  buraya taşıyalım.
    //TODO: Sonra WebAPI projemizdeki var olan Repositories/RepositoryContext class'ın silelim.
    public class RepositoryContext : DbContext
    {
        //TODO: DbContextOptions nesnesi verdiğimizde base(options) ile DbContext göndermiş oluyoruz.
        //TODO:Install-Package Microsoft.EntityFrameworkCore -Version 6.0.10 -ProjectName Repositores !!!  (Package Manage Console dan indir)
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        //TODO: Dependencies Add Project Reference/Entities projesini ekle. 
        public DbSet<Book> Books { get; set; }

        //TODO: Tip konfigürasyonunu için ilgili kodu ekleyin.
        //TODO: Artık Model oluşturulurken BookConfig sınıfını kullanacağız.
        //TODO:Efcore/Config klasörünü oluştur.
        //TODO: Altına BookConfig.cs dosyasını oluşturun.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}

