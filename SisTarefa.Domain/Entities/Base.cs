namespace SisTarefa.Domain.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;
        public DateTime DeletedAt { get; private set; }
        void SetDeletar() => DeletedAt = DateTime.Now;
    }
}
