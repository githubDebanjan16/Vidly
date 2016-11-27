using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }


        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        //[Min18YrsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}