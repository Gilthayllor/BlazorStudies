﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Data
{
    [Table("Books")]
    public partial class Book : BaseEntity
    {
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Isbn { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}