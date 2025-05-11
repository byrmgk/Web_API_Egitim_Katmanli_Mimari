using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        
        //TODO: Bu classın override edilecek metodun olması. ToString() metodunu override edin.
        public override string ToString()
        {
            //TODO: JsonSerializer ile serialize edin.
            //TODO: this ifadesi sınıfın tamamını ilgilendirği için kullanıyoruz.
            return JsonSerializer.Serialize(this);
        }
    }
}
