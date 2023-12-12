CREATE OR ALTER PROCEDURE InsertarCliente
    @calle VARCHAR(120), 
	@piso VARCHAR(60), 
    @depto VARCHAR(45), 
    @telefono INT, 
    @idBarrio INT, 
    @idUsuario int
 
AS
BEGIN
    INSERT INTO Cliente(Calle, Piso, Depto, Telefono, IdBarrio, IdUsuario)
    VALUES (@calle, @piso, @depto, @telefono, @idBarrio, @idUsuario);
END 
