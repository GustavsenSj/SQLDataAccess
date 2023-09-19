USE SuperheroesDb;

/* Creates a linking table between the Superhero and power tables */
CREATE TABLE SuperheroPowerLink (
    SuperheroId int,
    PowerId int,
    PRIMARY KEY (SuperheroId, PowerId),
    FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id),
    FOREIGN KEY (PowerId) REFERENCES Power(Id)
);
