using Microsoft.EntityFrameworkCore;

namespace DelClub.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<BurgerKing> BurgerKings { get; set; }
        public DbSet<DominoPizza> DominoPizzas { get; set; }
        public DbSet<Kfc> Kfcs { get; set; }
        public DbSet<MyBox> MyBoxes { get; set; }
        public DbSet<SushiBox> SushiBoxes { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
