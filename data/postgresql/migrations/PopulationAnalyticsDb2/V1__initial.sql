CREATE TABLE Regions (
    Id INT NOT NULL,
    Name VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE Persons (
    Id INT NOT NULL,
    Identifier VARCHAR(255) NOT NULL,
    RegionId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (RegionId)
        REFERENCES Regions(Id)
        ON DELETE CASCADE
);
CREATE UNIQUE INDEX persons_region_identifier_idx ON Persons (RegionId, Identifier);

CREATE TABLE Genome (
    Id INT NOT NULL,
    Genes VARCHAR NOT NULL,
    PersonId INT NOT NULL,
    FOREIGN KEY (PersonId)
        REFERENCES Persons(Id)
        ON DELETE CASCADE
);
CREATE UNIQUE INDEX genome_person_idx ON Genome (PersonId);