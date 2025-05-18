using AutoMapper;
using Task_Management_API.Model.Domain;
using Task_Management_API.Model.DTO;

namespace Task_Management_API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TaskManagement, TaskManagementDto>().ReverseMap();
            CreateMap<TaskManagement, AddTaskDto>().ReverseMap();
            CreateMap<TaskManagement, UpdateTaskDto>().ReverseMap();
        }
    }
}
