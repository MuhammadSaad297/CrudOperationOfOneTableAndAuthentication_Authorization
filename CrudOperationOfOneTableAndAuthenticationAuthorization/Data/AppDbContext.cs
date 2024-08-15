using CrudOperationOfOneTableAndAuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CrudOperationOfOneTableAndAuthenticationAuthorization.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Saad",
                    FName = "Akbar Ali",
                    Email = "saad2@gmail.com",
                    RollNo = "BCS19-223",
                    PhoneNumber = "03026199105",
                    Address = "Ali pur Chatha District Gujjranwala"

                },

                 new Student
                 {
                     Id = 2,
                     Name = "Usman",
                     FName = "Javaid",
                     Email = "usman123@gmail.com",
                     RollNo = "BCS19-03",
                     PhoneNumber = "030432723282",
                     Address = "Gujjranwala"

                 },
                 new Student
                 {
                     Id = 3,
                     Name = "Umair",
                     FName = "Aslam",
                     Email = "umairaslam008@gmail.com",
                     RollNo = "BCS19-34",
                     PhoneNumber = "030432287282",
                     Address = "Peoples Colony Gujjranwala"

                 }
               );

        }
    }
}
