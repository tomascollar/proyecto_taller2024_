select * from factura where numero_documento = '0001'

select * from factura_detalle where id_factura = 4



---Detalle Venta
select v.id_factura, u.nombre_usuario, v.dni_cliente, v.nombre_cliente
,v.tipo_documento, v.numero_documento, v.monto_total,
convert(char(10),v.fecha_registro,103)[fecha_registro]
from factura v
inner join usuario u on u.id_usuario = v.id_usuario
where v.numero_documento = '0001'


select p.nombre_producto, dv.precioVenta,dv.cantidad, dv.subTotal
from factura_detalle dv
inner join productos p on p.id_producto = dv.id_producto
where dv.id_factura = 4