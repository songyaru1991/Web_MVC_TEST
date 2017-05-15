using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HtmlMethod.Models
{
    public class ModelDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SMT");
        }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentWithCheck> StuChecks { get; set; }
    }
}