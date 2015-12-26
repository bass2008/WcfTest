using System.Data.Entity;
using WcfTestApp.Domain.Models;

namespace WcfTestApp.DAL
{
    public class ServiceContext : DbContext
    {
        static ServiceContext()
        {
            Database.SetInitializer<ServiceContext>(new ContextInitializer());
        }
        
        public ServiceContext()
            : base("DbConnection")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Importance> Importances { get; set; }
    }
}
