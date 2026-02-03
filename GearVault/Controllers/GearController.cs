using GearVault.Data;
using GearVault.Models;
using Microsoft.AspNetCore.Mvc;
using GearVault.DTOs;
using GearVault.Services;

namespace GearVault.Controllers
{
    [Route("api/gear")]
    [ApiController]
    public class GearController : ControllerBase
    {
        private readonly ILogger<GearController> _logger;
        private readonly GearService _service;
        public GearController(GearVaultContext? db, ILogger<GearController> logger, GearService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("gearitems")]
        public async Task<ActionResult<IEnumerable<GearItemDto>>> GetAllItems()
        {
            _logger.LogInformation("Fetching all available items...");
            try
            {
                var items = await _service.GetAllItems();
                return items;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve items.");
                return BadRequest();
            }
        }

        [HttpGet("gearitem")]
        public async Task<ActionResult<GearDetailDto>> GetItemById(int id)
        {
            _logger.LogInformation("Fetching item with matching Id.");
            try
            {
                var item = await _service.GetItemById(id);
                if (item != null)
                {
                    return item;
                }
                return NotFound("No item with that ID was found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to fetch item.");
                return BadRequest();
            }
        }
        [HttpPost("create/gearitem")]
        public async Task<ActionResult<GearDetailDto>> CreateItem(CreateItemDto dto)
        {
            _logger.LogInformation("Creating a new gear item...");
            try
            {
                var createdItem = await _service.CreateItem(dto);
                return CreatedAtAction(nameof(GetItemById), new { id = createdItem.Id }, createdItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create new gear item.");
                return BadRequest();
            }
        }
    }
}
