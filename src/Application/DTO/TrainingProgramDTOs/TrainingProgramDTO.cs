using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SWD_IMS.src.Application.DTO.TaskDTOs;
using SWD_IMS.src.Application.DTO.UserDTOs;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Application.DTO.TrainingProgramDTOs
{
    public class TrainingProgramDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserDTO Mentor { get; set; } = null!;
        public List<TrainingProgramIntern> TrainingProgramInterns { get; set; } = new();
        public List<TaskDTO> Tasks { get; set; } = new();
        public List<Feedback> Feedbacks { get; set; } = new();
        public DateOnly? StartDate { get; set; }
        public int? Duration { get; set; }
    }

    public class TrainingProgramProfile : Profile
    {
        public TrainingProgramProfile()
        {
            CreateMap<TrainingProgramUpdateDTO, TrainingProgram>()
            .ForMember(dest => dest.Mentor, opt => opt.Ignore())
            .ForMember(dest => dest.TrainingProgramInterns, opt => opt.Ignore())
            .ForMember(dest => dest.Tasks, opt => opt.Ignore())
            .ForMember(dest => dest.Feedbacks, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.MentorId, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<TrainingProgramCreateDTO, TrainingProgram>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Mentor, opt => opt.Ignore())
            .ForMember(dest => dest.TrainingProgramInterns, opt => opt.Ignore())
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