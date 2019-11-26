using Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Common.BusinessObjects;

namespace DataAccess
{
    public class AutoSchoolContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<DrivingTest> DrivingTests { get; set; }

        public DbSet<RoadSituation> RoadSituations { get; set; }

	public DbSet<RuleSection> RulesSections { get; set; }
		
	public DbSet<AutoClassGroup> AutoClassGroups { get; set; }

        public DbSet<RuleSection> RuleSections { get; set; }

        public DbSet<AutoClassGroupe> AutoClassGroupes { get; set; }

        //public DbSet<Qualifications> Qualifications { get; set; }

        public DbSet<CategoryOfDriverLicence> CategoryOfDriverLicences { get; set; }

	public DbSet<AutoSchoolEmployee> AutoSchoolEmployees { get; set; }

        public DbSet<AutoSchoolAdmin> AutoSchoolAdmins { get; set; }

        public DbSet<AutoSchool> AutoSchools { get; set; }

        public DbSet<EmployeeLecturer> EmployeeLecturers { get; set; }

        public DbSet<Progress> Progresses { get; set; }

        public AutoSchoolContext(DbContextOptions<AutoSchoolContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
