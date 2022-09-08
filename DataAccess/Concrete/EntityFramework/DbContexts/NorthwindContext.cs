

using Core.Entity.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess.Concrete.EntityFramework.DbContexts
{
    public class NorthwindContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\mssqllocaldb; Database =Northwind ;Trusted_Connection = true; ");
        }

    
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaims> UserOperationClaims { get; set; }

    }
}

