

CREATE OR ALTER PROCEDURE InsertarUsuario
    @dni VARCHAR(45), 
	@nombre VARCHAR(120), 
    @apellido VARCHAR(120), 
    @idRol INT, 
    @FechaNacimiento DATE, 
    @mail VARCHAR(255), 
    @FechaAlta DATE
AS
BEGIN
    INSERT INTO Usuario(Dni, Nombre, Apellido, idRol, FechaNacimiento, Mail, FechaAlta)
    VALUES (@dni, @nombre, @apellido, @idRol, @FechaNacimiento, @mail, @FechaAlta);
END 