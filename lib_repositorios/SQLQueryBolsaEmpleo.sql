--Crear la base de datos
CREATE DATABASE BolsaDeEmpleo;
go

--Usar la base de datos
USE BolsaDeEmpleo;
go

--Crear las tablas
CREATE TABLE Roles( --Tabla Roles
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	nombre NVARCHAR(100) NOT NULL
);
go

CREATE TABLE Empresas( --Tabla Empresas
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	cod_empresa INT NOT NULL,
	nombre NVARCHAR(100) NOT NULL,
	direccion NVARCHAR(100),
	rol_id INT NOT NULL,
	
	FOREIGN KEY (rol_id) REFERENCES Roles(id)
);
go

CREATE TABLE Personas( --Tabla Personas
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	cedula NVARCHAR(10) NOT NULL,
	nombre NVARCHAR(100) NOT NULL,
	direccion NVARCHAR(100),
	rol_id INT NOT NULL,
	
	FOREIGN KEY (rol_id) REFERENCES Roles(id)
);
go

CREATE TABLE Estudios( --Tabla Estudios
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	cod_estudio INT NOT NULL,
	nombre NVARCHAR(100) NOT NULL
);
go

CREATE TABLE Cargos( --Tabla Cargos
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	nombre NVARCHAR(100) NOT NULL
);
go

CREATE TABLE Personas_Estudios( --Tabla Personas_Estudios
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	persona_id INT NOT NULL,
	estudio_id INT NOT NULL,

	FOREIGN KEY (persona_id) REFERENCES Personas(id),
	FOREIGN KEY (estudio_id) REFERENCES Estudios(id)
);
go

CREATE TABLE Cargos_Estudios( --Tabla Cargos_Estudios 
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	cargo_id INT NOT NULL,
	estudio_id INT NOT NULL,

	FOREIGN KEY (cargo_id) REFERENCES Cargos(id),
	FOREIGN KEY (estudio_id) REFERENCES Estudios(id)
);
go

CREATE TABLE Vacantes( --Tabla Vacantes
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	empresa_id INT NOT NULL,
	cargo_id INT NOT NULL,
	disponibilidad BIT NOT NULL DEFAULT 0,

	FOREIGN KEY (empresa_id) REFERENCES Empresas(id),
	FOREIGN KEY (cargo_id) REFERENCES Cargos(id)
);
go

CREATE TABLE Postulaciones( --Tabla Postulaciones
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	vacante_id INT NOT NULL,
	persona_id INT NOT NULL,
	elegido BIT NOT NULL DEFAULT 0,
	
	FOREIGN KEY (vacante_id) REFERENCES Vacantes(id),
	FOREIGN KEY (persona_id) REFERENCES Personas(id)
);
go

CREATE TABLE Auditorias( --Tabla Auditorias
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	nom_Entidad NVARCHAR(100) NOT NULL,
	entidad_id INT NOT NULL,
	accion_id INT NOT NULL,
	
	FOREIGN KEY (accion_id) REFERENCES Acciones(id)
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
INSERT INTO Roles (nombre)
VALUES ('Empresa'),
	   ('Persona');
GO

INSERT INTO Empresas (cod_empresa, nombre, direccion, rol_id)
VALUES (111,'Exito','Calle 4',1);
GO

INSERT INTO Cargos (nombre)
VALUES ('Desarrollador');
GO

INSERT INTO Vacantes (empresa_id,cargo_id,disponibilidad)
VALUES (1,1,1);
GO

INSERT INTO Personas (cedula,nombre,direccion, rol_id)
VALUES ('1010','Julian','Calle 10',2);
GO

INSERT INTO Postulaciones(persona_id,vacante_id,elegido)
VALUES (1,1,1);
GO

INSERT INTO Estudios(cod_estudio,nombre)
VALUES (1,'Ingenieria');
GO

INSERT INTO Personas_Estudios(persona_id,estudio_id)
VALUES (1,1);
GO

INSERT INTO Cargos (nombre)
VALUES ('Desarrollador');
GO

INSERT INTO Cargos_Estudios(estudio_id,cargo_id)
VALUES (1,1);
GO

--La tabla de auditorias sera llenada desde el SERVICIO