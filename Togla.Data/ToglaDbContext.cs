using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Togla.Data.Models;

namespace Togla.Data
{
	public class ToglaDbContext: DbContext
	{
		/// <summary>
		/// 
		/// </summary>
		public ToglaDbContext() { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		public ToglaDbContext(DbContextOptions options) : base(options) { }

		/// <summary>
		/// 
		/// </summary>
		public virtual DbSet<Stock> Stocks { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(
				"Host=localhost;Port=5432;Username=postgres;Password=GNUsn0tunix;Database=togla.dev2;");
			base.OnConfiguring(optionsBuilder);
		}
	}
}
