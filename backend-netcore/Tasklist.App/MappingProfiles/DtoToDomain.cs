using AutoMapper;
using Tasklist.Domain.DTO;
using Tasklist.Domain.Entities;

namespace Tasklist.App.MappingProfiles
{
    public class DtoToDomain : Profile
    {
        public DtoToDomain()
        {
            CreateMap<TaskDto, Task>()
                .ForMember(x => x.Id, y => y.Ignore());
        }
    }
}
