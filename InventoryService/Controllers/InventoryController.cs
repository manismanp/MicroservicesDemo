using InventoryService.Data;
using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryDbContext _dbContext;

        public InventoryController(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetInventoryItems()
        {
            return Ok(_dbContext.InventoryItems.ToList());
        }

        [HttpPost]
        public IActionResult AddInventoryItem(InventoryItem item)
        {
            _dbContext.InventoryItems.Add(item);
            _dbContext.SaveChanges();
            return Ok(item);
        }
    }

}
