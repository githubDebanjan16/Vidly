﻿using System;
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
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name ="Release Date")]
        public DateTime DateReleased { get; set; }

        [Required]
        [Range(1,30)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}