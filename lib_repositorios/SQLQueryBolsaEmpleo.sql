--Crear la base de datos
CREATE DATABASE BolsaDeEmpleo;
go

--Usar la base de datos
USE BolsaDeEmpleo;
go

--Crear las tablas
CREATE TABLE Roles( --Tabla Roles
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	Nombre NVARCHAR(100) NOT NULL
);
go

CREATE TABLE Empresas( --Tabla Empresas
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	Cod_empresa INT NOT NULL,
	Nombre NVARCHAR(100) NOT NULL,
	Direccion NVARCHAR(100),
	Rol_id INT NOT NULL,
	
	FOREIGN KEY (Rol_id) REFERENCES Roles(Id)
);
go

CREATE TABLE Personas( --Tabla Personas
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Cedula NVARCHAR(10) NOT NULL,
	Nombre NVARCHAR(100) NOT NULL,
	Direccion NVARCHAR(100),
	Rol_id INT NOT NULL,
	
	FOREIGN KEY (Rol_id) REFERENCES Roles(Id)
);
go

CREATE TABLE Estudios( --Tabla Estudios
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Cod_estudio INT NOT NULL,
	Nombre NVARCHAR(100) NOT NULL
);
go

CREATE TABLE Cargos( --Tabla Cargos
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre NVARCHAR(100) NOT NULL
);
go

CREATE TABLE Personas_Estudios( --Tabla Personas_Estudios
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Persona_id INT NOT NULL,
	Estudio_id INT NOT NULL,

	FOREIGN KEY (Persona_id) REFERENCES Personas(Id),
	FOREIGN KEY (Estudio_id) REFERENCES Estudios(Id)
);
go

CREATE TABLE Cargos_Estudios( --Tabla Cargos_Estudios 
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Cargo_id INT NOT NULL,
	Estudio_id INT NOT NULL,

	FOREIGN KEY (Cargo_id) REFERENCES Cargos(Id),
	FOREIGN KEY (Estudio_id) REFERENCES Estudios(Id)
);
go

CREATE TABLE Vacantes( --Tabla Vacantes
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Empresa_id INT NOT NULL,
	Cargo_id INT NOT NULL,
	Disponibilidad BIT NOT NULL DEFAULT 0,

	FOREIGN KEY (Empresa_id) REFERENCES Empresas(Id),
	FOREIGN KEY (Cargo_id) REFERENCES Cargos(Id)
);
go

CREATE TABLE Postulaciones( --Tabla Postulaciones
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Vacante_id INT NOT NULL,
	Persona_id INT NOT NULL,
	Elegido BIT NOT NULL DEFAULT 0,
	
	FOREIGN KEY (Vacante_id) REFERENCES Vacantes(Id),
	FOREIGN KEY (Persona_id) REFERENCES Personas(Id)
);
go

CREATE TABLE Auditorias( --Tabla Auditorias
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nom_Entidad NVARCHAR(100) NOT NULL,
	Entidad_id INT NOT NULL,
	Accion INT NOT NULL
);
go

--Validando que las tablas hayan sido creadas correctamente
SELECT * FROM Empresas;
SELECT * FROM Personas;
SELECT * FROM Estudios;
SELECT * FROM Cargos;
SELECT * FROM Personas_Estudios;
SELECT * FROM Cargos_Estudios;
SELECT * FROM Vacantes;
SELECT * FROM Postulaciones;

--Insertando valores en cada una de las tablas
INSERT INTO Roles (Nombre)
VALUES ('Empresa'),
	   ('Persona');
GO

INSERT INTO Empresas (Cod_empresa, Nombre, Direccion, Rol_id)
VALUES (111,'Exito','Calle 4',1);
GO

INSERT INTO Cargos (Nombre)
VALUES ('Desarrollador');
GO

INSERT INTO Vacantes (Empresa_id,Cargo_id,Disponibilidad)
VALUES (1,1,1);
GO

INSERT INTO Personas (Cedula,Nombre,Direccion, Rol_id)
VALUES ('1010','Julian','Calle 10',2);
GO

INSERT INTO Postulaciones(Persona_id,Vacante_id,Elegido)
VALUES (1,1,1);
GO

INSERT INTO Estudios(Cod_estudio,Nombre)
VALUES (1,'Ingenieria');
GO

INSERT INTO Personas_Estudios(Persona_id,Estudio_id)
VALUES (1,1);
GO

INSERT INTO Cargos (Nombre)
VALUES ('Desarrollador');
GO

INSERT INTO Cargos_Estudios(Estudio_id,Cargo_id)
VALUES (1,1);
GO

--La tabla de auditorias sera llenada desde el SERVICIO