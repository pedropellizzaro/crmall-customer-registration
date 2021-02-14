using CustomerRegistration.Domain.Entities;
using CustomerRegistration.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistration.Infrastructure.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}