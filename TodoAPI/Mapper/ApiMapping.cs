using AutoMapper;
using TodoAPI.Dtos;
using TodoAPI.Models;

namespace TodoAPI.Mapper
{
    public class ApiMapping : Profile
    {
        public ApiMapping()
        {
            CreateMap<Task, TaskDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
