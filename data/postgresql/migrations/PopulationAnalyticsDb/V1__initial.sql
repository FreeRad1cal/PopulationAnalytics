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

CREATE TABLE Genes (
    Id SERIAL,
    Name VARCHAR(255) NOT NULL,
    Value INT NOT NULL,
    PersonId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (PersonId)
        REFERENCES Persons(Id)
        ON DELETE CASCADE
);
CREATE UNIQUE INDEX genes_person_name_idx ON Genes (PersonId, Name);