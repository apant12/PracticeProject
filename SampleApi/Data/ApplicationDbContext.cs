using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SampleApi.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            

        }

        public DbSet<ProjectEntity> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntity>().HasData(
                new ProjectEntity() { 
                    IsActive = true ,
                    ProjectId=1,
                    Name="Ayush"
                }, new ProjectEntity()
                {
                    IsActive = true,
                    ProjectId = 2,
                    Name = "Nirakar"
                },
                 new ProjectEntity()
                 {
                     IsActive = true,
                     ProjectId = 3,
                     Name = "Bentdkesh"
                 });
        }
    }
}
