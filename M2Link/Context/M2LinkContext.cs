using M2Link.Entities;
using M2Link.Repositories;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using M2Link.Models;

namespace M2Link.Context
{
    public class M2LinkContext : DbContext
    {
        public M2LinkContext() : base("M2LinkContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}