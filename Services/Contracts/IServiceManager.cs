using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    public interface IServiceManager
    {
        //TODO: Projmizde kullanacağımız servisleri burada tanımlayacağız. Servisleri tek bir manager ile yöneteceğiz.
        //TODO: Tüm servisleri burada tanımlayacağız.
        IBookService BookService { get; }
   
    }
}
