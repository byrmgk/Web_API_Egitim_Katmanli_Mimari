using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebAPI.Utilities.AutoMapper
{
    //TODO : MappingProfile class Profile dan kalıtım alacak
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //TODO : Mapping işlemleri burada yapılacak
            //TODO:CreateMap<Source, Destination>();
            //TODO: ReverseMap işlemi Book dan BookDtoUpdate e, BookDtoUpdate dem Book a dönüşüm yapacak
            CreateMap<BookDtoUpdate, Book>().ReverseMap();

            CreateMap<Book, BookDto>();

            CreateMap<BookDtoForInsertion, Book>();
               

        }
    }
}
