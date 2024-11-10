using AutoMapper;
using Entities.DbSet;
using Entities.Dtos.Requests;

namespace FormulaOne.MappingProfiles
{
    public class RequestToDomanin : Profile
    {
        public RequestToDomanin()
        {
            CreateMap<CreateDriverAchievementRequest, Achievement>()
                .ForMember(
                    dest => dest.RaceWins,
                    opt => opt.MapFrom(src => src.Wins))
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => 1))
                .ForMember(
                    dest => dest.AddedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                ;

            CreateMap<UpdateDriverAchievementRequest, Achievement>()
                .ForMember(
                    dest => dest.RaceWins,
                    opt => opt.MapFrom(src => src.Wins))
                .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                ;

            CreateMap<CreateDriverRequest, Driver>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => 1))
                .ForMember(
                    dest => dest.AddedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                ;

            CreateMap<UpdateDriverRequest, Driver>()
                .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                ;
        }
    }
}
