-- Create Users table with unique constraint on email
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(255) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL, -- Assuming you'll store hashed passwords
    EncryptedPassword VARBINARY(MAX), -- Example for data encryption
    Email VARCHAR(255) NOT NULL,
    Role VARCHAR(50) NOT NULL DEFAULT 'User', -- User role by default
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT UC_Email UNIQUE (Email),
    CONSTRAINT CK_UserRole CHECK (Role IN ('User', 'Admin'))
);

-- Create Categories table
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(255) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE()
);

-- Create Recipes table with ImagePath
CREATE TABLE Recipes (
    RecipeId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    Ingredients TEXT,
    CategoryId INT,
    ImagePath VARCHAR(255),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

-- Create Ratings table
CREATE TABLE Ratings (
    RatingId INT PRIMARY KEY IDENTITY(1,1),
    RecipeId INT,
    UserId INT,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (RecipeId) REFERENCES Recipes(RecipeId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Create Logging table
CREATE TABLE Logging (
    LogId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT, -- Add UserId if you want to associate logs with users
    LogMessage TEXT,
    LogLevel VARCHAR(20), -- Info, Warning, Error, etc.
    CreatedAt DATETIME2 DEFAULT GETDATE()
);

-- Index foreign key columns for better performance
CREATE INDEX IX_Recipes_UserId ON Recipes (UserId);
CREATE INDEX IX_Recipes_CategoryId ON Recipes (CategoryId);
CREATE INDEX IX_Ratings_RecipeId ON Ratings (RecipeId);
CREATE INDEX IX_Ratings_UserId ON Ratings (UserId);