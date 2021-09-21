using BookStore.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Contracts.Services
{
    public interface IBookService
    {
        Task<BookDTO> Create(BookDTOCreate entity);

        Task<bool> Update(BookDTOUpdate entity);

        Task<bool> Remove(int id);

        Task<BookDTO> Get(int id);

        Task<IEnumerable<BookDTO>> GetAll();
    }
}
