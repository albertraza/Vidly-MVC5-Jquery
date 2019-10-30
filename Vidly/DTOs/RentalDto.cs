using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class RentalDto
    {
        public byte CustomerId { get; set; }
        public List<byte> MoviesId { get; set; }
    }
}