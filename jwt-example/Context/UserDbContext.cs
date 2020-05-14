using jwt_example.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt_example.Context
{
    //DbContext ten kalıtım alarak bunun bir Context olacağını belirtiyorum
    public class UserDbContext: DbContext
    {
        //Hazırladığım modeli db ye tablo olarak eklemesini söylüyorum
        public DbSet<User>Users { get; set; }
        
        //Db olarak sqlserver
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-0SKG4BP;database=jxwEx;trusted_connection=true;");
        }

        //Veritabanı oluşturulurken dummy data ile oluşturulmasını istiyorum.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "test",
                Username = "testUser",
                Password = "testPassword"
            });
        }
    }
}
