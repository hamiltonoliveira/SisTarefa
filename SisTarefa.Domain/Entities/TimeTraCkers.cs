
using FluentValidation;
using SisTarefa.Domain.Dto;

namespace SisTarefa.Domain.Entities
{
    public class TimeTraCkers : Base
    {
        public int UsersId { get; set; }
        public Users Users { get; set; }
        public List<Tasks> Tasks { get; set; }
        public List<Colaborators> Colaborators { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
        public string? TimeZoneId { get; set; }
       
        public TimeTraCkers(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Tasks = new List<Tasks>();
            Colaborators = new List<Colaborators>();
            SetTimeZoneId();
        }
        void SetTimeZoneId()
        {
            var fusosHorarios = TimeZoneInfo.GetSystemTimeZones();
            foreach (var fusoHorario in fusosHorarios)
            {
                TimeZoneId =fusoHorario.Id;
            }

        }
    }
}
