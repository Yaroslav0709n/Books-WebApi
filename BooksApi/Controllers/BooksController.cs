using BooksAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<Books> books = new List<Books>
        {
            //new Books
            //{
            //    Id = 1, Title = "It", Writer = "Stiven King"
            //},
            //new Books
            //{
            //    Id = 2, Title = "Adventure of Sherlock Holmes",  Writer = "Arthur Conan Doyle"
            //}
        };
        private readonly APIDbContext context;
        public BooksController(APIDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Books>>> Get()
        {
            return Ok(await context.Books.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> Get(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Book not found");

            return Ok(book);
        }
        [HttpPost]
        public async Task<ActionResult<List<Books>>> AddBook(Books book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return Ok(await context.Books.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Books>>> UpdateBook(Books request)
        {
            var book = await context.Books.FindAsync(request.Id);
            if (book == null)
                return BadRequest("Book not found");

            book.Title = request.Title;
            book.Writer = request.Writer;
            book.Price = request.Price;
            await context.SaveChangesAsync();
            return Ok(await context.Books.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Books>>> DeleteBook(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Book not found");

            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return Ok(await context.Books.ToListAsync());
        }
    }
}
