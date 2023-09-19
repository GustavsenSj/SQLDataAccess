USE SuperheroesDb;

-- Add SuperheroId column to Assistant table
ALTER TABLE Assistant
ADD SuperheroId int;

-- Create foreign key constraint
ALTER TABLE Assistant
ADD CONSTRAINT FK_Superhero_Assistant
FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id);
