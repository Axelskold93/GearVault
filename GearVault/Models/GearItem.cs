namespace GearVault.Models
{
    public class GearItem
    {
        public int Id { get; set; }
        //Generell info
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public HardWareCategory Category { get; set; }
        public HardWareStatus Status { get; set; }

        //Detaljerad info
        public string? Specs { get; set; }
        public string Location { get; set; }
        //Noteringar kring service, byte av kylpasta osv.
        public string Notes { get; set; }

        //Ekonomi // Alla priser är i SEK
        public decimal PurchasePrice { get; set; }
        public DateOnly? PurchaseDate { get; set; }

        //Senare implementering av nuvarande värde
        //public decimal? CurrentMarketValue { get; set; }
        //public DateTime? LastMarketEvaluation { get; set; }
        //Senare relation till ValueSnapShots
        //public List<ValueSnapShot> ValueSnapShots { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; } = DateTime.UtcNow;



    }
}
