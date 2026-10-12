-- =====================================================================
-- Sistema de Gestión de Biblioteca - Datos de ejemplo (OPCIONAL)
-- Ejecutar DESPUÉS de schema.sql.
--
-- Inserta libros, préstamos, devoluciones y reservas de prueba para ver
-- las pantallas con datos. Los préstamos y reservas se asignan a los
-- usuarios con rol "Usuario" que ya existan en la tabla usuarios
-- (no crea usuarios ni contraseñas).
--
-- Es seguro ejecutarlo varias veces: si ya existen libros, no hace nada.
-- Las fechas son relativas a hoy, así que siempre hay préstamos vencidos,
-- reservas por vencer, etc.
-- =====================================================================

DO $$
DECLARE
    lectores INTEGER[];
    n        INTEGER;
BEGIN
    IF EXISTS (SELECT 1 FROM libros) THEN
        RAISE NOTICE 'Ya existen libros; no se insertan datos de ejemplo.';
        RETURN;
    END IF;

    -- ---------------- Libros ----------------
    INSERT INTO libros (titulo, autor, id_categoria, anio_publicacion,
                        ejemplares_total, ejemplares_disponibles)
    SELECT v.titulo, v.autor, c.id_categoria, v.anio, v.total, v.total
    FROM (VALUES
        (1,  'El Principito',                  'Antoine de Saint-Exupéry', 'Literatura',          1943, 3),
        (2,  'Cien años de soledad',           'Gabriel García Márquez',   'Literatura',          1967, 3),
        (3,  'Don Quijote de la Mancha',       'Miguel de Cervantes',      'Literatura',          1605, 2),
        (4,  '1984',                           'George Orwell',            'Ciencia Ficción',     1949, 2),
        (5,  'Clean Code',                     'Robert C. Martin',         'Tecnología',          2008, 3),
        (6,  'Introducción a la Programación', 'Luis Joyanes Aguilar',     'Tecnología',          2018, 3),
        (7,  'Estructuras de Datos',           'Mark Allen Weiss',         'Tecnología',          2012, 2),
        (8,  'Matemáticas Discretas',          'Kenneth H. Rosen',         'Matemáticas',         2011, 2),
        (9,  'Física Universitaria',           'Sears y Zemansky',         'Ciencias',            2010, 2),
        (10, 'Química General',                'Raymond Chang',            'Ciencias',            2013, 2),
        (11, 'Biología',                       'Curtis, Barnes, Schnek',   'Ciencias',            2016, 2),
        (12, 'Historia de México',             'Enrique Krauze',           'Historia',            2010, 2),
        (13, 'Psicología',                     'David G. Myers',           'Psicología',          2014, 2),
        (14, 'Administración',                 'Stephen P. Robbins',       'Administración',      2013, 2),
        (15, 'Inteligencia Artificial',        'Stuart Russell',           'Tecnología',          2020, 3),
        (16, 'Hábitos Atómicos',               'James Clear',              'Desarrollo Personal', 2018, 2),
        (17, 'Diseño de Bases de Datos',       'Carlos Coronel',           'Tecnología',          2019, 2),
        (18, 'El Sistema Solar',               'Isaac Asimov',             'Ciencias',            1990, 2),
        (19, 'Redes de Computadoras',          'Andrew S. Tanenbaum',      'Tecnología',          2012, 2),
        (20, 'La Sombra del Viento',           'Carlos Ruiz Zafón',        'Literatura',          2001, 2)
    ) AS v(ord, titulo, autor, categoria, anio, total)
    JOIN categorias c ON c.nombre = v.categoria
    ORDER BY v.ord;

    -- ---------------- Lectores existentes ----------------
    SELECT array_agg(id_usuario ORDER BY id_usuario)
      INTO lectores
      FROM usuarios
     WHERE estado
       AND id_rol = (SELECT id_rol FROM roles WHERE nombre_rol = 'Usuario');

    IF lectores IS NULL THEN
        RAISE NOTICE 'No hay usuarios activos con rol "Usuario": se insertaron solo los libros. '
                     'Cree lectores desde la aplicación y vuelva a ejecutar este script en una base sin libros.';
        RETURN;
    END IF;

    n := array_length(lectores, 1);

    -- ---------------- Préstamos ----------------
    -- dias_atras: hace cuántos días se prestó (plazo de 14 días).
    --   > 14 y sin devolver  => Vencido
    -- dev_dias: hace cuántos días se devolvió (NULL = sigue activo).
    INSERT INTO prestamos (id_usuario, id_libro, fecha_prestamo, fecha_vencimiento,
                           fecha_devolucion, estado, observacion)
    SELECT lectores[(p.ord % n) + 1],
           l.id_libro,
           now() - make_interval(days => p.dias_atras),
           (CURRENT_DATE - p.dias_atras) + 14,
           CASE WHEN p.dev_dias IS NULL THEN NULL
                ELSE now() - make_interval(days => p.dev_dias) END,
           CASE WHEN p.dev_dias IS NULL THEN 'Activo' ELSE 'Devuelto' END,
           NULL
    FROM (VALUES
        (1,  'El Principito',                  10, NULL::INTEGER),
        (2,  'Clean Code',                     12, NULL),
        (3,  'Estructuras de Datos',           18, NULL),
        (4,  'Hábitos Atómicos',                6, NULL),
        (5,  'Inteligencia Artificial',         3, NULL),
        (6,  'Introducción a la Programación', 20, NULL),
        (7,  'Matemáticas Discretas',           8, NULL),
        (8,  'Diseño de Bases de Datos',       30, 25),
        (9,  'El Sistema Solar',               25, 12),
        (10, 'Cien años de soledad',           22, 10),
        (11, 'Clean Code',                     40, 28),
        (12, 'Redes de Computadoras',          35, 15),
        (13, 'La Sombra del Viento',           45, 20),
        (14, 'El Principito',                  50, 40),
        (15, 'Química General',                15, 2)
    ) AS p(ord, titulo, dias_atras, dev_dias)
    JOIN libros l ON l.titulo = p.titulo
    ORDER BY p.ord;

    -- ---------------- Devoluciones de los préstamos devueltos ----------------
    -- Multa de ejemplo: 1.00 por día de retraso.
    INSERT INTO devoluciones (id_prestamo, fecha_devolucion, dias_retraso, multa, multa_pagada)
    SELECT p.id_prestamo,
           p.fecha_devolucion,
           GREATEST(p.fecha_devolucion::date - p.fecha_vencimiento, 0),
           GREATEST(p.fecha_devolucion::date - p.fecha_vencimiento, 0) * 1.00,
           false
    FROM prestamos p
    WHERE p.estado = 'Devuelto'
    ORDER BY p.fecha_devolucion;

    -- ---------------- Reservas ----------------
    INSERT INTO reservas (id_usuario, id_libro, fecha_reserva, fecha_vencimiento,
                          estado, prioridad)
    SELECT lectores[(r.ord % n) + 1],
           l.id_libro,
           now() - make_interval(days => r.dias_atras),
           CURRENT_DATE + r.vence_en,
           r.estado,
           r.prioridad
    FROM (VALUES
        (1,  'El Principito',                  1, 6,  'Activa',    'Normal'),
        (2,  'Cien años de soledad',           2, 5,  'Activa',    'Alta'),
        (3,  'Estructuras de Datos',           3, 2,  'Activa',    'Alta'),
        (4,  'Hábitos Atómicos',               4, 1,  'Activa',    'Normal'),
        (5,  'Diseño de Bases de Datos',       5, 6,  'Activa',    'Normal'),
        (6,  'Inteligencia Artificial',        6, 3,  'Cancelada', 'Normal'),
        (7,  'El Sistema Solar',               6, 4,  'Confirmada','Baja'),
        (8,  'Clean Code',                     7, 2,  'Activa',    'Alta'),
        (9,  'Introducción a la Programación', 8, 5,  'Activa',    'Normal'),
        (10, 'Matemáticas Discretas',          9, 3,  'Cancelada', 'Normal')
    ) AS r(ord, titulo, dias_atras, vence_en, estado, prioridad)
    JOIN libros l ON l.titulo = r.titulo
    ORDER BY r.ord;

    -- ---------------- Ajustar disponibilidad según préstamos activos ----------------
    UPDATE libros l
       SET ejemplares_disponibles = l.ejemplares_total - (
               SELECT count(*) FROM prestamos p
                WHERE p.id_libro = l.id_libro AND p.estado = 'Activo');

    RAISE NOTICE 'Datos de ejemplo insertados correctamente.';
END
$$;
