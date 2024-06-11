using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Infrastructure.Context
{
    public class SwdImsContext : DbContext
    {
        public SwdImsContext()
        {

        }
        public SwdImsContext(DbContextOptions<SwdImsContext> options) : base(options)
        {

        }
        public DbSet<Domain.Entities.Models.Application> Applications { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Intern> Interns { get; set; }
        public DbSet<TaskResult> TaskResults { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Domain.Entities.Models.Task> Tasks { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<WorkResult> WorkResults { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    Name = "Admin"
                },
                new Role
                {
                    RoleId = 2,
                    Name = "Mentor"
                },
                new Role
                {
                    RoleId = 3,
                    Name = "Intern"
                },
                new Role
                {
                    RoleId = 4,
                    Name = "HRManager"
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    FullName = "Admin",
                    Password = "00000000",
                    Phone = "0000000000",
                    Email = "SWD_IMS@gmail.com",
                    RoleId = 1,
                }
            );
        }
    }
}