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

> Los permisos se controlan únicamente en la interfaz (botones y secciones visibles). No existen restricciones a nivel de base de datos.

## Arquitectura

El código está separado en capas y usa el patrón **DAO (Data Access Object)**:

| Capa | Carpeta | Responsabilidad |
|---|---|---|
| Presentación | `Presentacion/` | Formularios y controles. Gestionan la interacción y las validaciones de pantalla. |
| Acceso a datos y reglas | `Clases/` | Una clase DAO por entidad (`UsuarioDAO`, `LibroDAO`, `PrestamoDAO`, `DevolucionDAO`, `ReservaDAO`, `ReporteDAO`, `InicioDAO`). Contienen las consultas SQL y las reglas de negocio (límites, multas, renovaciones). |
| Conexión | `Conexion/` | `ConexionBD` crea las conexiones Npgsql. |
| Sesión | `Clases/Sesion.cs` | Guarda el usuario autenticado durante la ejecución. |

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
        ├── Clases/
        │   ├── UsuarioDAO.cs
        │   ├── LibroDAO.cs
        │   ├── PrestamoDAO.cs
        │   ├── DevolucionDAO.cs
        │   ├── ReservaDAO.cs
        │   ├── ReporteDAO.cs
        │   ├── InicioDAO.cs
        │   └── Sesion.cs
        ├── Conexion/
        │   └── ConexionBD.cs
        ├── Database/
        │   ├── schema.sql               # Tablas de libros, préstamos, devoluciones y reservas
        │   └── datos_ejemplo.sql        # Datos de prueba (opcional)
        ├── Presentacion/
        │   ├── frmLogin.cs
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
- PostgreSQL y pgAdmin (o `psql`).

### Pasos

1. **Clonar el repositorio** y cambiar a la rama de trabajo:
   ```bash
   git clone https://github.com/tito9903-byte/Sistema-de-gestion-de-biblioteca.git
   git checkout feature/interfaces-ui
   ```
2. **Crear la base de datos** `BibliotecaDB` en PostgreSQL.
3. **Crear las tablas `roles` y `usuarios`.** El código espera estas columnas: `roles(id_rol, nombre_rol)` y `usuarios(id_usuario, usuario, nombre, password_hash, id_rol, estado)`. Los roles deben llamarse exactamente `Administrador`, `Bibliotecario` y `Usuario`. Estas dos tablas no tienen todavía un script en el repositorio.
4. **Ejecutar `Database/schema.sql`** en la base de datos. Es idempotente y no modifica `roles` ni `usuarios`.
5. **Crear al menos un usuario administrador.** La contraseña se almacena como SHA-256 en hexadecimal y mayúsculas en `password_hash`.
6. *(Opcional)* Ejecutar `Database/datos_ejemplo.sql`. Inserta libros, préstamos, devoluciones y reservas de prueba y asigna los préstamos y reservas a los usuarios con rol `Usuario` que ya existan. Si ya hay libros, no hace nada.
7. **Configurar la conexión** en `Conexion/ConexionBD.cs` con el servidor, puerto, base de datos, usuario y contraseña de su propia instancia de PostgreSQL. No publique credenciales reales en el repositorio.
8. **Abrir y ejecutar:** abrir `SistemaDeGestionDeBiblioteca.csproj` en Visual Studio y ejecutar con **F5**, o desde la terminal:
   ```bash
   cd SistemaGestionBibliotecas/SistsemaGestionBlioteca
   dotnet run
   ```

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
| Aplicación de `schema.sql` y `datos_ejemplo.sql` en PostgreSQL local | Correcta |
| Visualización de los datos en cada pantalla | Pendiente de verificar de forma sistemática |
| Inicio de sesión y gestión de usuarios | Desarrollados desde la primera entrega; falta una prueba formal de todos los casos |
| Operaciones de escritura (registrar préstamo, renovar, devolver, multas, reservas, alta/edición/baja de libros) | **Pendiente de pruebas funcionales** |
| Permisos por rol en la interfaz | **Pendiente de probar** con una cuenta de cada rol |
| Exportación de reportes a PDF | **Pendiente de probar** |
| Pruebas automatizadas | No existen |

## Estado del proyecto

| Parte | Estado |
|---|---|
| Inicio de sesión, panel principal y menú por rol | Implementado |
| Usuarios, Libros, Préstamos, Devoluciones, Reservas y Reportes | Implementado, con pruebas funcionales pendientes |
| Recuperación de contraseña | No implementada |
| Envío real de notificaciones de reservas | No implementado (solo se registra) |

**Mejoras pendientes**
- Mover las credenciales de la base de datos fuera del código fuente (archivo de configuración o variables de entorno).
- Reemplazar el hash SHA-256 simple por un algoritmo con sal, como bcrypt o Argon2.
- Aplicar los permisos también en el servidor o la base de datos, no solo en la interfaz.
- Agregar un script para las tablas `roles` y `usuarios`.
- Corregir la ruta del proyecto en `SistemaDeBiblioteca.slnx`, que apunta a una carpeta anterior.
- Agregar pruebas automatizadas e incorporar las capturas reales del sistema.

## Integrantes del equipo

- Luis Emilio García Pichardo
- Brian Amaury Lora De Dios
- Elio De Jesús Dilone
- Eduardo Tejada Gutiérrez
