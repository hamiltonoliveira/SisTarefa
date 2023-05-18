using AutoMapper;
using SisTarefa.Domain.Dto;
using SisTarefa.Domain.Entities;

namespace SisTarefa.Infra.Data.Mapping
{
    public class MappingConfig : Profile
    {
        public class DomainDTOMapping : Profile
        {
            public DomainDTOMapping()
            {
                CreateMap<Users, UsersDto>();
                CreateMap<UsersDto, Users>();

                CreateMap<Colaborators, ColaboratorsDto>();
                CreateMap<ColaboratorsDto, Colaborators>();

                CreateMap<Projects, ProjectsDto>();
                CreateMap<ProjectsDto, Projects>();

                CreateMap<TimeTraCkers, TimeTraCkersDto>();
                CreateMap<TimeTraCkersDto, TimeTraCkers>();

                CreateMap<Tasks, TaskDto>();
                CreateMap<TaskDto, Tasks>();
            }
        }
    }
}
