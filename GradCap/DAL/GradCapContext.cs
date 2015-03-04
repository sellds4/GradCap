using GradCap.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GradCap.DAL
{
    public class GradCapContext : IdentityDbContext<ApplicationUser>
    {
        public GradCapContext() : base("GradCapContext", throwIfV1Schema: false)
        {
        }

        public static GradCapContext Create()
        {
            return new GradCapContext();
        }

        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<ApplicationUser>()
                .HasMany<School>(s => s.FavoriteSchools)
                .WithMany(c => c.FavoriteStudents)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentId");
                    cs.MapRightKey("SchoolId");
                    cs.ToTable("FavoriteStudentSchool");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<School>(s => s.NoInterestSchools)
                .WithMany(c => c.NoInterestStudents)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentId");
                    cs.MapRightKey("SchoolId");
                    cs.ToTable("NoInterestStudentSchool");
                });
        } 
    }
}