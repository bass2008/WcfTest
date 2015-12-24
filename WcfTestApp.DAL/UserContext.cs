using System.Data.Entity;

namespace WcfTestApp.DAL
{
        class UserContext : DbContext
        {
            public UserContext()
                : base("DbConnection")
            { }

            public DbSet<User> Users { get; set; }
        }
    
}
