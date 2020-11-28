using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using Togla.Data;
using Togla.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Togla.Utilities.DataImporter
{
	class Program
	{
		static void Main(string[] args)
		{ 
			
			// Filepath and buffer size.
			string csvFilePath = @"/Users/milesvendetti/Downloads/equity_trade_and_quotes.csv";
			const int bufferCapacity = 16;
			
			
			// Read in the csv and place it in the buffer.
			using(var reader = new StreamReader(csvFilePath))
			{
				List<string[]> inputBuffer  = new List<string[]>(bufferCapacity);
				
				// Read out first line as it contains column titles.
				reader.ReadLine();

				while (!reader.EndOfStream)
				{
					int counter = 0;
					while (counter < inputBuffer.Capacity)
					{
						var line = reader.ReadLine();
						var values = line.Split(',');

						inputBuffer.Add(values);
				
						// Parse them into the list of stocks.
						Console.WriteLine(inputBuffer.Count);
						
						counter++;
					}
					
					//do something with the input buffer.
					using (var db = new ToglaDbContext())
					{
						//CSV Table Schema as follows for equity data
						// Date,Timestamp,EventType,Ticker,Price,Quantity,Exchange,Conditions
					
						foreach (var row in inputBuffer)
						{
							Stock newStock = new Stock()
							{
								UpdatedOn = DateTime.Now,
								Date = DateTime.ParseExact(row[0], "yyyyMMdd",
									CultureInfo.InvariantCulture),
								Timestamp = row[1],
								EventType = row[2],
								SymbolTicker = row[3],
								Price = Convert.ToDecimal(row[4]),
								Quantity = Convert.ToInt32(row[5]),
								Exchange = row[6],
								Conditions = row[7]
							};
							
							// Stock newStock = new Stock()
							// {
							// 	Price = 1m,
							// 	SymbolTicker = "test",
							// 	CreatedOn = DateTime.Now
							// };
							
							Console.WriteLine(" TICKER: " + newStock.SymbolTicker + " @ $" +
									newStock.Price + " created on " + 
							                  newStock.CreatedOn);
							
							db.Stocks.Add(newStock);
						}

						db.SaveChanges();
					}

					// Clear it out before adding another batch.
					inputBuffer.Clear();
				}
			}
			
			//Populate the database 
			// using (var db = new ToglaDbContext())
			// {
			// 	//foreach (var row in excelData)				
			// 	
			// 	//var newStock = new Stock()
			// 	//db.Stocks.Add(newStock)		
			// }
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T FromRow<T>(string[] row) where T : new()
		{
			List<T> newObjects = new List<T>();
			T retval = new T();
			//Stock testStock = GetObject<Stock>(row);
			Stock stock = new Stock();
			AttributeCollection attributes = TypeDescriptor.GetAttributes(stock);
 
			/* Prints the name of the type converter by retrieving the 
			 * TypeConverterAttribute from the AttributeCollection. */
			TypeConverterAttribute myAttribute = 
				(TypeConverterAttribute)attributes[typeof(TypeConverterAttribute)];
    
			Console.WriteLine("The type conveter for this class is: " + 
			                  myAttribute.ConverterTypeName);

			return retval;
			// return newObjects;
		}
		
	}
	
	
}
