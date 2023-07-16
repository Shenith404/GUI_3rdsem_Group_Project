using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using test2.Models;

namespace test2
{
    public class DatabaseDataContex:DbContext
    {
        public DbSet<User> Dbusers { get; set; }
        
        public DbSet<Module> Dbmodules { get; set; }
        public DbSet<Student> Dbstudnets { get; set; }

        public DbSet<LoginHistory> DbLoginHistory_list { get; set; }

       
        public DbSet<StudentModules> DBstudentModules { get; set; }

        private readonly string _path = @"c:\temp\test2.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={_path}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModules>()
            .HasKey(ms => ms.Id);

            modelBuilder.Entity<StudentModules>()
                .HasOne(ms => ms.Student)
                .WithMany(s => s.StudentModules)
                .HasForeignKey(ms => ms.StudentId);

            modelBuilder.Entity<StudentModules>()
                .HasOne(ms => ms.Module)
                .WithMany(m => m.Modulestudents)
                .HasForeignKey(ms => ms.ModuleId);



        }
    }
}
