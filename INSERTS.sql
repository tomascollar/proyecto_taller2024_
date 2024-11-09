----prueba de registro venta

-- Declara la variable de tipo tabla EDetalle_Venta
DECLARE @DetalleVentaTable EDetalle_Venta;

-- Inserta los datos de prueba en @DetalleVentaTable
INSERT INTO @DetalleVentaTable (IdProducto, Precio, Cantidad, SubTotal)
VALUES 
    (1003, 50.00, 1, 50.00),  -- Producto 1, Precio 50, Cantidad 1, SubTotal 50
    (1004, 25.00, 2, 50.00);  -- Producto 2, Precio 25, Cantidad 2, SubTotal 50

-- Declara las variables de salida
DECLARE @Resultado BIT;
DECLARE @Mensaje VARCHAR(500);

-- Ejecuta el procedimiento almacenado con la variable de tabla y otros parámetros
EXEC usp_RegistrarVentaConFecha 
    @id_usuario = 9,
    @tipo_documento = 'Factura',
    @numero_documento = 'F-12345',
    @dni_cliente = '12345678',
    @nombre_cliente = 'Cliente de Prueba',
    @monto_total = 100.00,
    @fecha_registro = '2024-10-15',  -- Fecha específica para la venta
    @DetalleVenta = @DetalleVentaTable,  -- Pasa la variable de tipo tabla
    @Resultado = @Resultado OUTPUT,
    @Mensaje = @Mensaje OUTPUT;

-- Verifica los resultados
SELECT @Resultado AS Resultado, @Mensaje AS Mensaje;

INSERT INTO marca (descripcion_marca)
VALUES ('Rosamonte');

INSERT INTO marca (descripcion_marca)
VALUES ('Coca Cola');

INSERT INTO marca (descripcion_marca)
VALUES ('Pepsi');

INSERT INTO marca (descripcion_marca)
VALUES ('Bayer');

