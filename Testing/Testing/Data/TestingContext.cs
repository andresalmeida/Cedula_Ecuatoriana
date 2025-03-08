using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testing.Models;

namespace Testing.Data
{
    public class TestingContext : DbContext
    {
        public TestingContext (DbContextOptions<TestingContext> options)
            : base(options)
        {
        }

        public DbSet<Testing.Models.ClientePostgreSQL> ClientePostgreSQL { get; set; } = default!;
    }
}
