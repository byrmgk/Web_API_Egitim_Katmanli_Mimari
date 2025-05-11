using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    //TODO:IRepositoryBase<T> için oluşturulan RepositoryBase<T> classını kalıtım aldık.
    //TODO:RepositoryBase<T> dışında yapılacak işlemler için IBookRepository interface'ini implement ettik.
    //TODO:C# da bir class birden fazla interface'i implement edebilir. Ama bir class sadece bir class'ı kalıtım alabilir. Bu yüzden RepositoryBase<T> classını kalıtım aldık.
    public class BookRepository : RepositoryBase<Book>, IBookRepository //Ctrl + .
    {
        //TODO:Constructor'da RepositoryContext'i istiyor. Bu RepositoryContext'i base gönderiyor. Bu base de RepositoryBase oluyor. RepositoryBase gittiğimizde _context'i kullanıyor.
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateBook(Book book) => Create(book); 

        public void DeleteBook(Book book) => Delete(book);

        public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(b => b.Id)
            .ToListAsync();
            

        public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges) =>
           await FindByCondition(x => x.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
            

        public void UpdateBook(Book book) => Update(book);
    }
}
