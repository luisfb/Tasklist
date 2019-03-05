using AutoMapper;
using Tasklist.Domain.DTO;
using Tasklist.Domain.Entities;
using Tasklist.Domain.Enumerations;

namespace Tasklist.App.MappingProfiles
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Task, TaskDto>()
                .ForMember(x => x.Concluido, y => y.MapFrom(z => z.Status == TaskStatus.Done))
                .ForMember(x => x.Erros, y => y.MapFrom(z => z.ValidationErrors));
        }
    }
}
