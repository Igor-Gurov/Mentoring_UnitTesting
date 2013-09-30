using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskCodeFirst.Entities;

namespace TaskCodeFirst
{
	public class TaskContext : DbContext
	{
		public DbSet<Payment> Payments { get; set; }

		public DbSet<Good> Goods { get; set; }

		public DbSet<Category> Category { get; set; }

		public DbSet<Client> Clients { get; set; }

		public DbSet<CashOperationType> CashOperationType { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CashOperationType>().ToTable("CashOperationTypies");
			modelBuilder.Entity<SpotCash>().ToTable("SpotCashes");
			modelBuilder.Entity<BankCard>().ToTable("BankCarded");
			modelBuilder.Entity<WebMoney>().ToTable("WebMoney");
			modelBuilder.Entity<PayPal>().ToTable("PayPal");

			modelBuilder.Entity<Payment>()
				.HasRequired(c => c.Client)
				.WithMany()
				.HasForeignKey(c => c.ClientId);
		
			modelBuilder.Entity<Good>()
				.HasMany(g => g.Categories)
				.WithMany(c => c.Goods)
				.Map(m =>
					{
						m.MapLeftKey("Good");
						m.MapRightKey("Category");
						m.ToTable("Structure");
					});

			base.OnModelCreating(modelBuilder);
		}
	}
}
