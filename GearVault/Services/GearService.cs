using GearVault.Data;
using GearVault.Models;
using GearVault.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace GearVault.Services
{
    public class GearService
    {
        private readonly GearVaultContext _db;
        private readonly ILogger<GearService> _logger;
        private readonly IMapper _mapper;

        public GearService(GearVaultContext db, ILogger<GearService> logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }



        public async Task<List<GearItemDto>> GetAllItems()
        {
            _logger.LogInformation("Fetching all available items.");

            try
            {
                var items = await _db.GearItems
                                    .AsNoTracking()
                                    .OrderByDescending(x => x.Id)
                                    .ToListAsync();
                if (items.Count == 0)
                {
                    _logger.LogInformation("No items were found in the database.");
                }
                return _mapper.Map<List<GearItemDto>>(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch items from database.");
                throw;
            }

        }

        public async Task<GearDetailDto?> GetItemById(int id)
        {
            _logger.LogInformation("Fetching item by id {Id}.", id);

            var item = await _db.GearItems
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                _logger.LogInformation("Item with id {Id} not found.", id);
                return null;
            }

            return _mapper.Map<GearDetailDto>(item);
        }


        public async Task<GearDetailDto> CreateItem(CreateItemDto dto)
        {
            _logger.LogInformation("Creating a new gear item.");
            try
            {
                var item = _mapper.Map<GearItem>(dto);
                item.Created = DateTime.UtcNow;
                item.Updated = null;
                _db.GearItems.Add(item);
                await _db.SaveChangesAsync();
                return _mapper.Map<GearDetailDto>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create a new gear item.");
                throw;
            }
        }

        public async Task<bool> UpdateItem(UpdateItemDto dto)
        {
            _logger.LogInformation("Updating gear item with id {Id}.", dto.Id);
            try
            {
                var item = await _db.GearItems.FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (item == null)
                {
                    _logger.LogInformation("Item with id {Id} not found for update.", dto.Id);
                    return false;
                }
                _mapper.Map(dto, item);
                item.Updated = DateTime.UtcNow;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update gear item with id {Id}.", dto.Id);
                throw;
            }
        }


    
    public async Task<bool> DeleteItem(int id)
        {
            _logger.LogInformation("Deleting gear item with id {Id}.", id);
            try
            {
                var item = await _db.GearItems.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    _logger.LogInformation("Item with id {Id} not found for deletion.", id);
                    return false;
                }
                _db.GearItems.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete gear item with id {Id}.", id);
                throw;
            }
        }
    }
}
