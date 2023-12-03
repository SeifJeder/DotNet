using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? Month { get; set; }
        public int? Year { get; set; }

        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }

        public ICollection<Customer>? Customers { get; set; }


        public DateTime? MovieAdded { get; set; }
        public string? Photo { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
