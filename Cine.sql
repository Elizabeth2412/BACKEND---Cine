USE DB_CINE


CREATE TABLE pelicula(
	id_pelicula int PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(150) NOT NULL,
	duracion TIME(2) NOT NULL
);

CREATE TABLE sala_cine(
	id_sala int PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(150) NOT NULL,
	estado VARCHAR(10) NOT NULL	
);

CREATE TABLE pelicula_salacine(
	id_pelicula_sala int PRIMARY KEY IDENTITY(1,1),
	id_sala_cine INT FOREIGN KEY REFERENCES sala_cine(id_sala),
	fecha_publicacion DATETIME,
	fecha_fin DATETIME,
	id_pelicula INT FOREIGN KEY REFERENCES pelicula(id_pelicula)
);

ALTER TABLE pelicula_salacine ALTER COLUMN fecha_publicacion DATE
ALTER TABLE pelicula_salacine ALTER COLUMN fecha_fin DATE


INSERT INTO pelicula (nombre, duracion) VALUES ('Avengers','1:30:00')
SELECT * FROM pelicula

-- STORES PROCEDURES DE PELICULA  ---

CREATE PROCEDURE sp_listapelicula 
AS
BEGIN
SELECT
	a.id_Pelicula,
	a.nombre,
	a.duracion
FROM pelicula AS a
END
GO

ALTER PROCEDURE sp_buscarpelicula 
	@nombre VARCHAR(60)
AS
BEGIN
SELECT
	a.id_Pelicula,
	a.nombre,
	a.duracion
FROM pelicula AS a
WHERE LOWER(a.nombre) = LOWER(@nombre)
END


CREATE PROCEDURE sp_crearpelicula
	@nombre VARCHAR(60),
	@duracion TIME(2)
AS
BEGIN
INSERT INTO pelicula
	(nombre,duracion)
	VALUES
	(@nombre,@duracion)
END


CREATE PROCEDURE sp_editarpelicula
	@id_pelicula int,
	@nombre VARCHAR(60),
	@duracion TIME(2)
AS
BEGIN
UPDATE pelicula SET
	nombre = @nombre,
	duracion = @duracion
WHERE id_pelicula = @id_pelicula
END


CREATE PROCEDURE sp_eliminarpelicula
	@id_pelicula int
AS
BEGIN
	DELETE FROM pelicula WHERE id_pelicula = @id_pelicula
END


CREATE OR ALTER PROCEDURE sp_buscarpeliculafecha
	@fechapublicacion DATE
AS
BEGIN
SELECT
	b.id_pelicula_sala,
	a.id_pelicula,
	a.nombre,
	b.fecha_publicacion,
	b.fecha_fin,
	b.id_sala_cine
FROM pelicula AS a
INNER JOIN pelicula_salacine AS b ON a.id_pelicula = b.id_pelicula
WHERE b.fecha_publicacion = @fechapublicacion
END;

EXEC sp_buscarpeliculafecha '2027/02/12'

SELECT * FROM pelicula_salacine


ALTER PROCEDURE sp_buscarsalacine
    @nombresala VARCHAR(50)
AS 
BEGIN
    SELECT 
        a.id_sala,
        a.nombre AS nombre,
        c.id_pelicula,
        c.nombre AS nombre_pelicula,
		c.duracion,
		b.id_pelicula_sala,
		b.fecha_fin,
		b.fecha_publicacion,
		b.id_sala_cine
    FROM pelicula_salacine AS b 
    INNER JOIN sala_cine AS a ON a.id_sala = b.id_sala_cine
    INNER JOIN pelicula AS c ON c.id_pelicula = b.id_pelicula_sala
    WHERE a.nombre = @nombresala;
END;




INSERT INTO sala_cine (nombre, estado) values ('SalaNorte','A')
INSERT INTO sala_cine (nombre, estado) values ('SalaEste','A')
INSERT INTO sala_cine (nombre, estado) values ('SalaSur','I')

SELECT * FROM sala_cine

SELECT * FROM pelicula

SELECT * FROM pelicula_salacine

INSERT INTO pelicula_salacine(id_sala_cine,id_pelicula, fecha_publicacion, fecha_fin)
			values ('1','5','2027/2/12','2028/2/12')

INSERT INTO pelicula_salacine(id_sala_cine,id_pelicula, fecha_publicacion, fecha_fin)
			values ('2','7','2022/7/15','2024/4/2')

INSERT INTO pelicula_salacine(id_sala_cine,id_pelicula, fecha_publicacion, fecha_fin)
			values ('1','4','2021/9/11','2021/12/10')


INSERT INTO pelicula_salacine(id_sala_cine,id_pelicula, fecha_publicacion, fecha_fin)
			values ('1','6','2026/9/11','2026/12/10')

INSERT INTO pelicula_salacine(id_sala_cine,id_pelicula, fecha_publicacion, fecha_fin)
			values ('1','7','2016/10/10','2017/12/10')

INSERT INTO pelicula_salacine(id_sala_cine,id_pelicula, fecha_publicacion, fecha_fin)
			values ('1','9','2020/9/11','2020/12/10')


CREATE PROCEDURE sp_listarsala
AS
BEGIN
SELECT * FROM sala_cine
END;