using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;

namespace BookStore.API.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<AuthorDTOCreate, Author>().ReverseMap();
            CreateMap<AuthorDTOUpdate, Author>().ReverseMap();
            
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BookDTOCreate, Book>().ReverseMap();
            CreateMap<BookDTOUpdate, Book>().ReverseMap();
        }
    }
}
