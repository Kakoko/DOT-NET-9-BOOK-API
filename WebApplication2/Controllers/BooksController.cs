using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(BookRepository.Books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var book = BookRepository.Books.FirstOrDefault(b => b.Id == id);

            if(book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book) 
        {
            book.Id = BookRepository.Books.Max(b => b.Id) + 1;
            BookRepository.Books.Add(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id , Book updatedBook)
        {
            if (id! == updatedBook.Id) 
            {
                BadRequest();
            }

            var book = BookRepository.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var book = BookRepository.Books.FirstOrDefault(b => b.Id == id);

            if(book is null)
            {
                return NotFound();
            }

            BookRepository.Books.Remove(book);
            return NoContent();
        }

    }
}
