using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
	public class HospitalContext : DbContext
	{
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Visitation> Visitations { get; set; }
		public DbSet<Diagnose> Diagnoses { get; set; }
		public DbSet<Medicament> Medicaments { get; set; }
		public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
		public DbSet<Doctor> Doctors { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(Configuration.ConactionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			ConfigurePatientEntity(modelBuilder);

			ConfigureVisitationEntity(modelBuilder);

			ConfigureDiagnoseEntity(modelBuilder);

			ConfigureMedicamentEntity(modelBuilder);

			ConfigurePatientMedicamentEntity(modelBuilder);

			ConfigureDoctorMedicamentEntity(modelBuilder);
		}

		private void ConfigureDoctorMedicamentEntity(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Doctor>()
				.HasKey(x => x.DoctorId);

			modelBuilder
				.Entity<Doctor>()
				.HasMany(x => x.Visitations)
				.WithOne(x => x.Doctor);
		}

		private void ConfigurePatientMedicamentEntity(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<PatientMedicament>()
				.HasKey(x => new {x.Patient, x.MedicamentId});

			modelBuilder
				.Entity<PatientMedicament>()
				.HasOne(x => x.Patient)
				.WithMany(x => x.Prescriptions)
				.HasForeignKey(x => x.PatientId);

			modelBuilder
				.Entity<PatientMedicament>()
				.HasOne(x => x.Medicament)
				.WithMany(x => x.Prescriptions)
				.HasForeignKey(x => x.MedicamentId);
		}

		private void ConfigureMedicamentEntity(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Medicament>()
				.HasKey(x => x.MedicamentId);

			modelBuilder
				.Entity<Medicament>()
				.Property(x => x.Name)
				.HasMaxLength(50)
				.IsUnicode()
				.IsRequired();
		}

		private void ConfigureDiagnoseEntity(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Diagnose>()
				.HasKey(x => x.DiagnoseId);

			modelBuilder
				.Entity<Diagnose>()
				.Property(x => x.Name)
				.HasMaxLength(50)
				.IsUnicode()
				.IsRequired();

			modelBuilder
				.Entity<Diagnose>()
				.Property(x => x.Comments)
				.HasMaxLength(250)
				.IsUnicode();
		}

		private void ConfigureVisitationEntity(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Visitation>()
				.HasKey(x => x.VisitationId);

			modelBuilder
				.Entity<Visitation>()
				.Property(x => x.Comments)
				.HasMaxLength(250)
				.IsUnicode();
		}

		private void ConfigurePatientEntity(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Patient>()
				.HasKey(p => p.PatientId);

			modelBuilder
				.Entity<Patient>()
				.HasMany(p => p.Visitations)
				.WithOne(v => v.Patient);

			modelBuilder
				.Entity<Patient>()
				.HasMany(p => p.Diagnoses)
				.WithOne(d => d.Patient);

			modelBuilder
				.Entity<Patient>()
				.Property(p => p.FirstName)
				.HasMaxLength(50)
				.IsUnicode()
				.IsRequired();

			modelBuilder
				.Entity<Patient>()
				.Property(p => p.LastName)
				.HasMaxLength(50)
				.IsUnicode()
				.IsRequired();

			modelBuilder
				.Entity<Patient>()
				.Property(p => p.Address)
				.HasMaxLength(250);

			modelBuilder
				.Entity<Patient>()
				.Property(p => p.Email)
				.HasMaxLength(80);
		}
	}
}
