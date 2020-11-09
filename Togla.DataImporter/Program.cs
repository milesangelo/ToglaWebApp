using System;
using System.Collections.Generic;
using Togla.Data;
using Togla.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Togla.Utilities.DataImporter
{
	class Program
	{
		static void Main(string[] args)
		{
			//DbContextOptions options

			///ToglaDbContext db = new ToglaDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions());

			List<Stock> stocksToImport = new List<Stock>();

			stocksToImport.Add(new Stock
			{
				SymbolTicker = "MSFT",
				Price = 151.50m,

			});
			

			
			// Open up a CSV file.

			// for every row in the CSV,

			// Create Stock object

			// Pass into database and save



			Console.WriteLine("Hello World!");
		}
	}
}
