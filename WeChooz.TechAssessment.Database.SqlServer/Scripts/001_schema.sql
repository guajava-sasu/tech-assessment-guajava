
IF OBJECT_ID(N'dbo.Formateurs', N'U') IS NULL
BEGIN
CREATE TABLE Formateurs (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nom NVARCHAR(100) NOT NULL,
    Prenom NVARCHAR(100) NOT NULL,
    CONSTRAINT UQ_Formateur_NomPrenom UNIQUE (Nom, Prenom)
);
END;

IF OBJECT_ID(N'dbo.Cours', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Cours (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Nom NVARCHAR(255) NOT NULL,
        DescriptionCourte NVARCHAR(500) NOT NULL,
        DescriptionLongueMarkdown NVARCHAR(MAX) NOT NULL,
        DureeEnJours INT NOT NULL,
        CapaciteMaximale INT NOT NULL,
        IdModeDelivrance INT NOT NULL,
        IdFormateur INT,
        DateCreation DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (IdFormateur) REFERENCES Formateurs(Id),
        FOREIGN KEY (IdModeDelivrance) REFERENCES ModeDelivrance(Id)
    );
END;

IF OBJECT_ID(N'dbo.Participants', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Participants (
        Id INT PRIMARY KEY IDENTITY(1,1),   
        Nom NVARCHAR(100) NOT NULL,
        Prenom NVARCHAR(100) NOT NULL,
        Email NVARCHAR(255) NOT NULL,
        NomEntreprise NVARCHAR(255) NOT NULL,
        DateCreation DATETIME DEFAULT GETDATE(),
        CONSTRAINT UQ_Email UNIQUE (Email)
    );
END;

IF OBJECT_ID(N'dbo.ModeDelivrance', N'U') IS NULL
BEGIN
CREATE TABLE ModeDelivrance (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Libelle NVARCHAR(50) NOT NULL,
    CONSTRAINT UQ_ModeDelivrance_Libelle UNIQUE (Libelle)
);

INSERT INTO ModeDelivrance (Libelle) VALUES ('Présentiel');
INSERT INTO ModeDelivrance (Libelle) VALUES ('À distance');

END;
IF OBJECT_ID(N'dbo.PopulationCible', N'U') IS NULL
BEGIN
CREATE TABLE PopulationCible (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Libelle NVARCHAR(50) NOT NULL,
    CONSTRAINT UQ_PopulationCible_Libelle UNIQUE (Libelle)
);

INSERT INTO PopulationCible (Libelle) VALUES ('Élu');
INSERT INTO PopulationCible (Libelle) VALUES ('Président de CSE');
END;
IF OBJECT_ID(N'dbo.Sessions', N'U') IS NULL
BEGIN
CREATE TABLE Sessions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdCours INT NOT NULL,
    IdModeDelivrance INT NOT NULL,
    DateDebut DATETIME NOT NULL,
    DateFin DATETIME NOT NULL,
    Lieu NVARCHAR(255),
    NombrePlacesMax INT NOT NULL,
    NombrePlacesRestantes INT NOT NULL,
    FOREIGN KEY (IdCours) REFERENCES Cours(Id),
    FOREIGN KEY (IdModeDelivrance) REFERENCES ModeDelivrance(Id),
    CONSTRAINT CHK_Date CHECK (DateDebut < DateFin),
    CONSTRAINT CHK_Places CHECK (NombrePlacesRestantes <= NombrePlacesMax)
);

END;

IF OBJECT_ID(N'dbo.CoursPopulationCible', N'U') IS NULL
BEGIN
CREATE TABLE CoursPopulationCible (
    IdCours INT NOT NULL,
    IdPopulationCible INT NOT NULL,
    PRIMARY KEY (IdCours, IdPopulationCible),
    FOREIGN KEY (IdCours) REFERENCES Cours(Id) ON DELETE CASCADE,
    FOREIGN KEY (IdPopulationCible) REFERENCES PopulationCible(Id) ON DELETE CASCADE
);
END;

IF OBJECT_ID(N'dbo.SessionsPopulationCible', N'U') IS NULL
BEGIN
CREATE TABLE SessionsPopulationCible (
    IdSession INT NOT NULL,
    IdPopulationCible INT NOT NULL,
    PRIMARY KEY (IdSession, IdPopulationCible),
    FOREIGN KEY (IdSession) REFERENCES dbo.Sessions(Id) ON DELETE CASCADE,
    FOREIGN KEY (IdPopulationCible) REFERENCES PopulationCible(Id) ON DELETE CASCADE
);
END;
