using BookStore.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Contracts.Services
{
    public interface IAuthorService
    {
        Task<AuthorDTO> Create(AuthorDTOCreate entity);

        Task<bool> Update(AuthorDTOUpdate entity);

        Task<bool> Remove(int id);

        Task<AuthorDTO> Get(int id);

        Task<IEnumerable<AuthorDTO>> GetAll();
    }
}
