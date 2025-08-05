using AutoMapper;
using ToDo.Application.DTOs;
using ToDo.Core.Entity;
using ToDo.Core.Entity.Enums;

namespace ToDo.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            //forMember hogy tudja a title a name-nek felel meg (ha ugyanazok a nevek nincs baj)
            //mindegyik fieldnek megkell ,lehet azt is  csinalni pl title nek ne adjon vissza semmit stb
            CreateMap<ToDoItem, GetToDoItemDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));
            CreateMap<UpdateToDoItemDTO,ToDoItem>();
            CreateMap<CreateToDoItemDTO, ToDoItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ToDoStatus.ToDo));
        }
    }
}
