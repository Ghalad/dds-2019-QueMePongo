
-- Ver usuarios y guardarropas
SELECT * FROM UsuarioGuardarropas

--Ver cantidad de prendas por guardarropa
SELECT gp.Guardarropa_Id, COUNT(*) 'Cantidad de prendas'
FROM GuardarropaPrendas gp
GROUP BY gp.Guardarropa_Id

--Ver prenda de guardarropa y tipo de prenda
SELECT gp.Guardarropa_Id, c.Clave, c.Valor
FROM GuardarropaPrendas gp JOIN CaracteristicasPrendas cp ON (cp.prenda_PrendaId = gp.Prenda_PrendaId)
							JOIN Caracteristicas c ON (c.CaracteristicaId = cp.CaracteristicaId)
WHERE c.Clave = 'TIPO'
ORDER BY gp.Guardarropa_Id



delete from GuardarropaPrendas
delete from CaracteristicasPrendas
delete from Prendas 
delete from Guardarropas
delete from Calificaciones
delete from Caracteristicas
delete from UsuarioGuardarropas
delete from Usuarios
