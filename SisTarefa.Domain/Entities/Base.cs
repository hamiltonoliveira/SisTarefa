namespace SisTarefa.Domain.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime DeletedAt { get; private set; }
        void SetDeletar() => DeletedAt = DateTime.UtcNow;
    }
}
