using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Application.DTO.InternDTOs
{
    public class InternDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? University { get; set; }
        public string? Major { get; set; }
        public string? Experience { get; set; }

        public List<Feedback> Feedbacks { get; set; } = new();
        public List<TrainingProgramIntern> TrainingProgramInterns { get; set; } = new();
        public List<TaskIntern> TaskInterns { get; set; } = new();
    }
    public class InternProfile : Profile
    {
        public InternProfile()
        {
            CreateMap<InternCreateDTO, Intern>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Feedbacks, opt => opt.Ignore())
            .ForMember(dest => dest.TrainingProgramInterns, opt => opt.Ignore())
            .ForMember(dest => dest.TaskInterns, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Intern, InternDTO>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InternUpdateDTO, Intern>()
            .ForMember(dest => dest.Feedbacks, opt => opt.Ignore())
            .ForMember(dest => dest.TrainingProgramInterns, opt => opt.Ignore())
            .ForMember(dest => dest.TaskInterns, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            
        }
    }
}