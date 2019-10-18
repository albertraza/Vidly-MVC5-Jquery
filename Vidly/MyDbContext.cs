using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly
{
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public MyDbContext()
        {
        }
    }
}