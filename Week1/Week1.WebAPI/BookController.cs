using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Week1.Data;
using Week1.Model.Entity;

namespace Week1.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x=>x.Id).ToList();
    }
}
