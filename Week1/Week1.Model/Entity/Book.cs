using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Model.Entity
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
