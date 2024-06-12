create database PruebaAfp

use PruebaAfp
CREATE TABLE Empresas (
    Id INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    RazonSocial NVARCHAR(150),
    FechaRegistro DATETIME,
);
CREATE TABLE Departamentos (
    Id INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    NumeroEmpleados INT,
    NivelOrganizacion NVARCHAR(100),
    IdEmpresa INT,
    FOREIGN KEY (IdEmpresa) REFERENCES Empresas(Id)
);
CREATE PROCEDURE sp_ObtenerEmpresaPorID
    @ID INT
AS
BEGIN
    SELECT 
        ID,
        Nombre,
        RazonSocial,
        FechaRegistro,
        LogDetails
    FROM Empresas
    WHERE ID = @ID;
END;


 CREATE PROCEDURE sp_RegistrarEmpresa
    @ID INT,
    @Nombre NVARCHAR(100),
    @RazonSocial NVARCHAR(150),
    @FechaRegistro DATETIME,
    @LogDetails NVARCHAR(MAX)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Empresas WHERE ID = @ID)
    BEGIN
        UPDATE Empresas
        SET Nombre = @Nombre,
            RazonSocial = @RazonSocial,
            FechaRegistro = @FechaRegistro,
            LogDetails = @LogDetails
        WHERE ID = @ID;
    END
    ELSE
    BEGIN
        INSERT INTO Empresas (ID, Nombre, RazonSocial, FechaRegistro, LogDetails)
        VALUES (@ID, @Nombre, @RazonSocial, @FechaRegistro, @LogDetails);
    END
END


CREATE PROCEDURE ObtenerDepartamentosPorIdEmpresa
    @IdEmpresa INT
AS
BEGIN
    SELECT *
    FROM Departamentos
    WHERE IdEmpresa = @IdEmpresa;
END;