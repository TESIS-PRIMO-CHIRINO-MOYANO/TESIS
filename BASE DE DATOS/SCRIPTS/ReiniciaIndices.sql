-- Vaciar la tabla
DELETE FROM CuentaCorriente

-- Reiniciar el índice autoincremental
DBCC CHECKIDENT ('CuentaCorriente', RESEED, 0)

select * from CuentaCorriente

-- Vaciar la tabla
DELETE FROM Cliente

-- Reiniciar el índice autoincremental
DBCC CHECKIDENT ('Cliente', RESEED, 0)

select * from Cliente

-- Vaciar la tabla
DELETE FROM Usuario where IdRol=1

-- Reiniciar el índice autoincremental
DBCC CHECKIDENT ('Usuario', RESEED, 0)

select * from Usuario