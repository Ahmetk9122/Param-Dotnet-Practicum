using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Week1.Data;
using Week1.Model.Entity;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Week1.WebAPI
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {

            var bookList = BookList.OrderBy(book => book.Id).ToList();
            if (bookList.Count == 0)
                return BadRequest();
                return Ok(bookList);

        }
        [HttpGet("{id}")]
        public Book GetBookById(int id)
        {
            var book = BookList.Find(book => book.Id == id);
            return book;
        }

        [HttpGet("/book-by-formquery")]
        public Book GetBookByIdFormQuery([FromQuery] string id)
        {
            var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult CreatBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x=>x.Id==newBook.Id);
            if (book is not null)
                return BadRequest();
            BookList.Add(newBook);
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id ,[FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();

            book.GenreId= updatedBook.GenreId != default ? updatedBook.GenreId :book.GenreId;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;

            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return NoContent();

            BookList.Remove(book);
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();

            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;

            return Ok();

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetToDescending()
        {
            var bookList = BookList.OrderByDescending(book => book.Title).ToList();
            return Ok(bookList);
        }


        #region BookData
        private static List<Book> BookList = new List<Book>()
        {
         new Book
         {
             Id = 1,
             Title = "Yüzüklerin Efendisi",
             Description = "Yüzüklerin Efendisi orta çağda geçen bir kitaptır.",
             GenreId = 1,
             PageCount = 500,
             PublishDate = new DateTime(2001, 06, 12)

         },
        new Book
        {
            Id = 2,
            Title = "Lean StartUp",
            GenreId = 2,
            PageCount = 200,
            PublishDate = new DateTime(2011, 12, 15)

        },
         new Book
        {
            Id = 3,
            Title = "Herland",
            GenreId = 2,
            PageCount = 250,
            PublishDate = new DateTime(2081, 07, 17)

        },
         new Book
        {
            Id = 4,
            Title = "Dune",
            GenreId = 3,
            PageCount = 400,
            PublishDate = new DateTime(2006, 03, 10)

        }
        #endregion
      
    };
    }
    
}
