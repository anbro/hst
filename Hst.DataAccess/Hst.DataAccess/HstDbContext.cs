using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.DataAccess
{
    public class HstDbContext : DbContext 
    {
        public HstDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HstDbContext>());
            
        }

        public HstDbContext(string connString)
        : base(connString)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HstDbContext>());

        }

        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<ChoreAssignment> ChoreRecords { get; set; }
        

    }
}
