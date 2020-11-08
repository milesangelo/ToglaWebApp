using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Togla.Data.Models;
using Togla.Services;
using Togla.Web.RequestModels;

namespace Togla.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly ILogger<StocksController> _logger;
        private readonly IStockService _stockService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="stockService"></param>
        public StocksController(ILogger<StocksController> logger, IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            var stocks = _stockService.GetAllStocks();
            return Ok(stocks);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateStock([FromBody] NewStockRequest stockRequest)
        {
            var now = DateTime.UtcNow;
            var stock = new Stock
            {
                CreatedOn = now,
                UpdatedOn = now,
                SymbolTicker = stockRequest.SymbolTicker,
                Price = stockRequest.Price,
            };

            _stockService.AddStock(stock);

            return Ok($"Stock created: {stock.SymbolTicker} at ${stock.Price}");
        }
    }
}
