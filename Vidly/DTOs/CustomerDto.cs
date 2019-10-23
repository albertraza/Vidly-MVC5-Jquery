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
        public string Name { get; set; }

        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSuscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}