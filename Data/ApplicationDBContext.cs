﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockAppSQ20.Model;

namespace StockAppSQ20.Data
{
    public class ApplicationDBContext: IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }


        //Roles need to be created when using identity framework
        protected override void OnModelCreating(ModelBuilder builder)
        {
             base.OnModelCreating(builder);

             List<IdentityRole> roles = new List<IdentityRole>
             {
                 new IdentityRole()
                 {
                     Name = "Admin",
                     NormalizedName = "ADMIN"
                 },

                 new IdentityRole()
                 {
                     Name = "User",
                     NormalizedName = "USER"
                 }
             };

             builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
