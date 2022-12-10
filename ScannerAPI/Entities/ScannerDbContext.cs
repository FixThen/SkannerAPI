using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ScannerAPI.Entities
{
	public class ScannerDbContext : DbContext
	{
		public DbSet<Scanner> Scanners { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<History> History_List { get; set; }
		public ScannerDbContext(DbContextOptions<ScannerDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Scanner>()
				.Property(s => s.Budynek)
				.IsRequired()
				.HasMaxLength(25);

			modelBuilder.Entity<History>()
				.Property(d => d.Data)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(a => a.Nazwisko)
				.IsRequired()
				.HasMaxLength(50);
		}
	}
}
