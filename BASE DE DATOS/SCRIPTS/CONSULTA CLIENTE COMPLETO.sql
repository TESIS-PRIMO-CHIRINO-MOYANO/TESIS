SELECT 
	U.IdUsuario,
	U.Dni,
	U.Nombre,
	U.Apellido,
	U.Mail,
	U.Password,
	U.FechaNacimiento,
	U.FechaAlta,
	C.IdCliente,
	C.IdBarrio,
	C.Calle,
	C.Piso,
	C.Depto,
	C.Telefono,
	CC.IdCuenta,
	CC.Monto
FROM 
Usuario AS U
Inner Join Cliente AS C ON C.IdUsuario = U.IdUsuario
Inner Join CuentaCorriente AS CC ON  CC.IdCliente = C.IdCliente