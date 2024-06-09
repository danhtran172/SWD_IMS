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
        public DbSet<Application> Applications { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Intern> Interns { get; set; }
        public DbSet<TaskResult> TaskResults { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Domain.Entities.Models.Task> Tasks { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<WorkResult> WorkResults { get; set; }
        public DbSet<User> Users { get; set; }
    }
}