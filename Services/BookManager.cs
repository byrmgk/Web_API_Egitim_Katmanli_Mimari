using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    public class BookManager : IBookService
    {
        //TODO: Manager ihtiyaç vardır.               
        private readonly IRepositoryManger _manger;

        //TODO: ILoggerService ihtiyaç vardır.
        private readonly ILoggerService _logger; //Ctrl + . yaparak ekleyin.

        private readonly IMapper _mapper; //TODO: Mapper ihtiyaç vardır.
        public BookManager(IRepositoryManger repository, ILoggerService logger, IMapper mapper)
        {
            _manger = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto)
        {
            var entity = _mapper.Map<Book>(bookDto); 

            _manger.Book.CreateBook(entity);
            await _manger.SaveAsync();

            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            //check entity
            var entity = await _manger.Book.GetOneBookByIdAsync(id, trackChanges);

            if (entity is null)                
                throw new BookNotFoundException(id);            

            _manger.Book.DeleteBook(entity);
            await _manger.SaveAsync();
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges)
        {
            //TODO: İlgili Map işlemi yapılacak.
            var book = await _manger.Book.GetAllBooksAsync(trackChanges);

            //TODO:Map leme ifadesi
            //TODO:IEnumerable<BookDto ihtiyaç duyulan alan
            //TODO:İşleme alınacak referans
            return _mapper.Map<IEnumerable<BookDto>>(book);
        }

        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book = await  _manger.Book.GetOneBookByIdAsync(id, trackChanges);
            if (book is null)            
                throw new BookNotFoundException(id);

            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateOneBookAsync(int id, BookDtoUpdate bookDto, bool trackChanges)
        {
            //check entity
            var entity =await _manger.Book.GetOneBookByIdAsync(id, trackChanges);  

            //check book null
            if (entity is null)
                throw new BookNotFoundException(id);

            //TODO: Burada Mapping işlemi var
            //TODO: Burada 10 tane alan olsa tek tek eşleyeceğiz. Bunun için Mapping işlemi yapacağız.
            //entity.Title = book.Title;
            //entity.Price = book.Price;

            entity = _mapper.Map<Book>(bookDto); //TODO: Bize <Book> lazım nihayi olarak bookDto kaynaklık edecek.

            _manger.Book.UpdateBook(entity);
            await _manger.SaveAsync();
        }

        public async Task<(BookDtoUpdate bookDtoUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges)
        {
          var book = await _manger.Book.GetOneBookByIdAsync(id, trackChanges);
            if (book is null)
                throw new BookNotFoundException(id);

            var bookDtoForUpdate = _mapper.Map<BookDtoUpdate>(book); //TODO: BookDtoUpdate ihtiyacı var.
            
            //TODO: Tuple yapısı ile döndürüyoruz.
            return (bookDtoForUpdate, book);
        }

        public async Task SaveChangesForPatchAsync(BookDtoUpdate bookDtoUpdate, Book book)
        {
            _mapper.Map(bookDtoUpdate, book); //TODO: BookDtoUpdate ile Book'u eşleştiriyoruz.
           await _manger.SaveAsync(); //TODO: Değişiklikleri kaydediyoruz.
        }
    }
}
