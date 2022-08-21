---------Creacion de DB------------
CREATE DATABASE TareasDb;
------------------------------------
------------------------------------


--Nota, utilizar la DB creada para crear las tablas
-------------Creacion de tablas--------------
CREATE TABLE colaborador(
   id INT GENERATED ALWAYS AS IDENTITY,
   nombre VARCHAR(255) NOT NULL,
   PRIMARY KEY(id)
);

CREATE TABLE estado(
   id INT GENERATED ALWAYS AS IDENTITY,
   estado VARCHAR(255) NOT NULL,
   PRIMARY KEY(id)
);

CREATE TABLE prioridad(
   id INT GENERATED ALWAYS AS IDENTITY,
   prioridad VARCHAR(255) NOT NULL,
   PRIMARY KEY(id)
);

CREATE TABLE Tareas(
   id INT GENERATED ALWAYS AS IDENTITY,
   descripcion VARCHAR NOT NULL,
   colaborador_id INT,
   estado_id INT,
   prioridad_id INT,
   fecha_inicio DATE NOT NULL,
   fecha_fin DATE NOT NULL,
   notas VARCHAR,
   PRIMARY KEY(id),
   CONSTRAINT fk_colaborador
      FOREIGN KEY(colaborador_id) 
	  REFERENCES colaborador(id),
    
   CONSTRAINT fk_estado
      FOREIGN KEY(estado_id) 
	  REFERENCES estado(id),
    
   CONSTRAINT fk_prioridad
      FOREIGN KEY(prioridad_id) 
	  REFERENCES prioridad(id)
);


-----------Inicializacion de datos------------------------
insert into estado (estado) values('Pendiente');
insert into estado (estado) values('En Proceso');
insert into estado (estado) values('Finalizada');

insert into prioridad (prioridad) values('Alta');
insert into prioridad (prioridad) values('Media');
insert into prioridad (prioridad) values('Baja');

insert into colaborador (nombre) values('Daniel');
insert into colaborador (nombre) values('Pablo');
insert into colaborador (nombre) values('Fabian');
insert into colaborador (nombre) values('Jonathan');
insert into colaborador (nombre) values('Simon');
insert into colaborador (nombre) values('Fabrizio');

INSERT INTO public.tareas(descripcion, colaborador_id, estado_id, prioridad_id, fecha_inicio, fecha_fin, notas)
	VALUES ('Programar', 1, 1, 1,'2022-10-16' , '2022-10-19', 'Proyecto Nuevo');