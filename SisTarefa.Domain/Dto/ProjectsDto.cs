using SisTarefa.Domain.Entities;

namespace SisTarefa.Domain.Dto
{
    public class ProjectsDto
    {
        public int UsersId { get; set; }
        public string? Name { get; private set; }
        public List<Tasks> Tasks { get; set; }
    }
}
