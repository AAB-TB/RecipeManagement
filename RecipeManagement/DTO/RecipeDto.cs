﻿namespace RecipeManagement.DTO
{
    public class RecipeDto
    {
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string ImagePath { get; set; }

        // You might want to add properties for Category and User information
        public CategoryDto Category { get; set; }
        public UserDto User { get; set; }
    }
}
