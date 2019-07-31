using Microsoft.EntityFrameworkCore;

namespace restapi.Models
{
    public class customerContext : DbContext
    {
        public customerContext(DbContextOptions<customerContext> options) :base (options)
        {

        }
        public DbSet<customer> customers {get; set;}

    }
}