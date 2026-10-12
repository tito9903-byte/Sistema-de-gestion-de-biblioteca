# Sistema de Gestión de Biblioteca

Proyecto final de la asignatura **Ingeniería de Software II** de la **Universidad Abierta para Adultos (UAPA)**.

Aplicación de escritorio desarrollada en C# con Windows Forms y PostgreSQL para administrar el catálogo de libros, los usuarios y el ciclo completo de préstamos, devoluciones y reservas de una biblioteca.

## Objetivo

Muchas bibliotecas pequeñas llevan el control de libros, préstamos y multas en registros manuales o dispersos, lo que provoca pérdida de información, libros sin seguimiento y dificultad para saber qué está prestado, quién lo tiene y cuándo debe regresar.

Este sistema centraliza esa información en una base de datos y busca:

- Mantener un catálogo de libros con control de ejemplares disponibles.
- Registrar préstamos, renovaciones, devoluciones y multas por retraso.
- Permitir reservar libros y dar seguimiento a las reservas vigentes.
- Controlar quién puede hacer qué mediante roles de usuario.
- Ofrecer reportes de actividad para apoyar la toma de decisiones.

## Tecnologías utilizadas

| Tecnología | Detalle |
|---|---|
| Lenguaje | C# (nullable habilitado, `ImplicitUsings`) |
| Interfaz | Windows Forms |
| Plataforma | .NET 10 (`net10.0-windows`) |
| Base de datos | PostgreSQL (los scripts están preparados para PostgreSQL 18) |
| Acceso a datos | Npgsql 10.0.3 |
| IDE | Visual Studio |
| Control de versiones | Git y GitHub |

Los gráficos de la pantalla de reportes se dibujan con GDI+ (control propio `GraficoBarras`), por lo que no se usan paquetes adicionales.

## Módulos desarrollados

### Inicio de sesión (`frmLogin`)
- Valida usuario y contraseña contra la base de datos; solo permite el acceso a usuarios activos.
- Botón para mostrar u ocultar la contraseña.
- La opción «Olvidé mi contraseña» solo muestra un aviso: la recuperación no está implementada.

### Panel principal (`frmMain`) e Inicio (`FrmInicio`)
- Menú lateral que muestra solo las secciones permitidas según el rol.
- Pantalla de inicio con tarjetas de resumen, actividad reciente y accesos directos para registrar un libro, un préstamo o una reserva.

### Gestión de Usuarios (`FrmUsuarios`, `FrmRegistroUsuario`)
- Listado y búsqueda por nombre, usuario o rol.
- Registro y edición de usuarios con asignación de rol y estado (Activo/Inactivo).
- Cambio de contraseña (si se deja vacía al editar, se conserva la actual) y confirmación de contraseña.
- Activar/desactivar y eliminar usuarios.
- Validación de campos obligatorios y de nombres de usuario repetidos.

### Gestión de Libros (`FrmLibros`, `FrmRegistroLibro`)
- Catálogo con búsqueda, tarjetas de resumen y vista de detalle.
- Registro y edición de libros (categoría, año, ISBN, editorial, ejemplares totales y disponibles).
- Validación de ISBN repetido.
- Si un libro tiene préstamos o reservas, no se elimina: se ofrece marcarlo como Inactivo.

### Préstamos (`FrmPrestamos`, `FrmNuevoPrestamo`)
- Listado con búsqueda y estados Activo, Vencido y Devuelto (el estado «Vencido» se calcula por fecha).
- Nuevo préstamo con plazo configurable (14 días por defecto).
- Renovación de 14 días, hasta 2 veces; no se renueva si el préstamo está vencido o si otro usuario tiene reservado el libro.
- Reglas al prestar: máximo 3 préstamos activos por lector, no repetir el mismo libro y exigir ejemplares disponibles.
- Registro de devolución y vista de detalle.

### Devoluciones (`FrmDevoluciones`, `FrmRegistrarDevolucion`)
- Listado de devoluciones con indicadores (a tiempo / con retraso).
- Cálculo de multa por retraso a razón de $1.00 por día.
- Marcar multas como pagadas y consultar el historial.

### Reservas (`FrmReservas`, `FrmNuevaReserva`)
- Nueva reserva con prioridad (Alta, Normal, Baja) y vigencia (7 días por defecto), máximo 3 reservas vigentes por lector.
- Confirmar y cancelar reservas.
- «Notificar» solo deja constancia en la base de datos; el sistema **no envía** correos ni mensajes.

### Reportes (`FrmReportes`)
- Reportes de Préstamos, Devoluciones o Reservas por rango de fechas.
- Indicadores (libros prestados, usuarios activos, reservas, morosidad), gráfico de barras por mes y tabla con los libros más prestados, devueltos o reservados.
- Exportación a PDF mediante la impresora «Microsoft Print to PDF» de Windows.

## Roles y permisos

Los roles se guardan en la tabla `roles` y se aplican en la interfaz.

| Función | Administrador | Bibliotecario | Usuario |
|---|:---:|:---:|:---:|
| Gestionar usuarios | Sí | No | No |
| Ver reportes | Sí | Sí | No |
| Registrar, editar y eliminar libros | Sí | Sí | No (solo consulta) |
| Registrar préstamos, renovaciones y devoluciones | Sí | Sí | No |
| Confirmar y notificar reservas | Sí | Sí | No |
| Ver préstamos, devoluciones y reservas | Todos | Todos | Solo los propios |
| Crear y cancelar reservas | Para cualquier lector | Para cualquier lector | Solo para sí mismo |

> Los permisos se aplican en la interfaz (botones y secciones visibles) y también en la capa de acceso a datos (`Clases/Permisos.cs`), que rechaza las operaciones no permitidas para el rol de la sesión. No se aplican restricciones con roles de PostgreSQL: la aplicación se conecta con una sola cuenta de base de datos.

## Arquitectura

El código está separado en capas y usa el patrón **DAO (Data Access Object)**:

| Capa | Carpeta | Responsabilidad |
|---|---|---|
| Presentación | `Presentacion/` | Formularios y controles. Gestionan la interacción y las validaciones de pantalla. |
| Acceso a datos y reglas | `Clases/` | Una clase DAO por entidad (`UsuarioDAO`, `LibroDAO`, `PrestamoDAO`, `DevolucionDAO`, `ReservaDAO`, `ReporteDAO`, `InicioDAO`). Contienen las consultas SQL y las reglas de negocio (límites, multas, renovaciones). |
| Conexión | `Conexion/` | `ConexionBD` crea las conexiones Npgsql. |
| Sesión y permisos | `Clases/Sesion.cs`, `Clases/Permisos.cs` | Guardan el usuario autenticado y validan el rol antes de cada operación. |

Los formularios no ejecutan SQL: llaman a los DAO. Las operaciones que modifican varias tablas (por ejemplo, registrar una devolución y actualizar los ejemplares disponibles) se ejecutan dentro de transacciones.

## Estructura del proyecto

```text
Sistema-de-gestion-de-biblioteca/
├── README.md
├── Modulo Registro Usuarios.md          # Documentación del módulo de usuarios
├── SistemaDeBiblioteca.slnx
└── SistemaGestionBibliotecas/
    └── SistsemaGestionBlioteca/
        ├── SistemaDeGestionDeBiblioteca.csproj
        ├── Program.cs
        ├── conexion.ejemplo.txt         # Plantilla de la cadena de conexión (conexion.local.txt no se sube a Git)
        ├── Clases/
        │   ├── UsuarioDAO.cs
        │   ├── LibroDAO.cs
        │   ├── PrestamoDAO.cs
        │   ├── DevolucionDAO.cs
        │   ├── ReservaDAO.cs
        │   ├── ReporteDAO.cs
        │   ├── InicioDAO.cs
        │   ├── Sesion.cs
        │   ├── Permisos.cs
        │   └── MessageBox.cs            # Avisos centrados sobre la ventana de la aplicación
        ├── Conexion/
        │   ├── ConexionBD.cs
        │   └── PreparadorBD.cs          # Crea la base de datos y las tablas en el primer uso
        ├── Database/
        │   ├── tablas_base.sql          # Tablas roles y usuarios, roles y administrador inicial
        │   ├── schema.sql               # Tablas de libros, préstamos, devoluciones y reservas
        │   └── datos_ejemplo.sql        # Datos de prueba (opcional)
        ├── Presentacion/
        │   ├── frmLogin.cs
        │   ├── FrmConfigurarBD.cs       # Ventana de configuración de PostgreSQL (primer uso)
        │   ├── frmMain.cs
        │   ├── FrmInicio.cs
        │   ├── FrmUsuarios.cs / FrmRegistroUsuario.cs
        │   ├── FrmLibros.cs / FrmRegistroLibro.cs
        │   ├── FrmPrestamos.cs / FrmNuevoPrestamo.cs
        │   ├── FrmDevoluciones.cs / FrmRegistrarDevolucion.cs
        │   ├── FrmReservas.cs / FrmNuevaReserva.cs
        │   ├── FrmReportes.cs
        │   ├── FrmEnConstruccion.cs
        │   └── Controles/
        │       ├── PanelTarjeta.cs
        │       ├── TarjetaResumen.cs
        │       ├── TarjetaAccion.cs
        │       └── GraficoBarras.cs
        ├── Properties/
        └── ReferenciasUI/               # Imágenes de referencia del diseño (no son capturas del sistema)
```

## Instalación y configuración

### Requisitos
- Windows 10 u 11.
- Visual Studio con la carga de trabajo de **desarrollo de escritorio de .NET** y compatibilidad con .NET 10 (SDK 10).
- PostgreSQL instalado y en ejecución, con un usuario que pueda crear bases de datos (por ejemplo `postgres`).

### Pasos

1. **Clonar el repositorio** y cambiar a la rama de trabajo:
   ```bash
   git clone https://github.com/tito9903-byte/Sistema-de-gestion-de-biblioteca.git
   git checkout feature/interfaces-ui
   ```
2. **Abrir y ejecutar:** abrir `SistemaDeGestionDeBiblioteca.csproj` en Visual Studio y ejecutar con **F5**, o desde la terminal:
   ```bash
   cd SistemaGestionBibliotecas/SistsemaGestionBlioteca
   dotnet run
   ```
3. **Configuración automática en el primer uso.** Si no hay una base de datos configurada, la aplicación muestra la ventana «Configurar la base de datos». Escriba el servidor, el puerto, el usuario y la contraseña de su PostgreSQL (la base se llama `BibliotecaDB` por defecto) y pulse **Conectar**. La aplicación:
   - crea la base de datos si no existe;
   - ejecuta los scripts de `Database/` (incluidos dentro del programa): `tablas_base.sql`, `schema.sql`, `usuarios_equipo.sql` y `datos_ejemplo.sql`;
   - guarda la configuración en `%LOCALAPPDATA%\SistemaGestionBiblioteca\conexion.local.txt`, fuera del repositorio, para no volver a preguntar.
4. **Iniciar sesión.** Con los datos de ejemplo existen estos usuarios:
   - `admin` (Administrador). Su contraseña inicial está indicada en `Database/tablas_base.sql`; cámbiela después del primer inicio de sesión. Si la base de datos ya existía y no tiene ningún Administrador, la aplicación lo crea al arrancar (con el nombre `admin`, o `admin_inicial` si `admin` ya estaba en uso).
   - `luis.garcia`, `brian.lora`, `elio.dilone` y `eduardo.tejada` (rol Usuario), usados para las pruebas. Sus contraseñas iniciales están en `Database/usuarios_equipo.sql`.

**Configuración manual (opcional).** En lugar de la ventana de primer uso se puede copiar `conexion.ejemplo.txt` como `conexion.local.txt` (junto al `.csproj`) o definir la variable de entorno `BIBLIOTECA_CONEXION` con la cadena de conexión. También se pueden ejecutar los scripts de `Database/` a mano con pgAdmin o `psql`, en el orden indicado arriba.

## Capturas del sistema

Las capturas reales del sistema en ejecución están pendientes de incorporar. Las imágenes de `ReferenciasUI/` son diseños de referencia, no evidencia de funcionamiento.

| Pantalla | Estado |
|---|---|
| Inicio de sesión | Pendiente |
| Panel principal / Inicio | Pendiente |
| Gestión de Usuarios | Pendiente |
| Gestión de Libros | Pendiente |
| Préstamos | Pendiente |
| Devoluciones | Pendiente |
| Reservas | Pendiente |
| Reportes | Pendiente |

## Pruebas y validaciones

| Aspecto | Estado |
|---|---|
| Compilación del proyecto (`dotnet build`) | Correcta, sin errores ni advertencias |
| Creación de la base desde cero (`tablas_base.sql`, `schema.sql`, `datos_ejemplo.sql`) | Correcta, y repetible sin errores |
| Inicio de sesión, aviso por credenciales incorrectas y acceso por rol | Verificado con ejecución real de las ventanas sobre una copia de la base |
| Registro de usuarios, libros (alta y edición), préstamos, renovaciones, devoluciones con multa, reservas y reportes | Verificado a nivel de lógica y base de datos |
| Validación de campos obligatorios en los formularios | Verificada en libro, préstamo, reserva, devolución y usuario |
| Navegación por todos los módulos con cada rol | Verificada sin errores |
| Permisos por rol en el acceso a datos (Administrador, Bibliotecario, Usuario) | Verificados |
| Contraseñas con PBKDF2 y sal, y actualización automática de hashes antiguos | Verificado |
| Avisos y ventanas centrados sobre la aplicación | Verificado |
| Configuración automática de la base de datos en una copia limpia del proyecto (contraseña incorrecta, servidor caído, base nueva, base vacía y repetición) | Verificado |
| Recorrido manual con mouse y teclado de cada pantalla | **Pendiente** |
| Exportación de reportes a PDF | **Pendiente de probar** |
| Rendimiento con grandes volúmenes de datos | **Sin medir** |
| Pruebas automatizadas dentro del repositorio | No existen (las verificaciones se ejecutaron de forma externa) |

## Estado del proyecto

| Parte | Estado |
|---|---|
| Inicio de sesión, panel principal y menú por rol | Implementado |
| Usuarios, Libros, Préstamos, Devoluciones, Reservas y Reportes | Implementado y verificado con pruebas ejecutadas; falta el recorrido manual con capturas |
| Recuperación de contraseña | No implementada |
| Envío real de notificaciones de reservas | No implementado (solo se registra) |

**Mejoras pendientes**
- Cambiar la contraseña de PostgreSQL que estuvo escrita en el código: sigue visible en el historial de Git.
- Usar roles de PostgreSQL con permisos limitados en lugar de una sola cuenta de base de datos.
- Medir el rendimiento con un volumen grande de datos y verificar el sistema en otros equipos.
- Agregar pruebas automatizadas e incorporar las capturas reales del sistema.

## Integrantes del equipo

- Luis Emilio García Pichardo
- Brian Amaury Lora De Dios
- Elio De Jesús Dilone
- Eduardo Tejada Gutiérrez
