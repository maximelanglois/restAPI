using Microsoft.EntityFrameworkCore;

namespace restapi.Models
{
    public class batteryContext : DbContext
    {
        public batteryContext(DbContextOptions<batteryContext> options) :base (options)
        {

        }
        public DbSet<battery> batteries {get; set;}

    }
}