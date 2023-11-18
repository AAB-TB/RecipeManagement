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
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();


            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();


            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<Recipe, CreateRecipeDto>().ReverseMap();
            CreateMap<Recipe, UpdateRecipeDto>().ReverseMap();

            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Rating, CreateRatingDto>().ReverseMap();
            CreateMap<Rating, UpdateRatingDto>().ReverseMap();




        }
    }
}
