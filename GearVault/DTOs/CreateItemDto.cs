using GearVault.Models;
using System.ComponentModel.DataAnnotations;

namespace GearVault.DTOs
{
    public class CreateItemDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public string? Model { get; set; }

        public HardWareCategory HardWareCategory { get; set; }

        public HardWareStatus HardWareStatus { get; set; }

        public string? Specs { get; set; }

        public string? Location { get; set; }

        public string? Notes { get; set; }

        public decimal? PurchasePrice { get; set; }

        public DateOnly? PurchaseDate { get; set; }
    }
}
