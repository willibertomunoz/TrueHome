using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppContext : DbContext, IAppContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Property { get; set; }

        public DbSet<Activity> Activity { get; set; }

        public DbSet<Survey> Survey { get; set; }
    }
}
