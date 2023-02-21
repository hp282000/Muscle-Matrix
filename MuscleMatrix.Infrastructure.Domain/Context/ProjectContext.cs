using Microsoft.EntityFrameworkCore;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }


        public DbSet<Class> Classifications { get; set; }

        public DbSet<Class_Schedule> class_Schedules { get; set; }

        public DbSet<GymLocation> GymLocations { get; set; }

        public DbSet<Height> Heights { get; set; }  

        public DbSet<Member> Members { get; set; }  

        public DbSet<Membership> Memberships { get; set; }  

        public DbSet<MembershipPayment> MembershipPayments { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Trainer> Trainers { get; set; }    

        public DbSet<User> Users { get; set; }

        public DbSet<UserRoleMapping> userRoleMappings { get; set; }

        public DbSet<Weight> Weights { get; set; }  
        public DbSet<Booking> Bookings { get; set; }

    }
}
