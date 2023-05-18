
using FluentValidation;
using SisTarefa.Domain.Dto;

namespace SisTarefa.Domain.Entities
{
    public class TimeTraCkers : Base
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
        public string? TimeZoneId { get; set; }
        public int TasksId { get; set; }
        public Tasks Tasks { get; set; }
        public int ColaboratorsId { get; set; }
        public Colaborators Colaborators { get; set; }

        public TimeTraCkers(DateTime startDate, DateTime endDate, string? timeZoneId)
        {
            StartDate = startDate;
            EndDate = endDate;
            TimeZoneId = timeZoneId;
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
