USE master
go

IF exists(SELECT * FROM SysDataBases WHERE name='Obligatorio_BIOS_News')
BEGIN
    DROP DATABASE Obligatorio_BIOS_News
END
go

CREATE DATABASE Obligatorio_BIOS_News
go
use Obligatorio_BIOS_News
go


-----------------------------------------------------------------------------------------------------------
					/*/*/*/*/*/*/*/*/*/*	 USUARIOS		*/*/*/*/*/*/*/*/*/*/
-----------------------------------------------------------------------------------------------------------
USE master
GO

CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS 
GO

USE Obligatorio_BIOS_News
GO

CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO

GRANT Execute to [IIS APPPOOL\DefaultAppPool]
go


-----------------------------------------------------------------------------------------------------------
					/*/*/*/*/*/*/*/*/*/*	 TABLAS		*/*/*/*/*/*/*/*/*/*/
-----------------------------------------------------------------------------------------------------------
create table periodistas (
	cedula Varchar(8) primary key         
           check(cedula like '[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	nombre varchar(30) not null,
	email varchar(30) not null
		  check(email like '%_@__%.__%'),
	deleted bit not null default(0) -- 0 activo, 1 borrado
)
go

create table usuarios (
	username varchar(10) primary key check(len(username) = 10),
	password varchar(7) check(password like '[A-Z][A-Z][A-Z][A-Z][0-9][0-9][0-9]')
)
go

create table secciones(
	codigo_secc varchar(5) check(len(codigo_secc) = 5),
	nombre_secc varchar(20) not null,
	primary key (codigo_secc),
	deleted bit not null default(0)
)
go

create table noticias (
	codigo varchar(6)  primary key not null,
	fecha date not null,
	titulo varchar (50) not null,
	cuerpo varchar (max) not null,
	importancia int not null check (importancia >= 1 and importancia <= 5),
	username varchar(10) not null,
	foreign key (username) references usuarios(username)
)
go
 
create table nacionales (
	codigo varchar(6),
	codigo_secc varchar(5) not null,
	foreign key (codigo_secc) references secciones(codigo_secc),
	foreign key (codigo) references noticias(codigo)
)
go

create table internacionales (
	codigo varchar(6),
	pais varchar(25) not null,
	primary key (codigo),
	foreign key (codigo) references noticias(codigo)
)
go

create table escriben(
	codigo varchar(6),
	cedula Varchar(8) not null,
	primary key (codigo, cedula),
	foreign key (codigo) references noticias (codigo),
	foreign key (cedula) references periodistas (cedula)
)
go


-----------------------------------------------------------------------------------------------------------
					/*/*/*/*/*/*/*/*/*/*	 DATOS		*/*/*/*/*/*/*/*/*/*/
-----------------------------------------------------------------------------------------------------------

insert periodistas (cedula,nombre,email)
	values ('41520770', 'DANIEL MANDALIOS','D.MANDA_123@gmail.com'),
		   ('47326453', 'ESTEBAN PICCARDO','estebanpiccardo1989@gmail.com'),
		   ('35654643', 'GABRIEL GESTA',   'G.GESTA_123@gmail.com'),
	       ('43243243', 'LAURA CTBLATANGA','L.CTBLA_567@gmail.com'),
		   ('12564354', 'SOFIA HERNANDEZ', 'S.OHERN_666@gmail.COM'),
	       ('30014354', 'RODRIGO ROMANO',  'rodrigoromano@gmail.com'),
		   ('46664004', 'ROBERTO MOAR',	   'robertomoar@gmail.com'),
		   ('22884504', 'ALBERTO KESMAN',  'kesmaseskesman@gmail.com')
go

insert usuarios (username,password)
	values ('dnmm88bios', 'dnmm123'),
	       ('este89bios', 'este123'),
	       ('gabi78bios', 'gabi123'),
		   ('administro', 'abcd123')
go

insert secciones (codigo_secc,nombre_secc)
	values ('003c5', 'DEPORTES'),
		   ('123k6', 'SALUD'),
		   ('7665d', 'VARIADOS'),
		   ('87w8q', 'NOTCIAS DEL DIA'),
		   ('wd45w', 'POLICIALES'),
		   ('z8789', 'CLIMA'),
		   ('opwo5', 'MUSICA'),
		   ('w286j', 'ARTE')
go

insert noticias (codigo,fecha,titulo,cuerpo,importancia,username)
values ('abd123', '20210823', 'COPA AMERICA',
		'URUGUAY DEBUTO PERDIENDO CON ARGENTINA 1 A 0. PARTIDO JUGADO EN BRASIL', 
		4,'este89bios'),
	   ('abC456', '20210823', 'COVID',
	    'MANTENIDA BAJA DE CASOS EN LOS ULTIMOS DIAS A NIVEL NACIONAL', 
		1,'este89bios'),
	   ('usi432', '20210824', 'REMATE',
		'NUEVO REMATE A REALIZARSE EL PROXIMO SABADO EN CIUDAD DE LA COSTA. ARTICULOS ANTIGUOS', 
		5,'este89bios'),
	   ('art456', '20210825', 'HURACAN',
		'SE APROXIMA HURACAN CATEGORIA 5 A LAS COSTAS DEL CARIBE SE VA A VER AFECTADO LA COSTA MEXICANA, MIAMI. SE EXORTA A LOS VIAJEROS PRECAUCION', 
		1,'gabi78bios'),
	   ('acf126', '20210826', 'VUELTA',
		'DE A POCO SE VAN RETOMANDO LAS ACTIVIDADES A NIVEL NACIONAL A MEDIDA QUE VA MEJORANDO LA SITUACION PANDEMICA', 
		2,'dnmm88bios'),
	   ('abd125', '20210827', 'ALLANAMIENTO',
		'IMPORTANTE OPERATIVO DE INTERPOOL DESARTICULARON ORGANIZACION DEDICADA AL NARCOTRAFICO Y TRAFICO DE ARMAS CON OPERACIONES EN VARIOS PAISES DE AMERICA LATINA', 
		3,'dnmm88bios'),


	   ('ppp666', '20210810', 'TEMA 1',
		'CONTENIDO DE LA NOTICIA 763WEW', 
		4,'este89bios'),
	   ('ggg000', '20210810', 'TEMA 2',
	    'CONTENIDO DE LA NOTICIA 763WEW', 
		5,'este89bios'),
	   ('jhg456', '20210811', 'TEMA 3',
		'CONTENIDO DE LA NOTICIA 763WEW', 
		5,'este89bios'),
	   ('kkk232', '20210811', 'TEMA 4',
		'CONTENIDO DE LA NOTICIA 763WEW', 
		1,'este89bios'),
	   ('rpo987', '20210812', 'TEMA 5',
		'CONTENIDO DE LA NOTICIA 763WEW', 
		5,'este89bios'),
	   ('763wew', '20210813', 'TEMA 6',
		'CONTENIDO DE LA NOTICIA 763WEW', 
		3,'este89bios')
go

insert nacionales (codigo,codigo_secc)
	values ('abd123', '003c5'),
		   ('abC456', '123k6'),
		   ('usi432', '7665d'),
		   ('acf126', '87w8q'),
		   ('kkk232', 'wd45w'),
		   ('rpo987', '7665d'),
		   ('763wew', 'z8789')
go

insert internacionales (codigo,pais)
	values ('art456', 'MEXICO'),
		   ('abd125', 'BRASIL'),
		   ('ppp666', 'ARGENTINA'),
		   ('ggg000', 'BRASIL'),
		   ('jhg456', 'ESPAÑA')
go

insert escriben (codigo,cedula)
	values ('abd123', '22884504'),
		   ('abd123', '47326453'),
		   ('acf126', '47326453'),
		   ('abC456', '47326453'),
		   ('ppp666', '30014354'),
		   ('ggg000', '12564354'),
		   ('kkk232', '41520770'),
		   ('abd125', '12564354'),
		   ('rpo987', '41520770'),
		   ('art456', '35654643'),
		   ('art456', '46664004'),
		   ('art456', '12564354'),
		   ('art456', '43243243'),
		   ('usi432', '35654643'),
		   ('usi432', '22884504'),	   
		   ('jhg456', '35654643'),
		   ('jhg456', '46664004'),
		   ('jhg456', '43243243'),
		   ('763wew', '35654643'),
		   ('763wew', '47326453')   
go


-----------------------------------------------------------------------------------------------------------
					/*/*/*/*/*/*/*/*/*/*	 PROCEDIMIENTOS		*/*/*/*/*/*/*/*/*/*/
-----------------------------------------------------------------------------------------------------------


		-- ABM PERIODISTAS --
-----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'listar_periodistas')
	drop proc listar_periodistas
go
create proc listar_periodistas
as
begin
	select * from periodistas where deleted = 0 order by nombre
end
go

if exists (select * from sysobjects where name = 'listar_periodistas_noticia')
	drop proc listar_periodistas_noticia
go
create proc listar_periodistas_noticia
	@codigo varchar(6)
as
begin
	select * from periodistas p
	join escriben e on e.cedula = p.cedula
	where e.codigo = @codigo
end
go

if exists (select * from sysobjects where name = 'buscar_periodista')
	drop proc buscar_periodista
go
create proc buscar_periodista
	@cedula varchar(8)
as
begin
	select * from periodistas where cedula = @cedula
end
go

if exists (select * from sysobjects where name = 'buscar_periodista_activo')
	drop proc buscar_periodista_activo
go
create proc buscar_periodista_activo
	@cedula varchar(8)
as
begin
	select * from periodistas where cedula = @cedula and deleted = 0
end
go

if exists (select * from sysobjects where name = 'agregar_periodista')
	drop proc agregar_periodista
go
create proc agregar_periodista
	@cedula varchar(8), 
	@nombre varchar(30),
	@email varchar (30) 
AS	
Begin
	if (exists(select * from periodistas where cedula = @cedula and deleted = 1))
	Begin
		update periodistas
		set nombre = @nombre, email = @email, deleted = 0
		where cedula = @cedula
		return 1
	end
	if (exists(Select * From periodistas Where cedula = @cedula and deleted = 0))
		return -1

	Insert periodistas(cedula, nombre, email) Values (@cedula, @nombre, @email)
End
go

if exists (select * from sysobjects where name = 'modificar_periodista')
	drop proc modificar_periodista
go
create proc modificar_periodista
	@cedula varchar(8), 
	@nombre varchar(30),
	@email varchar (30) 
as
begin
	if (not exists(select * from periodistas where cedula = @cedula and deleted = 0))
		return -2
	else
	begin
		Update periodistas Set nombre=@nombre, email = @email where cedula=@cedula
		return 1
	end
end
go

if exists (select * from sysobjects where name = 'borrar_periodista')
	drop proc borrar_periodista
go
create proc borrar_periodista
	@cedula varchar(8) 
as
begin
	if (not exists(select * from periodistas where cedula = @cedula))
	begin	
		return -1
	end

	if (exists(Select * From escriben where cedula = @cedula))
	Begin
		update periodistas Set deleted = 1 where cedula = @cedula
	end
	else
	begin
		Delete From periodistas where cedula = @cedula
		return 1
	end
end
go


		-- EMPLEADOS -- Solo Alta de Usuarios y Logueo
-----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'logueo')
	drop proc logueo
go
create proc logueo
	@user varchar(10),
	@pass varchar(7)
as
begin
	select * from usuarios 
	where username = @user and password = @pass
end
go

if exists (select * from sysobjects where name = 'agregar_usuario')
	drop proc agregar_usuario
go
create proc agregar_usuario
	@username varchar(10),
	@password varchar(7)
as
begin
	begin try
		if (exists(Select * From usuarios Where username = @username))
			return -1
			
		insert into usuarios(username,password) values(@username,@password)
			return 1	
	end try
	begin catch
		return @@error
	end catch
end
go

if exists (select * from sysobjects where name = 'buscar_usuario')
	drop proc buscar_usuario
go
create proc buscar_usuario
	@user varchar(10)
as
begin
	select * from usuarios where username = @user
end
go


		-- ABM SECCIONES --
-----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'listar_secciones')
	drop proc listar_secciones
go
create proc listar_secciones
as
begin
	select * from secciones where deleted = 0
end
go

if exists (select * from sysobjects where name = 'buscar_seccion')
	drop proc buscar_seccion
go
create proc buscar_seccion	
	@codigo_secc varchar(5)
as
begin
	select * from secciones where codigo_secc = @codigo_secc
end
go

if exists (select * from sysobjects where name = 'buscar_seccion_activa')
	drop proc buscar_seccion_activa
go
create proc buscar_seccion_activa	
	@codigo_secc varchar(5)
as
begin
	select * from secciones where codigo_secc = @codigo_secc and deleted = 0
end
go

if exists (select * from sysobjects where name = 'agregar_seccion')
	drop proc agregar_seccion
go
create proc agregar_seccion	
	@codigo_secc varchar(5),
	@nombre_secc varchar(20)
AS
BEGIN
	if (exists(select * from secciones where codigo_secc = @codigo_secc and deleted = 1))
	Begin
		update secciones set nombre_secc = @nombre_secc, deleted = 0 
		where codigo_secc = @codigo_secc
		return 1
	end
	if (exists(select * from secciones where codigo_secc = @codigo_secc and deleted = 0))
		return -1
		
	Insert secciones(codigo_secc, nombre_secc) Values (@codigo_secc, @nombre_secc)
		return 1
END
go

if exists (select * from sysobjects where name = 'modificar_seccion')
	drop proc modificar_seccion
go
create proc modificar_seccion
	@codigo_secc varchar(5),
	@nombre_secc varchar(20)
AS
BEGIN
	if (not exists(select * from secciones where codigo_secc = @codigo_secc and deleted = 0))
		return -1
	else
	begin
		update secciones set nombre_secc = @nombre_secc where codigo_secc = @codigo_secc
		return 1
	end
END
go

if exists (select * from sysobjects where name = 'borrar_seccion')
	drop proc borrar_seccion
go
create proc borrar_seccion	
	@codigo_secc varchar(5)
 AS
BEGIN
	if Not(EXISTS(Select * From secciones Where codigo_secc = @codigo_secc))
		return -1
	
	if (exists(Select * From nacionales where codigo_secc = @codigo_secc))
	Begin
		update secciones Set deleted = 1 where codigo_secc = @codigo_secc
	end
	else
	begin
		Delete secciones Where codigo_secc = @codigo_secc
		return 1
	end
END
go




		-- NOTICIAS -- Pagina Inicial del sitio (default)
-----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'ultimas_cinco_nacionales')
	drop proc ultimas_cinco_nacionales
go
create proc ultimas_cinco_nacionales
as
begin
	select *
	from noticias w
	join nacionales n on n.codigo = w.codigo
	where w.fecha between dateadd(day,-5,getdate()) and GETDATE()
end
go


if exists (select * from sysobjects where name = 'ultimas_cinco_internacionales')
	drop proc ultimas_cinco_internacionales
go
create proc ultimas_cinco_internacionales
as
begin
	select * 
	from noticias w
	join internacionales i on i.codigo = w.codigo
	where w.fecha between dateadd(day,-5,getdate()) and GETDATE()
end
go


		-- NOTICIAS -- Consulta Individual de Noticia
-----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'buscar_nacional')
	drop proc buscar_nacional
go
create proc buscar_nacional
	@codigo varchar(6)
as
begin
	select * from noticias w
	join nacionales n on n.codigo = w.codigo
	where w.codigo = @codigo
end
go

if exists (select * from sysobjects where name = 'buscar_internacional')
	drop proc buscar_internacional
go
create proc buscar_internacional
	@codigo varchar(6)
as
begin
	select * from noticias w
	join internacionales i on i.codigo = w.codigo
	where w.codigo = @codigo
end
go

if exists (select * from sysobjects where name = 'buscar_noticia_general')
	drop proc buscar_noticia_general
go
create proc buscar_noticia_general
	@codigo varchar(6)
as
begin
	select * from noticias where codigo = @codigo
end
go


		-- NOTICIAS NACIONALES -- Alta
-----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'agregar_nacional')
	drop proc agregar_nacional
go	
create proc agregar_nacional
	@codigo varchar(6), 
	@fecha datetime, 
	@titulo varchar(50),
	@cuerpo varchar(max), 
	@importancia int, 
	@seccion varchar(5),
	@username varchar(10)
as
begin
	if (exists (select * from noticias where @codigo = codigo))
		return -1
	
	if (not exists (select * from usuarios where @username = username))
		return -2
		
	if (not exists (select * from secciones where codigo_secc = @seccion and deleted = 0))
		return -3
		
	begin try
		
		insert into noticias (codigo, fecha, titulo, cuerpo, importancia, username )
			values (@codigo, @fecha, @titulo, @cuerpo, @importancia, @username)
		
		insert into nacionales (codigo, codigo_secc)
			values	(@codigo, @seccion)
			
		return 1
	end try
	begin catch
		return @@error
	end catch

end
go	
	
		
		-- NOTICIAS NACIOINALES-- Modificacion
-----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'modificar_nacional')
	drop proc modificar_nacional
go	
create proc modificar_nacional
	@codigo varchar(6), 
	@fecha datetime, 
	@titulo varchar(50),
	@cuerpo varchar(max), 
	@importancia int, 
	@seccion varchar(5),
	@username varchar(10)
as
begin
	if (not exists (select * from nacionales where @codigo = codigo))
		return -1

	if (not exists (select * from usuarios where @username = username))
		return -2
		
	if (not exists (select * from secciones where codigo_secc = @seccion and deleted = 0))
		return -3
		
	begin try
		
		update noticias
		set fecha = @fecha, titulo = @titulo, cuerpo = @cuerpo,
			importancia = @importancia, username = @username
		where codigo = @codigo
		
		update nacionales 
		set codigo_secc = @seccion
		where codigo = @codigo

		return 1
	end try
	begin catch
		return @@error
	end catch
	
end
go


		-- NOTICIAS INTERNACIONALES -- Alta
-----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'agregar_internacional')
	drop proc agregar_internacional
go
create proc agregar_internacional
	@codigo varchar(6), 
	@fecha datetime, 
	@titulo varchar(50),
	@cuerpo varchar(max), 
	@importancia int, 
	@pais varchar(25),
	@username varchar(10)
as
begin
	if (exists (select * from noticias where @codigo = codigo))
		return -1
	
	if (not exists (select * from usuarios where @username = username))
		return -2
		
	begin try
		
		insert into noticias (codigo, fecha, titulo, cuerpo, importancia, username )
			values (@codigo, @fecha, @titulo, @cuerpo, @importancia, @username)
		
		insert into internacionales (codigo, pais)
			values	(@codigo, @pais)
			
		return 1
	end try
	begin catch
		return @@error
	end catch
end
go	
		


		-- NOTICIAS INTERNACIOINALES-- Modificacion
-----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'modificar_internacional')
	drop proc modificar_internacional
go	
create proc modificar_internacional
	@codigo varchar(6), 
	@fecha datetime, 
	@titulo varchar(50),
	@cuerpo varchar(max), 
	@importancia int, 
	@pais varchar(25),
	@username varchar(10)
as
begin
	if (not exists (select * from internacionales where @codigo = codigo))
		return -1

	if (not exists (select * from usuarios where @username = username))
		return -2
		
	begin try
		
		update noticias
		set fecha = @fecha, titulo = @titulo, cuerpo = @cuerpo,
			importancia = @importancia, username = @username
		where codigo = @codigo
		
		update internacionales 
		set pais = pais
		where codigo = @codigo

		return 1
	end try
	begin catch
		return @@error
	end catch
	
end
go

-----------------------------------------------------------------------------------------------------------


create procedure agregar_escriben 
	@cedula int , 
	@codigo varchar(6) 
as
begin
	begin Try
		
		if (not exists (select * from periodistas where cedula = @cedula and deleted = 0))
			return -1
			
		if (not exists (select * from noticias where codigo = @codigo))
			return -2
		
		if(exists(select * from escriben where @cedula = cedula and @codigo = codigo))
			return -3
		
		insert into escriben (codigo, cedula) values (@codigo, @cedula)
			return 1
	end Try
	begin Catch
		return @@Error
	end Catch
end
go


create procedure borrar_ecriben 
	@codigo varchar(6) 
as
begin
	begin Try
		if (not exists (select * from escriben where codigo = @codigo))
			return -1
						
		delete from escriben where codigo = @codigo
			return 1
	end Try
	begin Catch
		return @@Error
	end Catch
end
go


		-- NOTICIAS - ESTADISTICAS
-----------------------------------------------------------------------------------------------------------


if exists (select * from sysobjects where name = 'estadisticas_nacionales')
	drop proc estadisticas_nacionales
go
create proc estadisticas_nacionales
as
begin
	select * from noticias w
	join nacionales i on i.codigo = w.codigo
	where w.fecha <= getdate()
end
go

if exists (select * from sysobjects where name = 'estadisticas_internacionales')
	drop proc estadisticas_internacionales
go
create proc estadisticas_internacionales
as
begin
	select * from noticias w
	join internacionales i on i.codigo = w.codigo
	where w.fecha <= getdate()
end
go

-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------

--if exists (select * from sysobjects where name = 'buscar_noticia')
--	drop proc buscar_seccion
--go
--create proc buscar_seccion	
--	@tipo int
--as
--begin
--	if(@tipo = 0)
--	begin 
--		select * from noticias w
--		join nacionales n on n.codigo = w.codigo
--		where w.codigo = @codigo
--	end
--	else
--	begin
--		select * from noticias w
--		join internacionales i on i.codigo = w.codigo
--		where w.codigo = @codigo
--	end
--	select * from secciones where codigo_secc = @codigo_secc
--end
--go