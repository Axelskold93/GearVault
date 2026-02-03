using GearVault.Models;

namespace GearVault.DTOs
{
    public class GearDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public HardWareCategory Category { get; set; }
        public HardWareStatus Status { get; set; }
        public string? Specs { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public decimal PurchasePrice { get; set; }
        public DateOnly? PurchaseDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
