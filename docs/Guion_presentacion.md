# Guion de presentación – Sistema de Gestión de Biblioteca

Ingeniería de Software II · UAPA · 4 expositores · ~4 minutos cada uno.
Las frases están escritas para decirse en voz alta; adáptenlas con sus propias palabras.
**[DEMO]** indica lo que se hace en pantalla.

---

## 1. Luis Emilio García — Introducción, arquitectura e inicio de sesión

"Buenos días. Somos [nombres del equipo] y vamos a presentar el **Sistema de Gestión de Biblioteca**, proyecto de Ingeniería de Software II.

**El problema.** Cuando una biblioteca controla sus libros y préstamos de forma manual, la información se pierde. Es difícil saber qué libro está prestado, quién lo tiene y cuándo debe devolverlo, y las multas se calculan a mano.

**Nuestra solución** es una aplicación de escritorio que centraliza todo en una base de datos. Permite llevar el catálogo de libros, los préstamos, devoluciones y reservas, controlar el acceso por roles y consultar reportes.

**Tecnologías.** Está hecha en C# con Windows Forms sobre .NET 10. La base de datos es PostgreSQL, conectada con Npgsql, y trabajamos con Visual Studio, Git y GitHub.

**Arquitectura.** Separamos el código en capas. La carpeta *Presentacion* tiene los formularios y no contiene consultas SQL. La carpeta *Clases* tiene una clase DAO por entidad, como `LibroDAO` o `PrestamoDAO`, que concentra las consultas y las reglas de negocio. La carpeta *Conexion* crea la conexión a PostgreSQL. Esto hace el código más ordenado y fácil de mantener.

**[DEMO]** Abrir la aplicación. Intentar entrar con una contraseña incorrecta (mostrar el aviso). Usar el ojo para ver la contraseña. Entrar con un usuario válido y mostrar el panel principal con el menú lateral.

Una nota: la opción 'Olvidé mi contraseña' todavía no está implementada y solo muestra un aviso. Ahora Brian les explica los usuarios y los roles."

---

## 2. Brian Amaury Lora De Dios — Usuarios, roles y seguridad

"El primer módulo que desarrollamos fue **Gestión de Usuarios**. Aquí el administrador puede registrar usuarios, editarlos, buscarlos por nombre, usuario o rol, activarlos, desactivarlos y eliminarlos.

El formulario valida que los campos obligatorios estén completos, que no exista otro usuario con el mismo nombre y que la contraseña y su confirmación coincidan. Al editar, si dejamos la contraseña vacía se conserva la anterior.

**Roles.** Los roles se guardan en la base de datos y se cargan automáticamente en el formulario. Tenemos tres:
- **Administrador:** gestiona usuarios y también ve reportes y gestiona todo lo demás.
- **Bibliotecario:** gestiona libros, préstamos, devoluciones y reservas, y ve reportes, pero no administra usuarios.
- **Usuario (lector):** solo consulta el catálogo y ve sus propios préstamos, devoluciones y reservas. Puede reservar libros para sí mismo.

**Seguridad.** Las contraseñas no se guardan en texto plano: se almacenan con hash SHA-256.

Una limitación que queremos ser claros en mencionar: los permisos se aplican en la interfaz, es decir, mostrando u ocultando botones y secciones. Como mejora futura, queremos aplicarlos también en el servidor.

**[DEMO]** Crear un usuario nuevo, editarlo, desactivarlo y volver a activarlo. Cerrar sesión, entrar con un usuario de rol *Usuario* y mostrar que no aparecen las secciones 'Usuarios' ni 'Reportes'.

Ahora Elio les muestra el ciclo del libro."

---

## 3. Elio De Jesús Dilone — Libros, Préstamos y Devoluciones

"Voy a explicar el corazón del sistema: el ciclo de un libro.

**Libros.** El catálogo permite buscar y ver tarjetas de resumen. Se pueden registrar y editar libros con categoría, año, ISBN, editorial y cantidad de ejemplares. El sistema valida que el ISBN no esté repetido. Si un libro ya tiene préstamos o reservas, no se elimina para no perder el historial: se ofrece marcarlo como inactivo.

**Préstamos.** Al prestar un libro el sistema aplica reglas: el plazo por defecto es de 14 días, cada lector puede tener máximo 3 préstamos activos, no puede llevar dos veces el mismo libro y debe haber ejemplares disponibles. Se puede renovar el préstamo 14 días más, hasta 2 veces, siempre que no esté vencido y que nadie más tenga reservado el libro. El estado 'Vencido' se calcula por la fecha de vencimiento.

**Devoluciones.** Al registrar una devolución se actualiza la disponibilidad del libro. Si hay retraso, el sistema calcula la multa a razón de **$1.00 por día**. Luego se puede marcar la multa como pagada y consultar el historial.

**[DEMO]** Registrar un libro con 2 ejemplares. Hacer un préstamo y mostrar que baja la disponibilidad. Mostrar el aviso al intentar superar una regla (por ejemplo, el mismo libro dos veces). Devolver el libro y mostrar la devolución con y sin retraso, y la multa.

Ahora Eduardo les presenta las reservas y los reportes."

---

## 4. Eduardo Tejada Gutiérrez — Reservas, Reportes, estado del proyecto y cierre

"**Reservas.** Cuando un libro no está disponible, un lector puede reservarlo. Cada reserva tiene una prioridad (alta, normal o baja) y una vigencia, por defecto de 7 días. Cada lector puede tener hasta 3 reservas vigentes. El administrador o bibliotecario puede confirmarlas o cancelarlas. El botón 'Notificar' hoy solo deja constancia en la base de datos: todavía **no envía correos ni mensajes**. El rol Usuario solo puede reservar para sí mismo.

**Reportes.** Se elige el tipo de reporte —préstamos, devoluciones o reservas— y un rango de fechas. El sistema muestra indicadores como libros prestados, usuarios activos y morosidad, un gráfico de barras por mes y la lista de los libros más prestados, devueltos o reservados. El gráfico es un control propio que dibujamos nosotros. El reporte se puede exportar a PDF.

**[DEMO]** Crear una reserva, confirmarla y cancelar otra. Abrir Reportes, cambiar el tipo y el rango de fechas, y exportar a PDF.

**Estado del proyecto.** Todos los módulos están implementados: inicio de sesión, usuarios, libros, préstamos, devoluciones, reservas y reportes. Lo que sigue pendiente es completar las pruebas funcionales de todas las operaciones, la recuperación de contraseña y el envío real de notificaciones.

**Mejoras futuras.** Mover las credenciales de la base de datos fuera del código fuente, usar un hash con sal para las contraseñas, aplicar los permisos también en el servidor y agregar pruebas automatizadas.

**Cierre.** Con este sistema, la biblioteca pasa de registros manuales a una herramienta centralizada que controla libros, préstamos, multas y reservas. Gracias, y quedamos atentos a sus preguntas."

---

## Posibles preguntas del profesor

| Pregunta | Respuesta breve |
|---|---|
| ¿Por qué usar DAO? | Separa el acceso a datos de la interfaz: los formularios no tienen SQL, y los cambios en consultas se hacen en un solo lugar. |
| ¿Cómo se protegen las contraseñas? | Se guardan con hash SHA-256. Como mejora, usaríamos un hash con sal (bcrypt o Argon2). |
| ¿Qué pasa si dos personas piden el mismo último ejemplar? | Las operaciones de préstamo y devolución se ejecutan dentro de transacciones y el sistema verifica los ejemplares disponibles antes de prestar. |
| ¿Los permisos son seguros? | Hoy se controlan en la interfaz. La mejora prevista es aplicarlos también en el servidor. |
| ¿Qué falta? | Pruebas funcionales completas, recuperación de contraseña, envío real de notificaciones y pruebas automatizadas. |
| ¿Cómo se calcula la multa? | Días de retraso × $1.00 por día, al registrar la devolución. |
