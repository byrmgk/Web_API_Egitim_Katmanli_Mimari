using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Config
{
    //TODO:IEntityTypeConfiguration dan kalıtım alıyoruz. Generic yapıda Book sınıfını alıyoruz.
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //TODO: Migrasyon işlemlerinde tabloda da veri yoksa çekirdek veriler ekleyeceğiz.
            //TODO: WebAPI projemizdeki var olan Repositories/Config/BookConfig class'ını  buraya taşıyalım. !!! !!! !!!
            builder.HasData(
                new Book { Id = 1, Title = "Karagöz ve Hacivat", Price = 75 },
                new Book { Id = 2, Title = "Mesnevi", Price = 175 },
                new Book { Id = 3, Title = "Devlet", Price = 375 }
            );
        }
    }
}
