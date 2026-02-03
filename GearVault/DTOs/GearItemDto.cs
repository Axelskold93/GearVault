using GearVault.Models;

namespace GearVault.DTOs
{
    public class GearItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public HardWareCategory Category { get; set; }
        public HardWareStatus Status { get; set; }
    }
}
