namespace BreakAwayMVCWebApp.Models
{
    public class Destination
    {
        public Destination()
        {
            Lodgings = new HashSet<Lodging>();
        }

        public int DestinationId { get; set; }
        public string DestinationName { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Description { get; set; } = null!;
        public byte[]? Photo { get; set; }

        public virtual ICollection<Lodging> Lodgings { get; set; }
    }
}
