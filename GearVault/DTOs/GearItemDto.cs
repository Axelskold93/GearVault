using GearVault.Models;

namespace GearVault.DTOs
{
    public class GearItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public HardWareCategory HardWareCategory { get; set; }
        public HardWareStatus HardWareStatus { get; set; }
    }
}
