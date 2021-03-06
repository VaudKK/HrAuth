using HrAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace HrAuth.Context
{

    public class PostgreContext: DbContext{

        public PostgreContext(DbContextOptions<PostgreContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            //Value Converters

            builder
                .Entity<User>()
                .Property(e => e.UserId)
                .HasConversion<string>();

            builder
                .Entity<User>()
                .Property(e => e.CreatedAt)
                .HasConversion<long>();

             builder
                .Entity<User>()
                .Property(e => e.ModifiedAt)
                .HasConversion<long>();
        } 
        
        public DbSet<User> Users { get; set; }
    }

}