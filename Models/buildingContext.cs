using Microsoft.EntityFrameworkCore;

namespace restapi.Models
{
    public class buildingContext : DbContext
    {
        public buildingContext(DbContextOptions<buildingContext> options) :base (options)
        {

        }
        public DbSet<building> buildings {get; set;}

    }
}