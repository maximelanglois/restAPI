using Microsoft.EntityFrameworkCore;

namespace restapi.Models
{
    public class columnContext : DbContext
    {
        public columnContext(DbContextOptions<columnContext> options) :base (options)
        {

        }
        public DbSet<column> columns {get; set;}

    }
}