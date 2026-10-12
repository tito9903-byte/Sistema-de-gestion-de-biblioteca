-- =====================================================================
-- Sistema de Gestión de Biblioteca - Tablas base: roles y usuarios
-- PostgreSQL 18  |  Base de datos: BibliotecaDB
--
-- Ejecutar PRIMERO en una base nueva (antes de schema.sql). Crea las tablas
-- roles y usuarios, los tres roles del sistema y un administrador inicial.
-- Es seguro ejecutarlo más de una vez (IF NOT EXISTS / ON CONFLICT).
--
-- Administrador inicial: usuario "admin", contraseña "Admin123".
-- CAMBIE esa contraseña desde la aplicación después del primer inicio de
-- sesión. La aplicación guarda las contraseñas con PBKDF2 y sal; el hash
-- inicial de este script usa el formato antiguo (SHA-256) y se convierte
-- automáticamente al formato seguro en el primer inicio de sesión.
-- =====================================================================

BEGIN;

CREATE TABLE IF NOT EXISTS roles (
    id_rol     INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre_rol VARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO roles (nombre_rol) VALUES
    ('Administrador'),
    ('Bibliotecario'),
    ('Usuario')
ON CONFLICT (nombre_rol) DO NOTHING;


-- estado: true = Activo, false = Inactivo.
-- password_hash: PBKDF2$iteraciones$sal$hash (o SHA-256 hexadecimal antiguo).
CREATE TABLE IF NOT EXISTS usuarios (
    id_usuario     INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    usuario        VARCHAR(50)  NOT NULL UNIQUE,
    nombre         VARCHAR(100) NOT NULL,
    password_hash  VARCHAR(255) NOT NULL,
    id_rol         INTEGER NOT NULL,
    estado         BOOLEAN NOT NULL DEFAULT true,
    fecha_creacion TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_usuario_rol FOREIGN KEY (id_rol) REFERENCES roles (id_rol)
);


INSERT INTO usuarios (usuario, nombre, password_hash, id_rol, estado)
SELECT 'admin',
       'Administrador',
       upper(encode(sha256(convert_to('Admin123', 'UTF8')), 'hex')),
       (SELECT id_rol FROM roles WHERE nombre_rol = 'Administrador'),
       true
WHERE NOT EXISTS (SELECT 1 FROM usuarios WHERE usuario = 'admin');

COMMIT;
