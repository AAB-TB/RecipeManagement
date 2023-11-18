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
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<Rating, RatingDto>().ReverseMap();

            
        }
    }
}
