using Microsoft.EntityFrameworkCore;

namespace TP3.Models
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<TP3.Models.Customer> Customer { get; set; } = default!;
        public DbSet<TP3.Models.Movie> Movie { get; set; } = default!;
        public DbSet<TP3.Models.MembershipType> MembershipType { get; set; } = default!;
        public DbSet<TP3.Models.Genre> Genre { get; set; } = default!;
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            string GenreJSon = System.IO.File.ReadAllText("Genres.json");
            List<Genre>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            //Seed to categorie
            foreach (Genre c in genres)
                model.Entity<Genre>()
                .HasData(c);
        }
    }
}
