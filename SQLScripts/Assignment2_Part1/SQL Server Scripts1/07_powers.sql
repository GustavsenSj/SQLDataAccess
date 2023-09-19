USE SuperheroesDb;


/* Inserting values into the power table */
INSERT INTO Power(Name, Description)
VALUES 
	('Super speed', 'Lets hero move at incredible speed'),
	('Super strength', 'Lets hero display incredible feats of strength'),
	('Spider-senses', 'Warns hero of impending danger'),
	('Healing Factor', 'Lets hero regenerate damange and wounds at incredible speed');


/* Inserting values to the link table between Superhero and power tables */
INSERT INTO SuperheroPowerLink (SuperheroId, PowerId)
VALUES
	(1,1), -- The Flash gets super speed
	(2,2), -- The Hulk gets super strength
	(2,4), -- The Hulk gets Healing Factor
	(3,2), -- Spider-man gets Super strength
	(3,3), -- Spider-man gets Spider-senses
	(3,4); -- Spider-man gets Healing Factor