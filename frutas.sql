-- Crea la base de datos
CREATE DATABASE lab_rsp
GO

-- Usar base de datos creada
USE lab_rsp
GO

-- Crear tabla frutas
CREATE TABLE frutas
(
	id int identity(1,1) not null primary key,
	nombre varchar(100), 
	peso int,
	precio float

)

GO
-- Insertar registros
INSERT INTO frutas (nombre, peso, precio)
VALUES ('Manzana', 150, 0.75),
       ('Banana', 120, 0.50),
       ('Naranja', 180, 0.60),
       ('Pera', 170, 0.80);
