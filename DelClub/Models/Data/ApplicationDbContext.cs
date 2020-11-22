using Microsoft.EntityFrameworkCore;

namespace DelClub.Models.Data
{
    //Класс контекста БД
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        //Предоставление доступа к объектам для чтения и записи данных в приложении
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Makdonalds> Makdonalds { get; set; }
        public DbSet<BurgerKing> BurgerKings { get; set; }
        public DbSet<DominoPizza> DominoPizzas { get; set; }
        public DbSet<Kfc> Kfcs { get; set; }
        public DbSet<MyBox> MyBoxes { get; set; }
        public DbSet<SushiBox> SushiBoxes { get; set; }
        public DbSet<MDOrder> MDOrders { get; set; }
        public DbSet<BKOrder> BKOrders { get; set; }
        public DbSet<DPOrder> DPOrders { get; set; }
        public DbSet<KfcOrder> KfcOrders { get; set; }
        public DbSet<MBOrder> MBOrders { get; set; }
        public DbSet<SBOrder> SBOrders { get; set; }
    }
}
