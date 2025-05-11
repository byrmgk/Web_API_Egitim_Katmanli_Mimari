using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    //TODO: internal erişim belirleyicini public olarak değiştirin.
    //TODO: Bu class IRepositoryBase<T> sınıfını implement edecek.
    //TODO: T generic bir type i,fadesi referans tipli bir ifadedir(where T : class).
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class //Ctrl + . ile IRepositoryBase deki tüm metotları implement edeceğiz.
    {
        //TODO: Veri işlemleri için repository contextini ihtiyacımız var.
        //TODO: base bir class olduğu için classı abstract yapıyoruz. Abstract olması demek RepositoryBase'in newlenemeyeceği anlamına gelir. Diğer repolar bunu kalıtım alacaklar. İhtiyacı olan diğer metorlarıda tanımlayabilecekler.
        //TODO: RepositoryBase classı abstract olduğu için diğer sınıfların _context'i kullanabilmesi için protected erişim belirleyicisi ile tanımlıyoruz. Bu sayede sadece bu classı kalıtım alan sınıflar erişebilir.
        protected readonly RepositoryContext _context;
        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        public void Create(T entity) => _context.Set<T>().Add(entity); //TODO: _context'i kullanarak entity'i ekliyoruz. Set<T>() metodu ile T tipinde bir DbSet alıyoruz. Add metodu ile entity'i ekliyoruz. Burada SaveChanges metodu çağrılmadığı için değişiklikler kaydedilmiyor. Bu metot sadece ekleme işlemi yapıyor. SaveChanges metodu eksik kalıyor. Onuda Maneger üzerinden kullanacağız.
        public void Delete(T entity) => _context.Set<T>().Remove(entity); //TODO: _context'i kullanarak entity'i siliyoruz. Set<T>() metodu ile T tipinde bir DbSet alıyoruz. 
        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? 
            _context.Set<T>().AsNoTracking() :
            _context.Set<T>(); //TODO: trackChanges parametresi ile değişiklikleri izleyip izlemeyeceğini belirliyoruz. Eğer trackChanges true ise AsNoTracking() metodu ile değişiklikleri izlemiyoruz. Eğer false ise değişiklikleri izliyoruz. Set<T>() metodu ile T tipinde bir DbSet alıyoruz.
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => 
            !trackChanges ?
            _context.Set<T>().Where(expression).AsNoTracking() :
            _context.Set<T>().Where(expression); //TODO: Koşullu sorgulabilir bir liste döndürüyoruz. Expression<Func<T, bool>> expression parametresi ile koşul belirliyoruz. Set<T>() metodu ile T tipinde bir DbSet alıyoruz. Where metodu ile koşula göre filtreliyoruz. AsNoTracking() metodu ile değişiklikleri izlemiyoruz.
        public void Update(T entity) => _context.Set<T>().Update(entity); //TODO: _context'i kullanarak entity'i güncelliyoruz. Set<T>() metodu ile T tipinde bir DbSet alıyoruz.

        //TODO: Tüm CRUD işlemleri için base classı oluşturmuş olduk. 
    }
}
