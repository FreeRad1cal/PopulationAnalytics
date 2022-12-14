CREATE TABLE Regions (
    Id SERIAL,
    Name VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE Persons (
    Id SERIAL,
    Identifier VARCHAR(255) NOT NULL,
    RegionId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (RegionId)
        REFERENCES Regions(Id)
        ON DELETE CASCADE
);
CREATE UNIQUE INDEX persons_region_identifier_idx ON Persons (RegionId, Identifier);

CREATE TABLE Genome (
    Id SERIAL,
    Genes VARCHAR NOT NULL, -- Contains JSON representation of a person's genes: [{Name: Gene_1, Value: 140}, {Name: Gene_2, Value: 99}...]
    PersonId INT NOT NULL,
    FOREIGN KEY (PersonId)
        REFERENCES Persons(Id)
        ON DELETE CASCADE
);
CREATE UNIQUE INDEX genome_person_idx ON Genome (PersonId);