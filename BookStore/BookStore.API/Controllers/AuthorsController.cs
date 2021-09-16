using AutoMapper;
using BookStore.API.Contracts.Repositories;
using BookStore.API.Contracts.Services;
using BookStore.API.DTOs;
using BookStore.API.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(IAuthorService authorService, IMapper mapper, ILogger<AuthorsController> logger)
        {
            _authorService = authorService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all authors.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuthorDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            try
            {
                var authors = await _authorService.GetAll();
                return Ok(authors);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, "Please contact the Administrator.");
            }
        }

        /// <summary>
        /// Get author by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AuthorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthorDTO>> GetAuthorById([FromRoute] int id)
        {
            try
            {
                var author = await _authorService.Get(id);
                if (author == null)
                {
                    return NotFound();
                }

                return author;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, "Please contact the Administrator.");
            }
        }

        /// <summary>
        /// Create an author and save to database.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(AuthorDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorDTO>> CreateAuthor([FromBody] AuthorDTOCreate author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newAuthor = await _authorService.Create(author);
                return CreatedAtAction(nameof(GetAuthorById), new { id = newAuthor.Id }, newAuthor);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update an author.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(AuthorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorDTO>> UpdateAuthor([FromBody] AuthorDTOUpdate author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _authorService.Update(author);
                return Ok(author);
            }
            catch(ServiceException se)
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
        /// Delete an author.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAuthor([FromRoute] int id)
        {
            try
            {
                await _authorService.Remove(id);
                return Ok();
            }
            catch(ServiceException se)
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
