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
        /// Get all stocks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            var stocks = _stockService.GetAllStocks();
            return Ok(stocks);
        }

        /// <summary>
        /// Gets the stock at the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult GetStock(int id)
        {
            var stock = _stockService.GetAllStocks()
                .Find(s => s.Id == id);

            return Ok(stock);
        }

        /// <summary>
        /// Creates a single stock object.
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

        /// <summary>
        /// Saves a list of stock requests.
        /// </summary>
        /// <param name="stockRequests"></param>
        /// <returns></returns>
        [HttpPost("range")]
        public ActionResult CreateStock([FromBody] List<NewStockRequest> stockRequests)
        {
            var returnMessage = string.Empty;
            foreach (var stock in from stockReq in stockRequests
                let now = DateTime.UtcNow
                select new Stock
                {
                    CreatedOn = now,
                    UpdatedOn = now,
                    SymbolTicker = stockReq.SymbolTicker,
                    Price = stockReq.Price,
                })
            {
                _stockService.AddStock(stock);
                returnMessage += $"Stock created: {stock.SymbolTicker} at ${stock.Price} \n";
            }

            return Ok(returnMessage);
        }

        /// <summary>
        /// Deletes the stock with given ID.
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteStock(int id)
        {
            try
            {
                _stockService.DeleteStock(id);
            }
            catch (Exception ex)
            {
                // swallow and return Problem object.
                return Problem($"There was a problem deleting stock {id}");
            }

            return Ok($"Deleted stock {id}");
        }
    }
}