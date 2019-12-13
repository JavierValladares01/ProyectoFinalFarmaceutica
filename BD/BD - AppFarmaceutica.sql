use master 
go

create database AppFarmaceutica
go

use AppFarmaceutica
go

create table Usuario
(
NomUsu varchar (20) primary key,
PassUsu varchar (20) not null,
Nombre varchar (20) not null,
Apellido varchar (20) not null
)


create table Cliente
(
NomUsu varchar (20) primary key references Usuario (NomUsu),
DirEntrega varchar(30) not null,
NumTelefono int not null,
)


create table Empleado
(
NomUsu varchar (20) primary key references Usuario (NomUsu),
HorarioEntrada varchar(20),
HorarioSalida varchar(20)
)


create table Farmaceutica
(
RUC int primary key,
NomFarm varchar (20) not null, 
Email varchar (30),
Direccion varchar (30) not null
)


create table Medicamento
(
Codigo int not null,
RUC int foreign key references Farmaceutica (RUC),
NomMed varchar (20) not null, 
Descripcion varchar (30) not null,
Precio float not null
primary key (Codigo, RUC)
)

create table Pedido
(
NumPedido int identity (1,1) primary key,
NomUsu varchar (20) not null foreign key references Cliente (NomUsu),
Codigo int not null,
RUC int not null,
Cantidad int not null,
Estado varchar (20),
foreign key (Codigo, RUC) references Medicamento (Codigo, RUC)
)



----------------------------------------------
--********* //DATOS DE PRUEBA ****************
----------------------------------------------
set language spanish


insert Usuario values ('PedritoGarcia85', '123456', 'Pedro', 'Garcia')
insert Usuario values ('GatoPerez', 'hola22', 'Miguel', 'Perez')
insert Usuario values ('Leo', 'bcn2019', 'Lionel', 'Messi')
insert Usuario values ('RodSilvia', 'ufc4ever', 'Silvia', 'Rodriguez')
insert Usuario values ('ElFabrizio', '147147', 'Fabrizio', 'Werdum')
insert Usuario values ('Mariaaa', '123456', 'Maria', 'Martinez')
insert Usuario values ('ChrisBrown', 'christo0', 'Christopher', 'Brown')
insert Usuario values ('Jen92', 'jenn1jenn1', 'Jennifer','Smith')
insert Usuario values ('Tony', 'antoni0', 'Antonio','Neruda')
insert Usuario values ('Frankie', 'Frankie999', 'Frank','Rogers')
insert Usuario values ('TheDirkGraham', '999999999', 'Dirk','Graham')
insert Usuario values ('Lui-San', '22ls22', 'Luisa','Sanchez')
insert Usuario values ('CR7', 'Campeon', 'Cristiano','Ronaldo')
insert Usuario values ('Numero1', '60000', 'Gabriela','Gil')

insert Cliente values ('PedritoGarcia85', 'Yaguaron 2234', 98555444)
insert Cliente values ('GatoPerez', 'Meteorito 232', 99321321)
insert Cliente values ('Leo', 'Yi 1123', 98741789)
insert Cliente values ('RodSilvia', 'Av. Juarez y Mexico 2626', 92444111)
insert Cliente values ('ElFabrizio', '18 de Julio y Yi 1111', 98888777)
insert Cliente values ('Mariaaa', 'Mercedes 1285', 91554444)
insert Cliente values ('ChrisBrown', 'California 91210', 99777555)

insert Empleado values ('Jen92', '09:00', '15:30')
insert Empleado values ('Tony', '09:00', '15:30')
insert Empleado values ('Frankie','09:00', '15:30')
insert Empleado values ('TheDirkGraham', '07:30', '14:00')
insert Empleado values ('Lui-San', '07:30', '14:00')
insert Empleado values ('CR7', '07:30', '14:00')
insert Empleado values ('Numero1', '14:00', '20:30')


insert Farmaceutica values (11111111, 'MedicinaUY', 'medicinauy@farmaceutica.com', 'Mercedes 2212')
insert Farmaceutica values (22222222, 'FarmaSalud', 'farmasalud@farmaceutica.com', '18 de julio 3455')
insert Farmaceutica values (33333333, 'MediCare', 'farmaceutica@medicare.com', 'Montecaseros 2620')
insert Farmaceutica values (44444444, 'FarmaciaOriental', 'farmaciaoriental@yahoo.com', 'Comercio 1515')
insert Farmaceutica values (55555555, 'FLEX', 'flexmedicina@flex.com', 'Paysandu 0012')
insert Farmaceutica values (66666666, 'FarmaLab', 'laboratorios@farmalab.com', 'Alguna calle 5656')

insert Medicamento values (1234, 11111111, 'Perifar', 'Analgesico Antiinflamatorio', 200) 
insert Medicamento values (4567, 11111111, 'Bisolvon', 'Jarabe Expectorante', 250)
insert Medicamento values (5544, 22222222, 'WEB-C PLUS', 'Comprimido antigripal', 125)
insert Medicamento values (1142, 33333333, 'Xylisol', 'Spray nasal antialergico', 90)
insert Medicamento values (9865, 44444444, 'Ketonal 20', 'Comprimido antialergico', 600)
insert Medicamento values (7777, 44444444, 'Paracetamol', 'Analgesico Antipiretico', 200)
insert Medicamento values (3366, 55555555, 'Aliviol', 'Relajante muscular', 350)
insert Medicamento values (5588, 55555555, 'Dolosedol', 'Alivia dolor y fiebre', 290)

insert Pedido values ('RodSilvia', 1234, 11111111, 2, 'Generado')
insert Pedido values ('Leo', 1142, 33333333, 4, 'Enviado')
insert Pedido values ('Mariaaa', 7777, 44444444, 10, 'Entregado')
insert Pedido values ('Mariaaa', 1234, 11111111, 5, 'Entregado')
insert Pedido values ('ElFabrizio', 9865, 44444444, 1, 'Enviado')
insert Pedido values ('GatoPerez', 5588, 55555555, 4, 'Generado')
insert Pedido values ('GatoPerez', 3366, 55555555, 3, 'Generado')
insert Pedido values ('ChrisBrown', 5544, 22222222, 7, 'Generado')
insert Pedido values ('Leo', 5544, 22222222, 9, 'Entregado')
insert Pedido values ('RodSilvia', 7777, 44444444, 2, 'Enviado')

go



------------------------------------------------------------------
------------BUSCAR FARMACEUTICA-----------------------------------
------------------------------------------------------------------

create proc sp_BuscoFarmaceutica

@ruc int

as 

begin
select *
from farmaceutica
where ruc = @ruc
end

go


------------------------------------------------------------------
------------AGREGAR FARMACEUTICA-----------------------------------
------------------------------------------------------------------
create proc sp_AgregarFarmaceutica
@ruc int,
@nomFar varchar (20),
@email varchar (30),
@Dir varchar (30)

as

begin 
		if exists (select * from Farmaceutica where ruc = @ruc)
			return 0;

		declare @error int
		begin tran

			insert Farmaceutica (ruc, NomFarm, Email, Direccion) values (@ruc, @nomFar, @email, @Dir)
			set @error = @@ERROR

		if (@error = 0)
			begin
				commit tran
				return 1
			end
		else
			begin
				rollback tran
				return -1
			end
end

go


------------------------------------------------------------------
------------ELIMINAR FARMACEUTICA-----------------------------------
------------------------------------------------------------------
create proc sp_EliminarFarmaceutica
@ruc int 
as

begin 
		if exists (select * from pedido where ruc = @ruc)
			return 0; -- si encuentra ruc en pedido, no elimina

		declare @error int
		begin tran

			delete from Medicamento where ruc = @ruc
			if @@error <> 0
			begin 
				rollback tran
				return -1 -- si hay error al eliminar
			end

			delete from Farmaceutica where ruc = @ruc
			if @@error <> 0
			begin 
				rollback tran
				return -1 -- si hay error al eliminar
			end
		commit tran
		return 1 -- si todo sale bien
end

go



------------------------------------------------------------------
------------MODIFICAR FARMACEUTICA-----------------------------------
-------------------------------------------------------

create proc sp_ModificarFarmaceutica

@ruc int,
@nomFar varchar (20),
@email varchar (30),
@Dir varchar (30)

as

begin 
		if not exists (select * from farmaceutica where ruc = @ruc)
			return 0;

		declare @error int

		begin tran
			
			update Farmaceutica set NomFarm = @nomFar, Email = @email, Direccion = @Dir 
					where ruc = @ruc

			set @error = @@error

			if (@error = 0)
				begin 
					commit tran
					return 1
				end
			else 
				begin
					rollback tran
					return -1
				end
end

go

------------------------------------------------------------------
------------BUSCO MEDICAMENTO-----------------------------------
-------------------------------------------------------


create proc sp_BuscoMedicamento
@codigo int,
@ruc int

as
select * from Medicamento where @RUC = RUC and @codigo = codigo
go

------------------------------------------------------------------
------------AGREGAR MEDICAMENTO-----------------------------------
-------------------------------------------------------

create proc sp_AgregarMedicamento
@RUC int,
@codigo int,
@NomMed varchar(20),
@Descripcion varchar(30),
@Precio float

as

begin

	if not exists (select * from farmaceutica where ruc = @ruc )
		return 0;
	begin
		if exists (select * from Medicamento where codigo = @codigo)
			return -1  -- retorna -1 si encuentra el codigo
		
	-- si llego hasta aca es porque puedo agregar
   
	declare @error int
    begin tran
		insert Medicamento values (@codigo,@RUC,@NomMed,@Descripcion,@Precio)
		set @error = @@ERROR

		if (@error = 0)
			begin
				commit tran
				return 1
			end
		else
			begin
				rollback tran
				return -2
			end
	end
end

go
    

------------------------------------------------------------------
------------MODIFICAR MEDICAMENTO-----------------------------------
-------------------------------------------------------

create proc sp_ModificarMedicamento
@RUC int,
@codigo int,
@NomMed varchar(20),
@Descripcion varchar(30),
@Precio float

as

begin

	if not exists (select * from farmaceutica where ruc = @ruc )
		return 0; --debe encontrar ruc
	else if not exists (select * from Medicamento where codigo = @codigo)
		return -1  -- tambien debe encontrar codigo
	
	-- si llego hasta aca es porque puedo modificar
   
	declare @error int

    begin tran
		update Medicamento set NomMed = @NomMed, Descripcion = @Descripcion, Precio = @Precio where RUC = @RUC and Codigo = @Codigo
		set @error = @@ERROR

		if (@error = 0)
			begin
				commit tran
				return 1
			end
		else
			begin
				rollback tran
				return -2
			end
end

go


------------------------------------------------------------------
------------ElIMINAR MEDICAMENTO-----------------------------------
-------------------------------------------------------

create proc sp_EliminarMedicamento
@RUC int,
@codigo int
as
begin
	if exists (select * from pedido where @RUC = RUC and @codigo = codigo)
	 -- si existen compras entonces empiezo a eliminar

	declare @error int
	begin tran
		
		delete Pedido where Pedido.RUC = @RUC
			if @@ERROR <>0
				begin
					rollback tran
					return -1 -- SI HAY ERROR ELIMINANDO
				end
		delete Medicamento where codigo = @codigo and RUC = @RUC
			if @@ERROR <>0
				begin
					rollback tran
					return -2 -- SI HAY ERROR ELIMINANDO
				end
	commit tran
	return 1 -- SI SALE TODO BIEN
end
	
go

------------------------------------------------
------------LISTAR MEDICAMENTO-----------------
-----------------------------------------------

CREATE PROCEDURE sp_ListarMedicamentos
AS
BEGIN
	SELECT * FROM Medicamento
END
GO

--- listar medicamento seleccionado 

CREATE PROCEDURE sp_ListarMedicamentoSeleccionado
@ruc int,
@codigo int
AS
BEGIN
	SELECT * FROM Medicamento 
	WHERE Medicamento.ruc = @ruc AND Medicamento.codigo = @codigo
END
GO

------------------------------------------------
------------LOGUEO CLIENTE----------------------
------------------------------------------------


Create Procedure LogueoCliente 
@NomUsu varchar(20), 
@PassUsu varchar(20)

AS

Begin

	Select *
	From Usuario 
	inner join Cliente
	on Usuario.NomUsu = Cliente.NomUsu
	Where Usuario.NomUsu = @NomUsu and Usuario.PassUsu = @PassUsu

End
go

------------------------------------------------
------------LOGUEO EMPLEADO---------------------
------------------------------------------------


Create Procedure LogueoEmpleado 
@NomUsu varchar(20),
@PassUsu varchar(20)

AS

Begin
	Select *
	From Usuario 
	inner join Empleado 
	on Usuario.NomUsu = Empleado.NomUsu
	Where Usuario.NomUsu = @NomUsu and Usuario.PassUsu = @PassUsu
End
go


------------------------------------------------
------------LISTAR FARMACEUTICA---------------------
------------------------------------------------

create proc sp_ListarFarmaceuticas
as

begin
	select *
	from Farmaceutica
end

go


------------------------------------------------
------------LISTAR MEDICAMENTOS-----------------
--------------X FARMACEUTICA-------------------
------------------------------------------------

create proc sp_ListarMedicamentosXFarmaceutica
@RUC int

as

begin	
	select medicamento.*
	from medicamento
	join Farmaceutica
	on medicamento.ruc = Farmaceutica.ruc
	where farmaceutica.ruc = @RUC
end

go

------------------------------------------------
------------LISTAR PEDIDOS----------------------
------------------------------------------------

create proc sp_ListarPedidosXEstado
@estado varchar (20),
@codigo int

as

begin
	select *
	from pedido
	join Medicamento
	on pedido.Codigo = Medicamento.codigo
	where Estado = @estado and Medicamento.codigo = @codigo
end

go



------------------------------------------------
------------Buscar Cliente----------------------
------------------------------------------------

create proc sp_BuscarCliente
@NomUsu varchar (20)

as
begin
	select *
	from cliente
	join Usuario
	on cliente.NomUsu = usuario.NomUsu
	where cliente.NomUsu = @NomUsu
end

go

------------------------------------------------
------------AGREGAR CLIENTE---------------------
------------------------------------------------
create proc sp_AgregarCliente

@NomUsu VARCHAR(20),
@PassUsu VARCHAR(20),
@Nombre VARCHAR(20),
@Apellido VARCHAR(20),
@dirEntrega VARCHAR(30),
@telefono INT

AS
BEGIN
	BEGIN TRAN
		INSERT Usuario VALUES(@NomUsu, @PassUsu, @Nombre, @Apellido)
		IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRAN
				RETURN -1 --Error al agregar usuario
			END
		INSERT Cliente VALUES(@nomUsu, @dirEntrega, @telefono)
		IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRAN
				RETURN -1 --error al agregar cliente
			END
	COMMIT TRAN
	RETURN 1 --Agregado exitosamente
END
GO

------------------------------------------------
------------LISTAR TODOS PEDIDOS----------------------
------------------------------------------------

create proc sp_ListarTodosPedidos
@codigo int

as

begin
	select *
	from pedido
	join Medicamento
	on pedido.Codigo = Medicamento.codigo
	where Medicamento.codigo = @codigo
end

go

------------------------------------------------
------------AGREGAR PEDIDO----------------------
------------------------------------------------

CREATE PROCEDURE sp_AgregarPedido
@nomUsu varchar(20),
@cod int,
@ruc int,
@cantidad int,
@estado varchar (20)

AS

BEGIN
	
	declare @error int
	begin tran
		
		INSERT Pedido VALUES (@nomUsu, @cod, @ruc, @cantidad, @estado)
		set @error = @@error

		if (@error = 0)
				begin
					commit tran
					return 1
				end
		else 
				begin
					rollback tran
					return -1
				end
end
go


------------------------------------------------
------------ELIMINAR PEDIDO---------------------
-----------------------------------------------


CREATE PROCEDURE sp_EliminarPedido
@numPedido int

AS

BEGIN
	IF NOT EXISTS(SELECT * FROM Pedido WHERE numPedido = @numPedido)
		RETURN 0 --si no existe pedido retorna 0
	
		declare @error int
		begin tran
			DELETE Pedido WHERE NumPedido = @numPedido
			set @error = @@error

			if (@error = 0)
					begin
						commit tran
						return 1
					end
			else 
					begin
						rollback tran
						return -1
					end
end
go

------------------------------------------------
------------AGREGAR EMPLEADO--------------------
-----------------------------------------------

create proc sp_AgregarEmpleado
--atributos de EMPLEADO
@NomUsu varchar(20),
@HorarioEntrada varchar(20),
@HorarioSalida varchar(20),
--atributos de USUARIO
@PassUsu varchar(20),
@Nombre varchar (20),
@Apellido varchar (20)

as

BEGIN
	BEGIN TRAN
		INSERT Usuario VALUES(@NomUsu, @PassUsu, @Nombre, @Apellido)
		if @@ERROR <> 0
			begin
				ROLLBACK TRAN
				return -1 
			end
		INSERT Empleado VALUES(@NomUsu, @HorarioEntrada, @HorarioSalida)
		if @@ERROR <> 0
			BEGIN
				ROLLBACK TRAN
				return -1 
			END
	COMMIT TRAN
	RETURN 1 
END
GO

go


------------------------------------------------
------------MODIFICAR EMPLEADO--------------------
-----------------------------------------------
create proc sp_ModificarEmpleado
--atributos de EMPLEADO
@NomUsu varchar(20),
@HorarioEntrada varchar(20),
@HorarioSalida varchar(20),
--atributos de USUARIO
@PassUsu varchar(20),
@Nombre varchar (20),
@Apellido varchar (20)

as

BEGIN
	IF NOT EXISTS(SELECT * FROM Empleado WHERE nomUsu = @NomUsu)
		RETURN 0 -- no encuentra empleado
	ELSE IF EXISTS(SELECT * FROM Cliente WHERE nomUsu = @NomUsu)
		RETURN -2 -- el nomusu corresponde a cliente

	BEGIN TRAN
		UPDATE Usuario SET PassUsu = @PassUsu, nombre = @Nombre, apellido = @Apellido WHERE nomUsu = @NomUsu
			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRAN
					RETURN -1 --error al eliminar usuaerio
				END
		UPDATE Empleado SET HorarioEntrada = @HorarioEntrada, HorarioSalida = @HorarioSalida WHERE nomUsu = @NomUsu
			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRAN
					RETURN -1 --error al eliminar empleado
				END
	COMMIT TRAN
	RETURN 1 -- empleado eliminado con exito
END
GO

------------------------------------------------
------------ELIMINAR EMPLEADO-------------------
-----------------------------------------------

create proc sp_EliminarEmpleado
@NomUsu varchar (20)

AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Empleado WHERE nomUsu = @NomUsu)
		RETURN 0 -- empleado no encontrado
	ELSE
		BEGIN
			BEGIN TRAN
				DELETE Empleado WHERE nomUsu = @NomUsu
				IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRAN
						RETURN -1 -- error al eliminar empleado
					END
				DELETE Usuario WHERE nomUsu = @NomUsu
				IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRAN
						RETURN -1 --error al eliminar usuario
					END
			COMMIT TRAN
			RETURN 1
		END
END
GO

------------------------------------------------
------------BUSCAR EMPLEADO-------------------
-----------------------------------------------
create proc sp_BuscarEmpleado
@NomUsu VARCHAR(20)

AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Empleado WHERE nomUsu = @NomUsu)
		RETURN -1 -- empleado no encontrado
	ELSE
		BEGIN
			SELECT * 
			FROM Usuario
			JOIN Empleado
			ON USUARIO.NomUsu = Empleado.NomUsu
			WHERE Empleado.NomUsu = @NomUsu
		END
END
GO

------------------------------------------------
------------BUSCAR EMPLEADO-------------------
-----------------------------------------------

CREATE PROCEDURE sp_BuscarPedido
@NumPedido INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Pedido WHERE NumPedido = @NumPedido)
		RETURN 0 --Esto es, no existe tal pedido
	ELSE
		BEGIN
			SELECT * FROM Pedido WHERE NumPedido = @NumPedido 
			RETURN 1
		END
END
GO


------------------------------------------------
------------LISTAR PEDIDOS GENERADOS------------
-----------------------------------------------

create proc sp_ListarPedidosGenerados
@nomUsu varchar(20)

AS
BEGIN
	SELECT * FROM Pedido WHERE estado = 'Generado' and NomUsu = @nomUsu
END
GO


------------------------------------------------
------------CAMBIAR ESTADO PEDIDO---------------
------------------------------------------------




CREATE PROCEDURE sp_CambiarEstadoPedido
@numPedido int 

as
begin

if exists (select * from pedido where estado = 'Generado' and NumPedido = @numPedido)
	begin
		begin tran
			update Pedido set estado = 'Enviado' where Pedido.NumPedido = @numPedido
			if @@ERROR <> 0
			begin
				rollback tran
				return -1
			end
		else	
			begin
				commit tran
				return 1
			end
	end
else 
	begin
		if exists (select * from pedido where estado = 'Enviado' and NumPedido = @numPedido)
		begin tran
			update Pedido set estado = 'Entregado' where Pedido.NumPedido = @numPedido
			if @@ERROR <> 0
			begin
				rollback tran
				return -1
			end
		else	
			begin
				commit tran
				return 1
			end
	end
end
go


---------------------------------------------------------
------------LISTAR PEDIDOS GENERADOS Y ENVIADOS------------
---------------------------------------------------------


create proc sp_ListarPedidosGeneradosYEnviados

as

begin
	select *
	from pedido
	where Estado = 'Generado' or Estado = 'Enviado'

end

go


