using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    //TODO:  internal public yap.
    public class Book
    {
        //TODO: WebAPI projemizdeki var olan Book class'ın propertileri buraya taşıyalım.
        //TODO: Sonra WebAPI projemizdeki var olan Models klasörünü silelim.
        public int Id { get; set; }
        public String Title { get; set; }
        public decimal Price { get; set; }
    }
}

