using Microsoft.EntityFrameworkCore;
using TrainingExercise.Model;

namespace TrainingExercise.DatabaseContext
{
    public class UsersDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }

    }
}
