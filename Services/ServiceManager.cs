using AutoMapper;
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
    public class ServiceManager : IServiceManager
    {
        //TODO:IRepositoryManger  kullanarak repositoryManger üzerinden tüm Repository ve save meoduna erişim sağlayacağız.

        private readonly Lazy<IBookService>  _bookService;
        public ServiceManager(IRepositoryManger repositoryManger, ILoggerService logger, IMapper mapper)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManger, logger, mapper));
        }
        //TODO: İhtiyaç olduğunda new lenecek şekilde Lazy<T> kullanıyoruz.
        public IBookService BookService => _bookService.Value;
    }
}
