using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackBookStore.Persitence;
using Microsoft.EntityFrameworkCore;
using BackBookStore.Models;
using BackBookStore.Arguments;
namespace BackBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ICollection<Book>> FindMany()
        {
            return await _context.Books.ToListAsync();
        }  

        [HttpPost]
        public async Task<Book> CreateOne(CreateBookArguments arguments )
        {
            var book = new Book{ 
                Name = arguments.Name
            };
            var result = _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        [HttpDelete("{id:int}")]
        public async Task DeleteOne(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
