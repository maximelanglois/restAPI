using Microsoft.EntityFrameworkCore;

namespace restapi.Models
{
    public class leadContext : DbContext
    {
        public leadContext(DbContextOptions<leadContext> options) :base (options)
        {

        }
        public DbSet<lead> leads {get; set;}

    }
}