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

DROP PROCEDURE IF EXISTS sp_ReporteVentas;

CREATE PROC sp_ReporteVentas(
@fechainicio varchar(10),
@fechafin varchar(10)
)
as
begin
SET DATEFORMAT dmy;
select
convert(char(10),v.fecha_registro,103)[FechaRegistro],v.tipo_documento, v.numero_documento,v.monto_total,
u.nombre_usuario[NombreUsuario],
v.dni_cliente, v.nombre_cliente,
p.codigo_producto[CodigoProducto], p.nombre_producto[NombreProducto],ca.descripcion_categoria[Categoria], dv.precioVenta, dv.cantidad, dv.subTotal
from factura v
inner join usuario u on u.id_usuario = v.id_usuario
inner join factura_detalle dv on dv.id_factura = v.id_factura
inner join productos p on p.id_producto = dv.id_producto
inner join categoria ca on ca.id_categoria = p.id_categoria
where CONVERT(date, v.fecha_registro) between @fechainicio and @fechafin
end


exec sp_ReporteVentas '5/11/2024','6/11/2024'


CREATE PROCEDURE sp_ReporteVentasPorVendedor
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
        v.nombre_cliente,
        p.codigo_producto AS [CodigoProducto],
        p.nombre_producto AS [NombreProducto],
        ca.descripcion_categoria AS [Categoria],
        dv.precioVenta,
        dv.cantidad,
        dv.subTotal
    FROM factura v
    INNER JOIN usuario u ON u.id_usuario = v.id_usuario
    INNER JOIN factura_detalle dv ON dv.id_factura = v.id_factura
    INNER JOIN productos p ON p.id_producto = dv.id_producto
    INNER JOIN categoria ca ON ca.id_categoria = p.id_categoria
    WHERE v.id_usuario = @id_usuario
END;

EXEC sp_ReporteVentasPorVendedor @id_usuario = 9;