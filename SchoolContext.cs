using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FluentAPI_004
{
    public class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"server=Admin; Database=FluentAPIOneToMany; Trusted_Connection=True; Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Grades)
                .WithMany(p => p.Students)
                .HasForeignKey(a => a.CurrentGradeId)
                .OnDelete(DeleteBehavior.Cascade); // Xoá tự động
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grade { get; set; }
    }
}
