using AutoMapper;
using RecipeManagement.DTO;
using RecipeManagement.Model;

namespace RecipeManagement.Automapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
           
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Recipe, RecipeDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Ratings, opt => opt.MapFrom(src => src.Ratings))
                .ReverseMap();
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Logging, LoggingDto>().ReverseMap();

           
        }
    }
}
