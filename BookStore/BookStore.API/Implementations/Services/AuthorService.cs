using AutoMapper;
using BookStore.API.Contracts.Repositories;
using BookStore.API.Contracts.Services;
using BookStore.API.Data;
using BookStore.API.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Implementations.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> Create(AuthorDTO entity)
        {
            var author = _mapper.Map<Author>(entity);

            if (await _repository.Create(author))
            {
                return _mapper.Map<AuthorDTO>(author);
            }
            return null;
        }

        public async Task<AuthorDTO> Get(int id)
        {
            var author = await _repository.FindById(id);
            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task<IEnumerable<AuthorDTO>> GetAll()
        {
            var authors = await _repository.FindAll();
            return _mapper.Map<IEnumerable<AuthorDTO>>(authors);
        }

        public async Task<bool> Remove(int id)
        {
            if (!await _repository.Exists(id))
            {
                throw new Exception($"Author with id: {id} not found.");
            }

            return await _repository.Delete(new Author { Id = id });
        }

        public async Task<AuthorDTO> Update(AuthorDTO entity)
        {
            if (!await _repository.Exists(entity.Id))
            {
                throw new Exception($"Author with id: {entity.Id} not found.");
            }

            var author = _mapper.Map<Author>(entity);

            if (await _repository.Update(author))
            {
                return entity;
            }

            return null;
        }
    }
}
