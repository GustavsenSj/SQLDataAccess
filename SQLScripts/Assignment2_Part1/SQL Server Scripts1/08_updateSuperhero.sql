USE SuperheroesDb;


-- Updates The Flash from Barry Allen to Wally West 
UPDATE Superhero
SET Name = 'Wally West'
WHERE Name = 'Barry Allen';