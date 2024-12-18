using Microsoft.EntityFrameworkCore;

namespace ChenileCafe.Models
{
	public class ChenilleDbContext : DbContext
	{
		public ChenilleDbContext(DbContextOptions<ChenilleDbContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; } // Đảm bảo có DbSet cho các bảng

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
	
}
