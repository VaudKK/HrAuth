using HrAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace HrAuth.Context
{

    public class PostgreContext: DbContext{

        public PostgreContext(DbContextOptions<PostgreContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder builder)  
        {
            base.OnModelCreating(builder);

            //Value Converters
            builder
                .Entity<User>()
                .Property(e => e.UserId)
                .HasConversion<string>();
        } 
        
        public DbSet<User> HrUsers { get; set; }
    }

}