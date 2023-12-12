CREATE OR ALTER PROCEDURE InsertarCuenta
    @idCliente int 
AS
BEGIN
    INSERT INTO CuentaCorriente(Monto, IdCliente)
    VALUES (0, @idCliente);
END 
