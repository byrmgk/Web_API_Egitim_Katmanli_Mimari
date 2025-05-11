using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    //TODO:Burada IRepositoryBase<Book> referans alacağız.
    public interface IBookRepository : IRepositoryBase<Book>
    {
        //TODO: IRepositoryBase deki CRUD işlemlerininde başka bir işlem yapmayacağımızdan dolayı sade bırakıyoruz.     
        
        //TODO: Kitap oluşturmanın mantığı değişebilir düşüncesiyle burada bir metotlar tanımlıyoruz.
        //TODO: Ana interface'den koptuk.
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetOneBookByIdAsync(int id, bool trackChanges);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);



    }
}
