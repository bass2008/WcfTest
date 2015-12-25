using System.Data.Entity;
using WcfTestApp.Domain.Models;

namespace WcfTestApp.DAL
{
    class ServiceContext : DbContext
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
    }
}
