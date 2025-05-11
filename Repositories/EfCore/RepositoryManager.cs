using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    public class RepositoryManager : IRepositoryManger
    {
        private readonly RepositoryContext _context;
        
        //TODO: Lazy Loading için ekledik. 
        private readonly Lazy<IBookRepository> _bookRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
        }

        //TODO: Her bir repo yu IoC kaydını kaymak istemiyoruz
        //TODO: Sadece RepositoryManager ve IRepositoryManger Ioc ye ekleyeceğiz.
        //TODO: Bunun için diğer repoları burada new leyeceğiz. (İstisnai bir durum yapacağız.)

        //TODO: !!! Bir class altında başka bir class new lenmez. New lenirse sıkı bir bağlılık olur.
        //TODO: İsterseniz IBookRepository'i  BookRepository ve diğer Repository leri ek tek Ioc kayır edebiliriz.
        //TODO: Tüm Repository IoC yıkarsak AutoFac gibi bir uygulama ile yönetebiliriz. Ancak biz genelde microsfta yüklemek için böyle bir yol izliyoruz.


        //public IBookRepository Book => new BookRepository(_context);
        public IBookRepository Book => _bookRepository.Value; //Nesne ancak ve ancak kullanıldığında oluşturulacak. Lazy Loading yapmış olduk.

        //TODO: Book ifadesi artık BookRepository karşılık gelecek. 

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
