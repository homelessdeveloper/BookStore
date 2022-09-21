using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackBookStore.Models;
namespace BackBookStore.Persitence
{
    public class AppDbContext: DbContext
    {
        public virtual DbSet<Book> Books {get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }
    }
}