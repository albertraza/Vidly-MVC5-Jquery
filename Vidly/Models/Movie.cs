using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string DateAdded { get; set; }
        [Required]
        public byte NumberInStock { get; set; }
        [Required]
        public GenreType Genre { get; set; }
        [Required]
        public int GenreId { get; set; }

    }
}