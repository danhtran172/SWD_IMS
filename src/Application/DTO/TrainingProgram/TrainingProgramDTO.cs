using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SWD_IMS.src.Application.DTO.Task;
using SWD_IMS.src.Application.DTO.User;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Application.DTO
{
    public class TrainingProgramDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UserDTO Mentor { get; set; } = null!;
        public List<WorkResult> WorkResults { get; set; } = new();
        public List<TaskDTO> Tasks { get; set; } = new();
        public List<Feedback> Feedbacks { get; set; } = new();
    }

    public class TrainingProgramProfile : Profile
    {
        public TrainingProgramProfile()
        {
            CreateMap<TrainingProgramUpdateReqModel, TrainingProgram>()
            .ForMember(dest => dest.Mentor, opt => opt.Ignore())
            .ForMember(dest => dest.WorkResults, opt => opt.Ignore())
            .ForMember(dest => dest.Tasks, opt => opt.Ignore())
            .ForMember(dest => dest.Feedbacks, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            
            CreateMap<TrainingProgramCreateReqModel, TrainingProgram>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Mentor, opt => opt.Ignore())
            .ForMember(dest => dest.WorkResults, opt => opt.Ignore())
            .ForMember(dest => dest.Tasks, opt => opt.Ignore())
            .ForMember(dest => dest.Feedbacks, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<TrainingProgram, TrainingProgramDTO>()
            .ForMember(dest => dest.Mentor, opt => opt.MapFrom(src => src.Mentor))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}