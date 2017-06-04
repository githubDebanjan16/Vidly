using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RentalViewModel
    {
        public int? Id { get; set; }

        
        public Customer Customer { get; set; }

        //[Required]
        public Movie Movie { get; set; }


        public DateTime RentalDate { get; set; }
        [Required]
        public DateTime? ReturnDate { get; set; }
    }
}