-- =====================================================================
-- Sistema de Gestión de Biblioteca - Usuarios del equipo (lectores)
-- Ejecutar ANTES de datos_ejemplo.sql (y después de schema.sql), para que
-- los préstamos y reservas de ejemplo se asignen a estas personas.
--
-- Crea 4 usuarios con rol "Usuario". Contraseña inicial de todos: 1234
-- (se guarda como SHA-256 en mayúsculas, igual que la aplicación).
-- Es seguro ejecutarlo varias veces: si el usuario ya existe, lo omite.
-- =====================================================================

INSERT INTO usuarios (usuario, nombre, password_hash, id_rol, estado)
SELECT v.usuario,
       v.nombre,
       upper(encode(sha256(convert_to('1234', 'UTF8')), 'hex')),
       (SELECT id_rol FROM roles WHERE nombre_rol = 'Usuario'),
       true
FROM (VALUES
    ('luis.garcia',   'Luis Emilio Garcia Pichardo'),
    ('brian.lora',    'Brian Amaury Lora De Dios'),
    ('elio.dilone',   'Elio De Jesus Dilone'),
    ('eduardo.tejada','Eduardo Tejada Gutiérrez')
) AS v(usuario, nombre)
WHERE NOT EXISTS (SELECT 1 FROM usuarios u WHERE u.usuario = v.usuario);
