
create database SegurosFallabella
go
use SegurosFallabella
go
create table Categoria
(
Id int primary key identity,
Nombre varchar(50)
)
go
create table Producto
(
Id int primary key identity,
Nombre varchar(50),
Precio float,
FechaCreacion datetime,
Foto varchar(200),
CategoriaId int,
foreign key(CategoriaId) references Categoria)
go
insert into categoria(Nombre) values
('perfumes'),
('ropa'),
('accesorios')
go
insert into Producto(Nombre,Precio,FechaCreacion,CategoriaId) values 
('Perfume paulina rubio',30.000,getdate(),1),
('Paco Rabanne',70.000,getdate(),1),
('212 de Carolina Herrera',18.000,getdate(),1),
('Giorgio Armani Acqua Di Gio',100.000,getdate(),1),
('Issey Miyake L’eau D’issey Pour Homme',148.850,getdate(),1),
('Paco Rabanne Invictus',300.000,getdate(),1),
('Pantalones - Pants (Estados Unidos)',200.000,getdate(),2),
('Falda',70.000,getdate(),2),
('zapatos deportivos /Zapatillas',57.000,getdate(),2),
('Traje de baño ancho o bañador de hombre ',34.800,getdate(),2),
('Suéter ligero',36.07,getdate(),2),
('Clutch o bolso de mano',32.000,getdate(),3),
('Cartera negra',36.68,getdate(),3),
('Billetera',8.000,getdate(),3),
('Candongas pequeñas',5.000,getdate(),3),
('Gafas aviator',15.000,getdate(),3),
('Bufanda',30.000,getdate(),3)

go
create table Venta
(
Id int primary key identity,
DiaVenta datetime,
Subtotal float,
Iva float,
Total float)
go
create table ListaVenta
(
Id int primary key identity,
VentaId int,
ProductoId int,
Cantidad int,
Total float,
foreign key(VentaId) references Venta,
foreign key(ProductoId) references Producto
)


