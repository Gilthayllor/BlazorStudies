using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Isbn { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public int? AuthorId { get; set; }
        public virtual AuthorDTO Author { get; set; }
    }

    public class BookDTOCreate
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public int? Year { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        public string Isbn { get; set; }
        [MaxLength(500, ErrorMessage = "Max length is 500")]
        public string Summary { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public int? AuthorId { get; set; }
    }
    
    public class BookDTOUpdate
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public int? Year { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        public string Isbn { get; set; }
        [MaxLength(500, ErrorMessage = "Max length is 500")]
        public string Summary { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public int? AuthorId { get; set; }
    }
}
