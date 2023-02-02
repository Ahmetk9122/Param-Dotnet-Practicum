using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Model.Entity;

namespace Week1.Data
{
    public class BookList
    {
        static List<Book> Main(BookList[] args)
        {
         Book book1= new Book
            {
                Id = 1,
                Title = "Yüzüklerin Efendisi",
                GenreId = 1,
                PageCount = 500,
                PublishDate =new DateTime(2001,06,12)
                
            };
         Book book2 = new Book
            {
                Id = 2,
                Title = "Lean StartUp",
                GenreId = 2,
                PageCount = 200,
                PublishDate = new DateTime(2011, 12, 15)

            };
         Book book3 = new Book
            {
                Id =3,
                Title = "Herland",
                GenreId =2,
                PageCount = 250,
                PublishDate = new DateTime(2081, 07, 17)

            };
         Book book4 = new Book
            {
                Id = 4,
                Title = "Dune",
                GenreId = 3,
                PageCount = 400,
                PublishDate = new DateTime(2006, 03, 10)

            };

            List<Book> BookList = new List<Book>();
            BookList.Add(book1);
            BookList.Add(book2);
            BookList.Add(book3);
            BookList.Add(book4);
            return BookList;
        }
    }
}
