using Microsoft.EntityFrameworkCore;

namespace restapi.Models
{
    public class mySQLContext : DbContext
    {
        public mySQLContext(DbContextOptions<mySQLContext> options) :base (options)
        {

        }
        public DbSet<building> buildings {get; set;}
        public DbSet<battery> batteries {get; set;}
        public DbSet<column> columns {get; set;}
        public DbSet<customer> customers {get; set;}
        public DbSet<elevator> elevators {get; set;}
        public DbSet<lead> leads {get; set;}
        public DbSet<intervention> interventions {get; set;}


    }
}