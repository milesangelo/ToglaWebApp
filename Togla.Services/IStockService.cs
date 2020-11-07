using System.Collections.Generic;
using Togla.Data.Models;

namespace Togla.Services
{
	public interface IStockService
	{
		void AddStock(Stock stock);
		void DeleteStock(int stockId);
		List<Stock> GetAllStocks();
		Stock GetStock(int stockId);

	}
}