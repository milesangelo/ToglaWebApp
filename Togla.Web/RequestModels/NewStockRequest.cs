using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Togla.Web.RequestModels
{
	public class NewStockRequest
	{
		public string SymbolTicker { get; set; }
		public decimal Price { get; set; }
	}
}
