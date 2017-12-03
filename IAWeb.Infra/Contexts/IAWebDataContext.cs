using IAWeb.Domain.Entities;
using IAWeb.Infra.Mappings;
using IAWeb.Shared;
using System.Data.Entity;

namespace IAWeb.Infra.Contexts
{
    public class IAWebDataContext : DbContext
    {
        public IAWebDataContext() : base(Runtime.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ConversationMap());
        }
    }
}
