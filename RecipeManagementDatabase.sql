-- Users Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    UserRole NVARCHAR(20) DEFAULT 'Ordinary' CHECK (UserRole IN ('Ordinary', 'Admin')),
    CONSTRAINT Unique_Username UNIQUE (Username),
    CONSTRAINT Unique_Email UNIQUE (Email)
);

-- Categories Table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(50) NOT NULL
);

-- Recipes Table
CREATE TABLE Recipes (
    RecipeID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Ingredients NVARCHAR(MAX),
    CategoryID INT,
    UserID INT,
    ImagePath NVARCHAR(MAX),
    CONSTRAINT FK_Category FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    CONSTRAINT FK_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Ratings Table
CREATE TABLE Ratings (
    RatingID INT PRIMARY KEY IDENTITY(1,1),
    RecipeCreatorID INT, -- The user ID who created the recipe
    RatingValue INT CHECK (RatingValue >= 1 AND RatingValue <= 5),
    RatedRecipeID INT, -- The ID of the recipe being rated
    RatingUserID INT, -- The user ID who is giving the rating
    CONSTRAINT FK_RecipeCreator FOREIGN KEY (RecipeCreatorID) REFERENCES Users(UserID),
    CONSTRAINT FK_RatedRecipe FOREIGN KEY (RatedRecipeID) REFERENCES Recipes(RecipeID),
    CONSTRAINT FK_RatingUser FOREIGN KEY (RatingUserID) REFERENCES Users(UserID),
    CONSTRAINT Check_RatingUserNotRecipeCreator CHECK (RatingUserID != RecipeCreatorID)
);

-- Indexes for better query performance
CREATE INDEX idx_RecipeTitle ON Recipes (Title);
