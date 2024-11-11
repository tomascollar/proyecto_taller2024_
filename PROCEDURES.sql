---Procesos para registrar la venta-----

CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE(
	[IdProducto] int null,
	[Precio] decimal(18,2) NULL,
	[Cantidad] int NULL,
	[SubTotal] decimal(18,2) NULL
)

GO


create PROCEDURE usp_RegistrarVenta(
@id_usuario int,
@tipo_documento varchar(500),
@numero_documento varchar(500),
@dni_cliente varchar(500),
@nombre_cliente varchar(500),
@monto_total decimal(18,2),
@DetalleVenta [EDetalle_Venta] READONLY,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	begin try
		
		declare @idventa int = 0
		set @Resultado = 1
		set @Mensaje = ''

		begin transaction registro

		insert into factura(id_usuario,tipo_documento,numero_documento,dni_cliente,nombre_cliente,monto_total)
		values(@id_usuario,@tipo_documento,@numero_documento,@dni_cliente,@nombre_cliente,@monto_total)

		set @idventa = SCOPE_IDENTITY()

		insert into factura_detalle(id_factura,id_producto,precioVenta,cantidad,subTotal)
		select @idventa,IdProducto,Precio,Cantidad,SubTotal from @DetalleVenta

		commit transaction registro

	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch

end

go

-----REPORTE VENTAS-------


ALTER PROC sp_ReporteVentas(
@fechainicio varchar(10),
@fechafin varchar(10)
)
as
begin
SET DATEFORMAT dmy;
    SELECT 
        convert(char(10), v.fecha_registro, 103) AS [FechaRegistro],
        v.tipo_documento,
        v.numero_documento,
        v.monto_total,
        u.nombre_usuario AS [NombreUsuario],
        v.dni_cliente, 
        v.nombre_cliente
    FROM factura v
    INNER JOIN usuario u ON u.id_usuario = v.id_usuario
    WHERE CONVERT(date, v.fecha_registro) BETWEEN @fechainicio AND @fechafin
    GROUP BY 
        v.fecha_registro, v.tipo_documento, v.numero_documento, v.monto_total, 
        u.nombre_usuario, v.dni_cliente, v.nombre_cliente
END


exec sp_ReporteVentas '2/11/2024','11/11/2024'

----sp para generar reporte de ventas por vendedor

create PROCEDURE sp_ReporteVentasPorVendedor
    @id_usuario INT
AS
BEGIN
    SELECT
        CONVERT(CHAR(10), v.fecha_registro, 103) AS [FechaRegistro],
        v.tipo_documento,
        v.numero_documento,
        v.monto_total,
        u.nombre_usuario AS [NombreUsuario],
        v.dni_cliente,
        v.nombre_cliente
    FROM factura v
    INNER JOIN usuario u ON u.id_usuario = v.id_usuario
    WHERE v.id_usuario = @id_usuario
    GROUP BY 
        v.fecha_registro,
        v.tipo_documento,
        v.numero_documento,
        v.monto_total,
        u.nombre_usuario,
        v.dni_cliente,
        v.nombre_cliente;
END;

EXEC sp_ReporteVentasPorVendedor @id_usuario = 9;

------sp para generar grafico de ventas mensuales

CREATE PROCEDURE sp_ReporteVentasMensuales
AS
BEGIN
    SET DATEFORMAT dmy;
    SELECT 
        DATENAME(month, v.fecha_registro) AS Mes,
        COUNT(*) AS TotalVentas,
        SUM(v.monto_total) AS MontoTotal
    FROM 
        factura v
    GROUP BY 
        DATENAME(month, v.fecha_registro), MONTH(v.fecha_registro)
    ORDER BY 
        MONTH(v.fecha_registro);
END

----procedimiento para generar grafico torta producto mas vendido

CREATE PROCEDURE sp_ProductosMasVendidos
AS
BEGIN
    SELECT TOP 5
        p.nombre_producto AS NombreProducto,
        SUM(dv.cantidad) AS TotalVendidos
    FROM
        factura_detalle dv
    INNER JOIN
        productos p ON p.id_producto = dv.id_producto
    GROUP BY
        p.nombre_producto
    ORDER BY
        TotalVendidos DESC;
END

----sp para registrar una venta desde sql con una fecha q yo desee y no la actual

CREATE PROCEDURE usp_RegistrarVentaConFecha
(
    @id_usuario INT,
    @tipo_documento VARCHAR(500),
    @numero_documento VARCHAR(500),
    @dni_cliente VARCHAR(500),
    @nombre_cliente VARCHAR(500),
    @monto_total DECIMAL(18, 2),
    @fecha_registro DATETIME,  -- Parámetro adicional para la fecha de registro
    @DetalleVenta [EDetalle_Venta] READONLY,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
        DECLARE @idventa INT = 0;
        SET @Resultado = 1;
        SET @Mensaje = '';

        BEGIN TRANSACTION registro;

        -- Inserta en factura con la fecha especificada
        INSERT INTO factura(id_usuario, tipo_documento, numero_documento, dni_cliente, nombre_cliente, monto_total, fecha_registro)
        VALUES(@id_usuario, @tipo_documento, @numero_documento, @dni_cliente, @nombre_cliente, @monto_total, @fecha_registro);

        SET @idventa = SCOPE_IDENTITY();

        -- Inserta en factura_detalle
        INSERT INTO factura_detalle(id_factura, id_producto, precioVenta, cantidad, subTotal)
        SELECT @idventa, IdProducto, Precio, Cantidad, SubTotal FROM @DetalleVenta;

        COMMIT TRANSACTION registro;

    END TRY
    BEGIN CATCH
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
        ROLLBACK TRANSACTION registro;
    END CATCH
END

-----procedimiento almacenado para hacer baja logica de usuario

CREATE PROCEDURE sp_BajaLogicaUsuario
    @id_usuario INT
AS
BEGIN
    UPDATE usuario
    SET estado_usuario = 'Inactivo'
    WHERE id_usuario = @id_usuario;
END;

-----procedimiento almacenado para hacer baja logica de cliente

CREATE PROCEDURE sp_BajaLogicaCliente
    @id_cliente INT
AS
BEGIN
    UPDATE clientes
    SET estado_cliente = 'Inactivo'
    WHERE id_cliente = @id_cliente;
END;

-----procedimiento almacenado cliente con mas ventas 

CREATE PROCEDURE sp_ClientesMasVentas
AS
BEGIN
    SELECT TOP 5
        c.nombre_cliente AS NombreCliente,
        SUM(f.monto_total) AS TotalGastado
    FROM 
        factura f
    INNER JOIN
        clientes c ON c.dni_cliente = f.dni_cliente -- Relacionamos por dni_cliente
    GROUP BY
        c.nombre_cliente
    ORDER BY
        TotalGastado DESC;
END


----- procedimiento almacenado categoria de producto mas vendida

CREATE PROCEDURE sp_CategoriasMasVendidas
AS
BEGIN
    SELECT TOP 5
        c.descripcion_categoria AS Categoria,
        SUM(dv.cantidad) AS TotalVendidos
    FROM 
        factura_detalle dv
    INNER JOIN
        productos p ON p.id_producto = dv.id_producto
    INNER JOIN
        categoria c ON c.id_categoria = p.id_categoria
    GROUP BY
        c.descripcion_categoria
    ORDER BY
        TotalVendidos DESC;
END

go


-----procedimiento para registrar una categoria

CREATE PROC SP_RegistrarCategoria(
@Descripcion varchar(50),
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	if not exists (select * from categoria where descripcion_categoria = @Descripcion)
	begin
		insert into categoria(descripcion_categoria, estado_categoria)
		values (@Descripcion,'Activo')
		set @Resultado =  SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'No se puede repetir la descripcion de una categoria'
end

go

----procedimiento para modificar categoria
create proc sp_EditarCategoria(
@IdCategoria int,
@Descripcion varchar(50),
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
	if not exists (select * from categoria where descripcion_categoria = @Descripcion and id_categoria != @IdCategoria)
		update categoria set
		descripcion_categoria = @Descripcion
		where id_categoria = @IdCategoria
	else
	begin
		set @Resultado = 0
		set @Mensaje = 'No se puede repetir la descripcion de una categoria'

	end

end

go
--------------------

create proc sp_EliminarCategoria(
@IdCategoria int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
	if not exists (
		select * from categoria c
		inner join productos p on p.id_categoria = c.id_categoria
		where c.id_categoria = @IdCategoria
		)
		begin
			update categoria set estado_categoria = 'Inactivo' where id_categoria = @IdCategoria
		end
	else
	begin
		set @Resultado = 0
		set @Mensaje = 'Esta categoria esta relacionada a un producto y no puede ser eliminada'
	end
end

go

---------SP PARA AGREGAR MARCA
CREATE PROC SP_RegistrarMarca(
@Descripcion varchar(50),
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	if not exists (select * from marca where descripcion_marca = @Descripcion)
	begin
		insert into marca(descripcion_marca, estado_marca)
		values (@Descripcion,'Activo')
		set @Resultado =  SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'No se puede repetir la descripcion de una marca'
end

go

-----SP PARA BAJA LOGICA DE UNA MARCA

create proc sp_EliminarMarca(
@IdMarca int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
	if not exists (
		select * from marca m
		inner join productos p on p.id_marca = m.id_marca
		where m.id_marca = @IdMarca
		)
		begin
			update marca set estado_marca = 'Inactivo' where id_marca = @IdMarca
		end
	else
	begin
		set @Resultado = 0
		set @Mensaje = 'Esta marca esta relacionada a un producto y no puede ser eliminada'
	end
end

go

---------