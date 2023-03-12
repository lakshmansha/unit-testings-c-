using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitTest.API.Data;
using UnitTest.API.Models;

namespace UnitTest.API.Data
{
    public class UnitTestAPIContext : DbContext
    {
        public UnitTestAPIContext (DbContextOptions<UnitTestAPIContext> options)
            : base(options)
        {
        }

        public DbSet<UnitTest.API.Models.Product> Product { get; set; } = default!;

        public void MarkAsModified(Product item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public DbSet<UnitTest.API.Models.User> User { get; set; }
    }
}
