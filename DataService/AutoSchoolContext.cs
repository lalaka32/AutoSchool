using Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
	public class AutoSchoolContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<TestResult> TestResults { get; set; }

		public DbSet<TestRules> TestRules { get; set; }

		public DbSet<RulesSection> RulesSections { get; set; }
		
		public DbSet<AutoClassGroupe> AutoClassGroupes { get; set; }

		public DbSet<Qualifications> Qualifications { get; set; }

		public DbSet<CategoryOfDriverLicence> CategoryOfDriverLicences { get; set; }
		
		public DbSet<AutoSchoolAdmin> AutoSchoolAdmins { get; set; }

		public DbSet<AutoSchool> AutoSchools { get; set; }

		public DbSet<EmployeeLecturer> EmployeeLecturers { get; set; }

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
