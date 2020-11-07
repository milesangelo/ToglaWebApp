using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Togla.Data.Models;

namespace Togla.Data
{
	public class ToglaDbContext: DbContext
	{
		public ToglaDbContext() { }

		public ToglaDbContext(DbContextOptions options) : base(options) { }

		public virtual DbSet<Stock> Stocks { get; set; }

	}
}
