using BulkDeleteCreate.Model;
using BulkDeleteCreate.SqlServer.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BulkDeleteCreate.SqlServer
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            new UserMap(modelBuilder.Entity<User>());
            new GroupMap(modelBuilder.Entity<Group>());
            new GroupMemberMap(modelBuilder.Entity<GroupMember>());
        }
    }
}
