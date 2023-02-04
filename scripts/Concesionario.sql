create database Concesionario
go
use Concesionario
go
CREATE TABLE Marcas(
  id_marca INT NOT NULL identity(1,1) PRIMARY KEY,
  nombre nvarchar(500),
  pais nvarchar(500) ,
  anno_creacion date
  );
go
CREATE TABLE Modelos (
  id_modelo INT NOT NULL identity(1,1) PRIMARY KEY,
  id_marca INT NOT NULL ,
  modelo nvarchar(145),
  motor nvarchar(145)
  )
  go
CREATE TABLE Vehiculos (
  id_vehiculo INT NOT NULL identity(1,1) PRIMARY KEY,
  nombre VARCHAR(145),
  tipo VARCHAR(145),
  id_modelo INT
  )

  go
Alter Table Modelos add Constraint Modelos_Maracas_FK
Foreign Key(id_marca) references Marcas(id_marca)
go
Alter Table Vehiculos add Constraint Vehiculos_Modelos_FK
Foreign Key(id_modelo) references Modelos(id_modelo)
go
INSERT INTO Marcas VALUES ('SpaceX', 'EEUU', '2022-05-14');
INSERT INTO Modelos VALUES ('1', 'Dragon', 'Reactor');
INSERT INTO Vehiculos VALUES ('Star Ship', 'Cohete', '1');
