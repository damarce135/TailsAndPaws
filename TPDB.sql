/* CREAR BASE DE DATOS */
drop database TP; --Only if needed 
create database TP; --Paso 1
use TP; --Paso 2



/* CREAR TABLAS */
--Crear tabla rol
create table rol (
idRol int primary key, 
nombreRol varchar(45)
); 


--Crear tabla usuario 
create table usuario ( 
idUsuario int primary key, 
cedula varchar(45) unique, 
nombre varchar(45), 
apellido1 varchar(45), 
apellido2 varchar(45), 
email varchar(100), 
telefono varchar(45), 
contrasena varbinary, 
idOrganizacion int, 
habilitado bit
);


--Crear relación usuario/rol 
create table usuarioRol ( 
idUsuarioRol int primary key, 
idRol int, 
idUsuario int
); 


--Crear tabla recordatorio 
create table recordatorio ( 
idRecordatorio int primary key, 
creado datetime not null, 
titulo varchar(100), 
descripcion varchar(300), 
urgencia varchar(45), 
alertaEstado int, 
idUsuario int, 
habilitado bit
); 


--Crear tabla cita 
create table cita ( 
idCita int primary key, 
nombre varchar(100), 
telefono varchar(45), 
fecha datetime, 
hora time, 
motivo varchar(300), 
idUsuario int, 
habilitado bit
); 


--Crear tabla seguimiento 
create table seguimiento ( 
idSeguimiento int primary key, 
idAnimal int, 
idAdoptante int, 
idUsuario int, 
estado varchar(45), 
habilitado bit
); 


--Crear tabla donante 
create table donante ( 
idDonante int primary key, 
nombre varchar(45), 
apellido1 varchar(45), 
apellido2 varchar(45), 
telefono varchar(45), 
email varchar(100), 
habilitado bit 
); 


--Crear tabla animal 
create table animal ( 
idAnimal int primary key, 
nombre varchar(45), 
sexo varchar(45), 
raza varchar(45), 
castrado varchar(45), 
edad varchar(45), 
fechaIngreso datetime, 
idGSanguineo int, 
idOrganizacion int, 
habilitado bit
); 


--Crear tabla adopcion 
create table adopcion ( 
idAdopcion int primary key, 
idAnimal int, 
idAdoptante int, 
fechaAdopcion datetime, 
fechaSeguimiento datetime, 
habilitado bit
); 


--Crear tabla adoptante 
create table adoptante ( 
idAdoptante int primary key, 
cedula varchar(45) unique, 
nombre varchar(45), 
apellido1 varchar(45), 
apellido2 varchar(45), 
email varchar(100), 
telefono varchar(45), 
idDireccion int, 
habilitado bit
); 


--Crear tabla grupo sanguineo 
create table grupoSanguineo ( 
idGSanguineo int primary key, 
nombreGSanguineo varchar(45) 
); 


--Crear tabla organizacion 
create table organizacion (
idOrganizacion int primary key, 
tipo varchar(45), 
nombre varchar(100), 
telefono varchar(45), 
email varchar(45), 
idDireccion int, 
descripcion varchar(300), 
habilitado bit
); 


--Crear tabla direccion 
create table direccion ( 
idDireccion int primary key, 
idProvincia int, 
idCanton int, 
idDistrito int, 
detalle varchar(300) 
); 


--Crear tabla provincia 
create table provincia ( 
idProvincia int primary key, 
nombreProvincia varchar(45) 
); 


--Crear tabla canton 
create table canton ( 
idCanton int primary key, 
nombreCanton varchar(45), 
); 


--Crear tabla distrito 
create table distrito ( 
idDistrito int primary key, 
nombreDistrito varchar(45) 
);


--Crear tabla proveedor 
create table proveedor ( 
idProveedor int primary key, 
nombreProveedor varchar(45), 
idDireccion int, 
email varchar(100), 
telefono varchar(45), 
habilitado bit 
); 


--Crear tabla orgProveedor  
create table orgProveedor ( 
idOrgProveedor int primary key, 
idOrganizacion int, 
idProveedor int 
); 


--Crear tabla producto 
create table producto ( 
idProducto int primary key, 
nombre varchar(45), 
descripcion varchar(300), 
fechaIngreso datetime, 
cantidad int, 
habilitado bit 
); 


--Crear tabla prodProveedor 
create table prodProveedor ( 
idProdProveedor int primary key, 
idProducto int, 
idProveedor int 
); 


--Crear tabla categoria 
create table categoria ( 
idCategoria int primary key, 
nombreCategoria varchar(45) 
); 


--Crear relacion prodCategoria 
create table prodCategoria ( 
idProdCategoria int primary key, 
idProducto int, 
idCategoria int 
); 




/* CREAR LLAVES FORANEAS */ 


--Relacion rol con usuario 
alter table usuarioRol 
add foreign key (idRol) references rol(idRol); 

alter table usuarioRol 
add foreign key (idUsuario) references usuario(idUsuario); 


--Relacion agenda con usuario 
alter table recordatorio 
add foreign key (idUsuario) references usuario(idUsuario); 

alter table cita 
add foreign key (idUsuario) references usuario(idUsuario); 

alter table seguimiento 
add foreign key (idUsuario) references usuario(idUsuario); 


--Relacion seguimiento con animal-adoptante 
alter table seguimiento 
add foreign key (idAnimal) references animal(idAnimal); 

alter table seguimiento 
add foreign key (idAdoptante) references adoptante(idAdoptante); 


--Relacion animal con organizacion-gruposanguineo 
alter table animal 
add foreign key (idGSanguineo) references grupoSanguineo(idGSanguineo); 

alter table animal 
add foreign key (idOrganizacion) references organizacion(idOrganizacion); 


--Relacion adopcion con animal-adoptante 
alter table adopcion 
add foreign key (idAnimal) references animal(idAnimal); 

alter table adopcion 
add foreign key (idAdoptante) references adoptante(idAdoptante); 


--Relacion organizacion con direccion 
alter table organizacion 
add foreign key (idDireccion) references direccion(idDireccion); 


--Relacion direccion con provincia-canton-distrito 
alter table direccion 
add foreign key (idProvincia) references provincia(idProvincia); 

alter table direccion 
add foreign key (idCanton) references canton(idCanton); 

alter table direccion 
add foreign key (idDistrito) references distrito(idDistrito); 


--Relacion proveedor con direccion
alter table proveedor 
add foreign key (idDireccion) references direccion(idDireccion); 


--Relacion proveedor con organizacion 
alter table orgProveedor 
add foreign key (idOrganizacion) references organizacion(idOrganizacion); 

alter table orgProveedor 
add foreign key (idProveedor) references proveedor(idProveedor); 


--Relacion producto con proveedor 
alter table prodProveedor 
add foreign key (idProducto) references producto(idProducto); 

alter table prodProveedor 
add foreign key (idProveedor) references proveedor(idProveedor); 


--Relacion producto con categoria 
alter table prodCategoria 
add foreign key (idProducto) references producto(idProducto); 

alter table prodCategoria 
add foreign key (idCategoria) references categoria(idCategoria); 


--Relacion usuario con organizacion 
alter table usuario 
add foreign key (idOrganizacion) references organizacion(idOrganizacion); 


--Relacion adoptante con direccion 
alter table adoptante 
add foreign key (idDireccion) references direccion(idDireccion); 
