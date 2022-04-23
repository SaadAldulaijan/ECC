using ECC.Models;
using Microsoft.EntityFrameworkCore;

namespace ECC.Users.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupPermission>().HasKey(x => new {x.GroupId, x.PermissionId});
        }
    }
}