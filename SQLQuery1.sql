Create database CRUD20250438
go
use CRUD20250438
go

create table peliculas(
id_pelicula int identity(1,1) primary key,
nombre varchar(50)not null,
director varchar(50) not null,
fechaLanzamiento date
);
go

INSERT INTO peliculas (nombre,director,fechaLanzamiento) VALUES('The Shawshank Redemtion','Frank Darabont','1994-09-23'),
('The Godfather','Francis Ford Coppola','1972-03-24'),
('Pulp Fiction','Quentin Tarantino','1994-10-14'),
('The Dark Knight','Christopher Nolan','2008-07-18'),
('Fight Club','Frank David Fincher','1999-10-15')

select *from peliculas