using Microsoft.EntityFrameworkCore;

namespace restapi.Models
{
    public class elevatorContext : DbContext
    {
        public elevatorContext(DbContextOptions<elevatorContext> options) :base (options)
        {

        }
        public DbSet<elevator> elevators {get; set;}

    }
}