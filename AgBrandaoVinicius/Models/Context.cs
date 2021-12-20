using Microsoft.EntityFrameworkCore;

namespace AgBrandaoVinicius.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<ClasseDestinos> classedestinos { get; set; }
        public DbSet<ClassePromo> classepromo { get; set; }
    }
}
