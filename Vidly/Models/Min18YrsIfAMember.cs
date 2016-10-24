using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YrsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId==MembershipType.Unknown
                ||customer.MembershipTypeId ==MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("BirthDate is Required");
            var ageDiff = DateTime.Now.Year - customer.BirthDate.Value.Year;

            return (ageDiff>=18) 
                ?  ValidationResult.Success
                : new ValidationResult("Customer Must be over 18 Years of Age");
        }
    }
}

