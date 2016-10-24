using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        

        [Required]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? DateReleased { get; set; }

        [Required]
        [Range(1, 30)]
        public byte? NumberInStock { get; set; }

        public string Title {
            get
            {
                
                return (Id!=0) ? "Edit Movie": "New Movie";

            }
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            DateReleased = movie.DateReleased;
            DateAdded = movie.DateAdded;
            NumberInStock = movie.NumberInStock;
        }
    }
}