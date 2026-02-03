using GearVault.Models;

namespace GearVault.DTOs
{
    public class GearDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public HardWareCategory HardWareCategory { get; set; }
        public HardWareStatus HardWareStatus { get; set; }
        public string? Specs { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public decimal? PurchasePrice { get; set; }
        public DateOnly? PurchaseDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
