using System;




namespace Togla.Data.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public decimal Price { get; set; }

        public decimal TradeSize { get; set; }

        public string SymbolTicker { get; set; }
    }
}
