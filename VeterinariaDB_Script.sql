CREATE DATABASE VeterinariaDB;
GO

USE VeterinariaDB;
GO

CREATE TABLE Propietarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Direccion NVARCHAR(150) NULL
);

CREATE TABLE Especies (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);

CREATE TABLE Razas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdEspecie INT NOT NULL,
    Nombre NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_Razas_Especies FOREIGN KEY (IdEspecie) REFERENCES Especies(Id) ON DELETE CASCADE
);

CREATE TABLE Mascotas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    IdPropietario INT NOT NULL,
    IdRaza INT NOT NULL,
    FechaNacimiento DATETIME2 NULL,
    Peso DECIMAL(5,2) NULL,
    RutaFoto NVARCHAR(255) NULL,
    CONSTRAINT FK_Mascotas_Propietarios FOREIGN KEY (IdPropietario) REFERENCES Propietarios(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Mascotas_Razas FOREIGN KEY (IdRaza) REFERENCES Razas(Id) ON DELETE CASCADE
);
GO

-- Insercion de datos iniciales (Catalogos)
INSERT INTO Especies (Nombre) VALUES ('Canino'), ('Felino');

-- Razas para Canino (IdEspecie = 1)
INSERT INTO Razas (IdEspecie, Nombre) VALUES (1, 'Labrador Retriever');
INSERT INTO Razas (IdEspecie, Nombre) VALUES (1, 'Bulldog Frances');
INSERT INTO Razas (IdEspecie, Nombre) VALUES (1, 'Pastor Aleman');

-- Razas para Felino (IdEspecie = 2)
INSERT INTO Razas (IdEspecie, Nombre) VALUES (2, 'Siames');
INSERT INTO Razas (IdEspecie, Nombre) VALUES (2, 'Persa');
INSERT INTO Razas (IdEspecie, Nombre) VALUES (2, 'Maine Coon');
GO
