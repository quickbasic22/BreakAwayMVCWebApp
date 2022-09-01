namespace BreakAwayMVCWebApp.Models
{
    public class Lodging
    {
        public int LodgingId { get; set; }
        public string LodgingName { get; set; } = null!;
        public string Owner { get; set; } = null!;
        public bool IsResort { get; set; }
        public int LodgingDestinationId { get; set; }

        public virtual Destination LodgingDestination { get; set; } = null!;
    }
}
