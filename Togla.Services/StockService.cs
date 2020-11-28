using System;
using System.Collections.Generic;
using System.Linq;
using Togla.Data;
using Togla.Data.Models;

namespace Togla.Services
{
	/// <summary>
	/// 
	/// </summary>
    public class StockService : IStockService
    {
	    /// <summary>
	    /// 
	    /// </summary>
		private ToglaDbContext _db;

        /// <summary>
        /// 
        /// </summary>
        public StockService(ToglaDbContext db) 
        {
			_db = db;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="stock"></param>
		public void AddStock(Stock stock)
		{
			_db.Add(stock);
			_db.SaveChanges();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="stockId"></param>
		/// <exception cref="InvalidOperationException"></exception>
		public void DeleteStock(int stockId)
		{
			var stock = _db.Stocks.Find(stockId);
			if (stock == null)
			{
				throw new InvalidOperationException(
					$"Can't delete stock {stockId} because does not exist");				
			}
			
			_db.Remove(stock);
			_db.SaveChanges();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<Stock> GetAllStocks()
		{
			return _db.Stocks.ToList();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="stockId"></param>
		/// <returns></returns>
		public Stock GetStock(int stockId)
		{
			var stock = _db.Stocks.First(stock => stock.Id == stockId);

			return stock;
		}
	}
}
