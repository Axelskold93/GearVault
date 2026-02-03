using GearVault.Models;
namespace GearVault.DTOs
{
    public record UpdateItemDto(
        int Id,
        string? Name,
        string? Brand,
        string? Model,
        HardWareCategory? HardWareCategory,
        HardWareStatus? HardWareStatus,
        string? Specs,
        string? Location,
        string? Notes,
        decimal? PurchasePrice,
        DateOnly? PurchaseDate
        );
    
}
