using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVBooksAppService.Models;

namespace MVBooksAppService.Data
{
    public class MVBooksDbContext : DbContext
    {
        public MVBooksDbContext (DbContextOptions<MVBooksDbContext> options)
            : base(options)
        {
        }

        public DbSet<MVBooksAppService.Models.Book> Book { get; set; } = default!;
    }
}
