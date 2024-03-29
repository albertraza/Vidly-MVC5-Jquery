﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name ="Number in Stock")]
        [NunInStockBetwen1And20]
        public byte NumberInStock { get; set; }

        [Required]
        public byte NumberAvailable { get; set; }

        public GenreType Genre { get; set; }

        [Required]
        [Display(Name ="Genre")]
        public int GenreId { get; set; }


    }
}