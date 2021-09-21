using AutoMapper;
using BookStore.API.Contracts.Repositories;
using BookStore.API.Contracts.Services;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Implementations.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;
        private IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookDTO> Create(BookDTOCreate entity)
        {
            var book = _mapper.Map<Book>(entity);

            if (await _repository.Create(book))
            {
                return _mapper.Map<BookDTO>(book);
            }
            return null;
        }

        public async Task<BookDTO> Get(int id)
        {
            var book = await _repository.FindById(id);
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            var books = await _repository.FindAll();
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<bool> Remove(int id)
        {
            if (!await _repository.Exists(id))
            {
                throw new ServiceException($"Book with id: {id} not found.");
            }

            return await _repository.Delete(new Book { Id = id });
        }

        public async Task<bool> Update(BookDTOUpdate entity)
        {
            if (!await _repository.Exists(entity.Id))
            {
                throw new ServiceException($"Book with id: {entity.Id} not found.");
            }

            var book = _mapper.Map<Book>(entity);

            return await _repository.Update(book);
        }
    }
}
