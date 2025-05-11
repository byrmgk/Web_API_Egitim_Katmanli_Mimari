using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    public interface IRepositoryManger
    {
        //TODO: TÜm repolara Manager üzerinden erişim sağlayacağız.
        IBookRepository Book { get; }
        Task SaveAsync();
    }
}
