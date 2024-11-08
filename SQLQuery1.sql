select u.id_usuario,u.nombre_usuario,u.apellido_usuario,u.telefono_usuario,u.usuario,u.contraseña,r.id_tipo_usuario,r.descripcion_tipo_usuario,u.estado_usuario from usuario u
inner join tipo_usuario r on r.id_tipo_usuario = u.id_tipo_usuario

