namespace SisTarefa.Domain.Dto
{
    public class TimeTraCkersDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TimeZoneId { get; set; }
        public List<string> Task { get; set; }
    }
}
