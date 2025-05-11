using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    //Bu sınıf new leme yapılmaması için abstract sınıf olarak tanımlanmıştır.
    public abstract class NotFoundException : Exception
    {
        //TODO: Bu class new leme yapılmadığından protected constructor tanımlanmıştır.
        //TODO: Sadece devr alınan classlarda kullanacağı için 
        protected NotFoundException(string message) : base(message)
        {

        }
    }
}
