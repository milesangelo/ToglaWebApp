using System;
using System.Collections.Generic;
using System.Linq;
using Togla.Data;
using Togla.Data.Models;

namespace Togla.Services
{
    public class StockService : IStockService
    {
		private ToglaDbContext _db;

        /// <summary>
        /// 
        /// </summary>
        public StockService(ToglaDbContext db) 
        {
			_db = db;
        }

		public void AddStock(Stock stock)
		{
			_db.Add(stock);
			_db.SaveChanges();
		}

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

		public List<Stock> GetAllStocks()
		{
			return _db.Stocks.ToList();
		}

		public Stock GetStock(int stockId)
		{
			var stock = _db.Stocks.First(stock => stock.Id == stockId);

			return stock;
		}
	}
}
