-- =====================================================================
-- Sistema de Gestión de Biblioteca - Esquema de base de datos
-- PostgreSQL 18  |  Base de datos: BibliotecaDB
--
-- Agrega las tablas de los módulos Libros, Préstamos, Devoluciones y
-- Reservas, más una vista para la actividad reciente del panel principal.
--
-- NO modifica ni borra las tablas existentes (roles, usuarios).
-- Es seguro ejecutarlo más de una vez (usa IF NOT EXISTS).
-- Se ejecuta en una sola transacción: si algo falla, no queda nada a medias.
--
-- Cómo ejecutarlo: abrir en pgAdmin (Query Tool) conectado a BibliotecaDB
-- y ejecutar el archivo completo.
-- =====================================================================

BEGIN;

-- ---------------------------------------------------------------------
-- CATEGORIAS
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS categorias (
    id_categoria  INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre        VARCHAR(60) NOT NULL UNIQUE
);

INSERT INTO categorias (nombre) VALUES
    ('Literatura'),
    ('Ciencia Ficción'),
    ('Tecnología'),
    ('Matemáticas'),
    ('Ciencias'),
    ('Historia'),
    ('Psicología'),
    ('Administración'),
    ('Desarrollo Personal'),
    ('Educación')
ON CONFLICT (nombre) DO NOTHING;


-- ---------------------------------------------------------------------
-- LIBROS
--   codigo: LIB-0001, LIB-0002... (se genera solo a partir del id)
--   estado: true = Activo, false = Inactivo (igual que en usuarios)
--   La disponibilidad ("Disponible"/"Prestado") se deduce de
--   ejemplares_disponibles > 0.
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS libros (
    id_libro               INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    codigo                 VARCHAR(20) GENERATED ALWAYS AS (
                               'LIB-' || CASE WHEN id_libro < 10000
                                              THEN lpad(id_libro::text, 4, '0')
                                              ELSE id_libro::text END
                           ) STORED,
    titulo                 VARCHAR(200) NOT NULL,
    autor                  VARCHAR(150) NOT NULL,
    isbn                   VARCHAR(20) UNIQUE,
    editorial              VARCHAR(100),
    id_categoria           INTEGER NOT NULL REFERENCES categorias (id_categoria),
    anio_publicacion       SMALLINT CHECK (anio_publicacion BETWEEN 1 AND 2100),
    ejemplares_total       INTEGER NOT NULL DEFAULT 1 CHECK (ejemplares_total >= 0),
    ejemplares_disponibles INTEGER NOT NULL DEFAULT 1 CHECK (ejemplares_disponibles >= 0),
    estado                 BOOLEAN NOT NULL DEFAULT true,
    fecha_registro         TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT ck_libros_disponibles CHECK (ejemplares_disponibles <= ejemplares_total),
    CONSTRAINT uq_libros_codigo UNIQUE (codigo)
);

CREATE INDEX IF NOT EXISTS ix_libros_titulo    ON libros (lower(titulo));
CREATE INDEX IF NOT EXISTS ix_libros_autor     ON libros (lower(autor));
CREATE INDEX IF NOT EXISTS ix_libros_categoria ON libros (id_categoria);


-- ---------------------------------------------------------------------
-- PRESTAMOS
--   codigo: P-000001...
--   estado: 'Activo' o 'Devuelto'. "Vencido" NO se guarda: se calcula
--           (estado = 'Activo' AND fecha_vencimiento < CURRENT_DATE).
--   id_usuario: el lector (usuario con rol "Usuario").
--   id_usuario_registro: quién registró el préstamo (bibliotecario/admin).
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS prestamos (
    id_prestamo          INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    codigo               VARCHAR(20) GENERATED ALWAYS AS (
                             'P-' || CASE WHEN id_prestamo < 1000000
                                          THEN lpad(id_prestamo::text, 6, '0')
                                          ELSE id_prestamo::text END
                         ) STORED,
    id_usuario           INTEGER NOT NULL REFERENCES usuarios (id_usuario),
    id_libro             INTEGER NOT NULL REFERENCES libros (id_libro),
    fecha_prestamo       TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    fecha_vencimiento    DATE NOT NULL,
    fecha_devolucion     TIMESTAMP,
    estado               VARCHAR(15) NOT NULL DEFAULT 'Activo'
                             CHECK (estado IN ('Activo', 'Devuelto')),
    renovaciones         SMALLINT NOT NULL DEFAULT 0 CHECK (renovaciones >= 0),
    observacion          VARCHAR(250),
    id_usuario_registro  INTEGER REFERENCES usuarios (id_usuario),
    CONSTRAINT uq_prestamos_codigo UNIQUE (codigo),
    CONSTRAINT ck_prestamos_fechas CHECK (
        fecha_vencimiento >= fecha_prestamo::date
        AND (fecha_devolucion IS NULL OR fecha_devolucion >= fecha_prestamo)
    ),
    CONSTRAINT ck_prestamos_estado_fecha CHECK (
        (estado = 'Devuelto' AND fecha_devolucion IS NOT NULL)
        OR (estado = 'Activo' AND fecha_devolucion IS NULL)
    )
);

CREATE INDEX IF NOT EXISTS ix_prestamos_usuario ON prestamos (id_usuario);
CREATE INDEX IF NOT EXISTS ix_prestamos_libro   ON prestamos (id_libro);
CREATE INDEX IF NOT EXISTS ix_prestamos_estado  ON prestamos (estado, fecha_vencimiento);


-- ---------------------------------------------------------------------
-- DEVOLUCIONES
--   codigo: DEV-0001...
--   Una devolución por préstamo.
--   Estado "A tiempo" / "Con retraso": se deduce de dias_retraso > 0.
--   multa: monto calculado al devolver (la tarifa por día la define la
--          aplicación). multa_pagada = false => cuenta como pendiente.
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS devoluciones (
    id_devolucion        INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    codigo               VARCHAR(20) GENERATED ALWAYS AS (
                             'DEV-' || CASE WHEN id_devolucion < 10000
                                            THEN lpad(id_devolucion::text, 4, '0')
                                            ELSE id_devolucion::text END
                         ) STORED,
    id_prestamo          INTEGER NOT NULL UNIQUE REFERENCES prestamos (id_prestamo),
    fecha_devolucion     TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    dias_retraso         INTEGER NOT NULL DEFAULT 0 CHECK (dias_retraso >= 0),
    multa                NUMERIC(10, 2) NOT NULL DEFAULT 0 CHECK (multa >= 0),
    multa_pagada         BOOLEAN NOT NULL DEFAULT false,
    id_usuario_registro  INTEGER REFERENCES usuarios (id_usuario),
    CONSTRAINT uq_devoluciones_codigo UNIQUE (codigo)
);

CREATE INDEX IF NOT EXISTS ix_devoluciones_fecha ON devoluciones (fecha_devolucion);


-- ---------------------------------------------------------------------
-- RESERVAS
--   codigo: R0001...
--   estado: 'Activa', 'Confirmada', 'Cancelada' o 'Cumplida'.
--           "Por vencer" NO se guarda: se calcula por fecha_vencimiento.
--   prioridad: 'Alta', 'Normal' o 'Baja'.
--   notificado: se marca al usar el botón "Notificar".
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS reservas (
    id_reserva           INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    codigo               VARCHAR(20) GENERATED ALWAYS AS (
                             'R' || CASE WHEN id_reserva < 10000
                                         THEN lpad(id_reserva::text, 4, '0')
                                         ELSE id_reserva::text END
                         ) STORED,
    id_usuario           INTEGER NOT NULL REFERENCES usuarios (id_usuario),
    id_libro             INTEGER NOT NULL REFERENCES libros (id_libro),
    fecha_reserva        TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    fecha_vencimiento    DATE NOT NULL,
    estado               VARCHAR(15) NOT NULL DEFAULT 'Activa'
                             CHECK (estado IN ('Activa', 'Confirmada', 'Cancelada', 'Cumplida')),
    prioridad            VARCHAR(10) NOT NULL DEFAULT 'Normal'
                             CHECK (prioridad IN ('Alta', 'Normal', 'Baja')),
    notificado           BOOLEAN NOT NULL DEFAULT false,
    CONSTRAINT uq_reservas_codigo UNIQUE (codigo),
    CONSTRAINT ck_reservas_fechas CHECK (fecha_vencimiento >= fecha_reserva::date)
);

CREATE INDEX IF NOT EXISTS ix_reservas_usuario ON reservas (id_usuario);
CREATE INDEX IF NOT EXISTS ix_reservas_libro   ON reservas (id_libro);
CREATE INDEX IF NOT EXISTS ix_reservas_estado  ON reservas (estado, fecha_vencimiento);


-- ---------------------------------------------------------------------
-- VISTA: actividad reciente (tabla "Actividad reciente" del panel principal)
-- Une préstamos, devoluciones y reservas ordenables por fecha.
-- ---------------------------------------------------------------------
CREATE OR REPLACE VIEW vw_actividad_reciente AS
    SELECT p.fecha_prestamo AS fecha,
           'Préstamo'::text AS tipo,
           u.nombre         AS usuario,
           l.titulo         AS detalle
    FROM prestamos p
    JOIN usuarios u ON u.id_usuario = p.id_usuario
    JOIN libros   l ON l.id_libro   = p.id_libro
    UNION ALL
    SELECT d.fecha_devolucion,
           'Devolución'::text,
           u.nombre,
           l.titulo
    FROM devoluciones d
    JOIN prestamos p ON p.id_prestamo = d.id_prestamo
    JOIN usuarios  u ON u.id_usuario  = p.id_usuario
    JOIN libros    l ON l.id_libro    = p.id_libro
    UNION ALL
    SELECT r.fecha_reserva,
           'Reserva'::text,
           u.nombre,
           l.titulo
    FROM reservas r
    JOIN usuarios u ON u.id_usuario = r.id_usuario
    JOIN libros   l ON l.id_libro   = r.id_libro;

COMMIT;
