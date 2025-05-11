using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    //TODO: T generic bir type parametresi alacak.
    public interface IRepositoryBase<T>
    {
        //TODO: CRUD işlemleri için gerekli olan metotları tanımlayın.
        //TODO: Sorgulanabilişr bir liste döndürecek.
        //TODO: trackChanges parametresi ile değişiklikleri izleyip izlemeyeceğini belirleyecek.
        IQueryable<T> FindAll(bool trackChanges);

        //TODO: Koşullu sorgulabilir bir liste döndürecek.
        //TODO: Expression<Func<T, bool> expression> parametresi ile koşul belirleyecek.
        //TODO: Func delegesi ile bir fonksiyon alacak.
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        //TODO: Create işlemi için bir metot tanımlayın.
        void Create(T entity);

        //TODO: Update işlemi için bir metot tanımlayın.
        void Update(T entity);

        //TODO: Delete işlemi için bir metot tanımlayın.
        void Delete(T entity);
    }
}
