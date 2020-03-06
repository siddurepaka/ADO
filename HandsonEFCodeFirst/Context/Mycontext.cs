using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using HandsonEFCodeFirst.Models;


namespace HandsonEFCodeFirst.Context
{
    class Mycontext:DbContext
    {
        
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-2BPKC13\SQLEXPRESS;Initial Catalog=PracticeDB;Persist Security Info=True;User ID=sa;Password=pass@word1");
           

        }
    }
}
