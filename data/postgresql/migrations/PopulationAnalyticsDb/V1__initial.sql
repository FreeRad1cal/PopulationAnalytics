﻿CREATE TABLE Countries (
    Id INT NOT NULL,
    Name VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE Persons (
    Id INT NOT NULL,
    Identifier VARCHAR(255) NOT NULL,
    CountryId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (CountryId)
        REFERENCES Countries(Id)
        ON DELETE CASCADE
);
CREATE INDEX persons_country_idx ON Persons (CountryId);
CREATE UNIQUE INDEX persons_identifier_idx ON Persons (Identifier);

CREATE TABLE Genes (
    Id INT NOT NULL,
    Name VARCHAR(255) NOT NULL,
    Value INT NOT NULL,
    PersonId INT NOT NULL,
    FOREIGN KEY (PersonId)
        REFERENCES Persons(Id)
        ON DELETE CASCADE
);
CREATE UNIQUE INDEX genes_person_name_idx ON Genes (PersonId, Name);