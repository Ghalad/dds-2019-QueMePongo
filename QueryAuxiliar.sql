--Ver los atuendos generados para el evento
SELECT u.Username, u.Discriminator, p.PedidoId, e.CiudadEvento, e.Descripcion, a.AtuendoId, pr.PrendaId, c.Valor
FROM Usuarios u JOIN Pedidos p ON (u.UsuarioId = p.PedidoId)
				JOIN Atuendos a ON (a.Pedido_PedidoId = p.PedidoId)
				JOIN Eventos e ON (e.EventoId = p.Evento_EventoId)
				JOIN PrendasAtuendos pa ON (pa.AtuendoId = a.AtuendoId)
				JOIN Prendas pr ON (pr.PrendaId = pa.PrendaId)
				JOIN CaracteristicasPrendas cp ON (cp.prenda_PrendaId = pr.PrendaId)
				JOIN Caracteristicas c ON (c.CaracteristicaId = cp.CaracteristicaId)
WHERE c.Clave = 'TIPO'

--Ver usuarios y reglas
SELECT u.Username, r.ReglaId, c.CondicionId, c.Discriminator, ca.Clave, ca.Valor
FROM Reglas r JOIN Usuarios u ON (u.UsuarioId = r.Usuario_UsuarioId)
			JOIN Condiciones c ON (c.Regla_ReglaId = r.ReglaId)
			JOIN CaracteristicasCondiciones cc ON (cc.condicion_CondicionId = c.CondicionId)
			JOIN Caracteristicas ca ON (ca.CaracteristicaId = cc.CaracteristicaId)

-- Ver usuarios y guardarropas
SELECT u.Username, ug.Guardarropa_Id 
FROM UsuarioGuardarropas ug JOIN Usuarios u ON (ug.Usuario_UsuarioId = u.UsuarioId)

--Ver cantidad de prendas por usuario y guardarropa
SELECT u.Username, gp.Guardarropa_Id, COUNT(*) 'Cantidad de prendas'
FROM GuardarropaPrendas gp JOIN UsuarioGuardarropas ug ON (ug.Guardarropa_Id = gp.Guardarropa_Id)
							JOIN Usuarios u ON (ug.Usuario_UsuarioId = u.UsuarioId)
GROUP BY u.Username, gp.Guardarropa_Id

--Ver prenda de guardarropa y tipo de prenda
SELECT u.Username, gp.Guardarropa_Id, c.Clave, c.Valor
FROM GuardarropaPrendas gp JOIN CaracteristicasPrendas cp ON (cp.prenda_PrendaId = gp.Prenda_PrendaId)
							JOIN Caracteristicas c ON (c.CaracteristicaId = cp.CaracteristicaId)
							JOIN UsuarioGuardarropas ug ON (ug.Guardarropa_Id = gp.Guardarropa_Id)
							JOIN Usuarios u ON (ug.Usuario_UsuarioId = u.UsuarioId)
WHERE c.Clave = 'TIPO'
ORDER BY gp.Guardarropa_Id

--Ver prendas y caracteristicas
SELECT cp.prenda_PrendaId, c.CaracteristicaId, c.Clave, c.Valor
FROM CaracteristicasPrendas cp JOIN Caracteristicas c ON (cp.CaracteristicaId = c.CaracteristicaId)

--Ver con prendas y caracteristicas
SELECT a.Pedido_PedidoId, pa.AtuendoId, pa.PrendaId, c.Valor 
FROM PrendasAtuendos pa JOIN CaracteristicasPrendas cp ON (cp.prenda_PrendaId = PrendaId)
				JOIN Caracteristicas c ON (c.CaracteristicaId = cp.CaracteristicaId)
				JOIN Atuendos a ON (a.AtuendoId = pa.AtuendoId)
WHERE c.Clave = 'TIPO'
ORDER BY AtuendoId


