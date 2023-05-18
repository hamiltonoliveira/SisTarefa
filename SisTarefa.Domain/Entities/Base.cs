namespace SisTarefa.Domain.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DeletedAt { get; set; } = new DateTime(2000, 1, 1);
    }
}
