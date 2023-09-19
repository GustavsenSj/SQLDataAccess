USE SuperheroesDb;

-- Creates Superhero table
CREATE TABLE Superhero (
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50) NOT NULL,
	Alias nvarchar(50),
	Origin nvarchar(200)
)

-- Creates Assistant table
CREATE TABLE Assistant (
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50) NOT NULL,
)

-- Creates power table
CREATE TABLE power (
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(150)
)