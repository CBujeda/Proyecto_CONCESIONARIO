Drop database if exists Concesionario;
go
create database Concesionario
go
use Concesionario
go
Drop table if exists Marcas;
go
CREATE TABLE Marcas(
  id_marca INT NOT NULL identity(1,1) PRIMARY KEY,
  nombre nvarchar(500),
  pais nvarchar(500) ,
  anno_creacion date
  );
go
Drop table if exists Modelos;
go
CREATE TABLE Modelos (
  id_modelo INT NOT NULL identity(1,1) PRIMARY KEY,
  id_marca INT NOT NULL ,
  modelo nvarchar(145),
  motor nvarchar(145)
  )
  go
  Drop table if exists Vehiculos;
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
INSERT INTO Marcas (nombre, pais, anno_creacion)
VALUES 
  ('SpaceX', 'EEUU', '2012-10-04'),
  ('ApoloXII', 'EEUU', '2022-05-14'),
  ('Halcon Milenario', 'Inframundo', '1920-07-09'),
  ('NASA', 'Estados Unidos', '1958-07-29'),
  ('Roscosmos', 'Rusia', '1992-03-25'),
  ('ESA', 'Europa', '1975-05-30'),
  ('JAXA', 'Japón', '2003-10-01'),
  ('ISRO', 'India', '1969-08-15'),
  ('CNSA', 'China', '1993-09-25'),
  ('SpaceX', 'Estados Unidos', '2002-03-24'),
  ('Blue Origin', 'Estados Unidos', '2000-09-01'),
  ('Boeing', 'Estados Unidos', '1916-07-15'),
  ('Lockheed Martin', 'Estados Unidos', '1912-07-01'),
  ('Northrop Grumman', 'Estados Unidos', '1939-12-06'),
  ('ArianeGroup', 'Europa', '1973-01-01'),
  ('Airbus Defence and Space', 'Europa', '2014-01-01'),
  ('RUAG Space', 'Suiza', '1917-01-01'),
  ('Thales Alenia Space', 'Europa', '2015-01-01'),
  ('Surrey Satellite Technology', 'Reino Unido', '1985-01-01'),
  ('GK Launch Services', 'Rusia', '2013-01-01'),
  ('Astrium', 'Europa', '2000-07-01'),
  ('Orbital Sciences Corporation', 'Estados Unidos', '1982-10-01'),
  ('SpaceDev', 'Estados Unidos', '1997-01-01'),
  ('Virgin Galactic', 'Reino Unido', '2004-06-28'),
  ('ULA', 'Estados Unidos', '2006-12-10'),
  ('Arianespace', 'Europa', '1980-06-08'),
  ('SNC-Lavalin', 'Canadá', '1911-06-01'),
  ('Intelsat', 'Luxemburgo', '1964-08-20'),
  ('SSL', 'Estados Unidos', '1957-01-01'),
  ('China Great Wall Industry Corporation', 'China', '1980-09-17'),
  ('Almaz-Antey', 'Rusia', '2002-02-01'),
  ('Mitsubishi Heavy Industries', 'Japón', '1954-01-01'),
  ('Khrunichev State Research and Production Space Center', 'Rusia', '1916-07-01');

go
INSERT INTO Modelos 
VALUES 
  (1, 'Space Shuttle', 'Solid Rocket Booster'),
  (2, 'Soyuz', 'RD-107A'),
  (3, 'Ariane 5', 'Vinci'),
  (4, 'Falcon 9', 'Merlin'),
  (5, 'Dragon', 'SuperDraco'),
  (6, 'Atlas V', 'RD-180'),
  (7, 'Delta IV', 'RS-68');

INSERT INTO Vehiculos 
VALUES 
  ('Endeavour', 'Space Shuttle', 1),
  ('Discovery', 'Space Shuttle', 1),
  ('Atlantis', 'Space Shuttle', 1),
  ('Columbia', 'Space Shuttle', 1),
  ('Soyuz MS-10', 'Soyuz', 2),
  ('Soyuz MS-11', 'Soyuz', 2),
  ('Ariane 5 VA241', 'Ariane 5', 3),
  ('Ariane 5 ES', 'Ariane 5', 3),
  ('Falcon 9 FT', 'Falcon 9', 4),
  ('Dragon 2', 'Dragon', 5),
  ('Dragon XL', 'Dragon', 5),
  ('Atlas V 401', 'Atlas V', 6),
  ('Atlas V 551', 'Atlas V', 6),
  ('Delta IV Heavy', 'Delta IV', 7),
  ('Delta IV Medium+ (5,2)', 'Delta IV', 7),
  ('Delta IV Medium+ (5,4)', 'Delta IV', 7),
  ('Delta IV Medium+ (4,2)', 'Delta IV', 7);