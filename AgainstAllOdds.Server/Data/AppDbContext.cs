using AgainstAllOdds.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AgainstAllOdds.Server.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Habit> Habits { get; set; }
		public DbSet<HabitLog> HabitLogs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<HabitLog>()
				.HasIndex(hl => new { hl.HabitId, hl.Date })
				.IsUnique();
		}
	}
}