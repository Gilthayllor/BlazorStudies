using BookStore.API.Contracts.Repositories;
using BookStore.API.Contracts.Services;
using BookStore.API.DTOs;
using BookStore.API.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            try
            {
                var books = await _bookService.GetAll();
                return Ok(books);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, "Please contact the Administrator.");
            }
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDTO>> GetBookById([FromRoute] int id)
        {
            try
            {
                var book = await _bookService.Get(id);
                if(book == null)
                {
                    return NotFound();
                }

                return Ok(book);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, "Please contact the Administrator.");
            }
        }

        /// <summary>
        /// Create an book and save to database.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(BookDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDTO>> CreateBook([FromBody] BookDTOCreate book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newBook = await _bookService.Create(book);
                return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update an book.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(BookDTOUpdate), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDTOUpdate>> UpdateBook([FromBody] BookDTOUpdate book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _bookService.Update(book);
                return Ok(book);
            }
            catch (ServiceException se)
            {
                return BadRequest(se.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Delete an book.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteBook([FromRoute] int id)
        {
            try
            {
                await _bookService.Remove(id);
                return Ok();
            }
            catch (ServiceException se)
            {
                return BadRequest(se.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}
