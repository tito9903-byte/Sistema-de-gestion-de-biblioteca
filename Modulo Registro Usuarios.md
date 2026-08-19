Módulo de Creación y Gestión de Usuarios por Roles
1. Descripción del módulo
El módulo de creación y gestión de usuarios forma parte del Sistema de Gestión de Biblioteca y tiene como finalidad administrar las cuentas de las personas que utilizarán el sistema. El módulo permite registrar usuarios, asignarles un rol, establecer su estado y posteriormente consultar o modificar su información.
La utilización de roles permite controlar los diferentes niveles de acceso dentro de la aplicación. De esta manera, no todos los usuarios tienen necesariamente las mismas responsabilidades ni los mismos permisos dentro del sistema.
El módulo se encuentra desarrollado en C# utilizando Windows Forms y está integrado con una clase UsuarioDAO, encargada de realizar las operaciones relacionadas con los usuarios y los roles.
2. Funcionalidades del módulo
Actualmente, el módulo permite realizar diferentes operaciones relacionadas con la administración de usuarios:
Registro de nuevos usuarios.
Selección del rol correspondiente.
Selección del estado del usuario.
Validación de información obligatoria.
Verificación de la selección de un rol.
Edición de usuarios existentes.
Carga de información de un usuario para modificarla.
Cambio de contraseña.
Confirmación de la nueva contraseña.
Activación o desactivación de usuarios.
Cancelación de la operación.
Consulta de los roles disponibles desde la base de datos.
El formulario utiliza diferentes eventos para controlar su funcionamiento. Por ejemplo, al cargarse el formulario se ejecuta el proceso de carga de roles y se establece inicialmente el estado del usuario como Activo.
3. Diseño del formulario
El formulario utilizado para esta funcionalidad se denomina FrmRegistroUsuario.
Su estructura permite introducir y administrar la información necesaria para cada usuario del sistema.
Entre los principales elementos se encuentran:
Campo / elemento	Función
Usuario	Permite establecer el nombre de usuario utilizado para identificarse dentro del sistema.
Nombre	Permite registrar el nombre del usuario.
Rol	Permite seleccionar el rol que tendrá el usuario.
Estado	Permite establecer si el usuario se encuentra activo o inactivo.
Contraseña	Permite establecer la contraseña del usuario.
Confirmación de contraseña	Permite verificar la nueva contraseña introducida.
Guardar	Permite registrar o actualizar la información del usuario.
Cancelar	Permite cancelar la operación actual.


El formulario también utiliza campos de contraseña protegidos visualmente para evitar que la información introducida sea mostrada directamente en pantalla.
4. Gestión de roles
Una de las características principales del módulo es la asignación de roles.
A diferencia de una implementación donde los roles se escriben manualmente dentro del formulario, el sistema obtiene los roles mediante UsuarioDAO.ObtenerRoles() y los carga dinámicamente en el ComboBox correspondiente.
El formulario utiliza:
nombre_rol como valor que se muestra al usuario.
id_rol como valor utilizado internamente para identificar el rol.
Esto permite que los roles sean administrados desde la base de datos y utilizados posteriormente para determinar los privilegios correspondientes.
Roles del sistema
De acuerdo con la estructura actual del proyecto, los roles utilizados por el sistema son:
Administrador
Bibliotecario
Usuario
Los privilegios específicos de cada rol deben mantenerse alineados con las funciones que el equipo haya definido para el sistema.
5. Gestión del estado del usuario
Además del rol, el formulario permite establecer el estado de cada cuenta.
Actualmente se manejan dos estados:
Activo
Inactivo
Al crear un usuario, el formulario establece inicialmente el estado Activo. Cuando se edita un usuario existente, el sistema carga su estado actual y permite modificarlo.
Esta funcionalidad permite desactivar una cuenta sin necesidad de eliminarla completamente del sistema.
6. Validaciones del formulario
El módulo incorpora validaciones antes de realizar el registro o modificación de un usuario.
Entre ellas se encuentra la comprobación de que se hayan introducido los datos básicos del usuario. Si los campos requeridos no están completos, el sistema muestra un mensaje de advertencia y detiene el proceso.
También se verifica que el usuario haya seleccionado un rol antes de continuar y que se haya seleccionado un estado.
Estas validaciones permiten reducir errores durante el registro y evitar que se almacene información incompleta.
7. Edición de usuarios
El módulo no se limita al registro de usuarios nuevos. También permite cargar la información de un usuario existente para modificarla.
Cuando se recibe el identificador del usuario, FrmRegistroUsuario utiliza UsuarioDAO.ObtenerUsuario(idUsuario) para recuperar la información correspondiente.
Posteriormente, los datos recuperados son colocados nuevamente en los controles del formulario, incluyendo el usuario, nombre, rol y estado.
Cuando se encuentra en modo edición, el título del formulario cambia a:
“Editar Usuario”
También se permite establecer una nueva contraseña o dejar los campos correspondientes vacíos para conservar la contraseña existente.
8. Acceso a datos mediante UsuarioDAO
Para separar la interfaz de usuario de las operaciones relacionadas con la base de datos se utiliza la clase:
UsuarioDAO
El patrón DAO, o Data Access Object, permite concentrar las operaciones de acceso a los datos en una clase específica.
De esta manera, FrmRegistroUsuario se encarga principalmente de la interacción con el usuario, mientras que UsuarioDAO se ocupa de las operaciones relacionadas con la información almacenada.
Entre las operaciones utilizadas por el módulo se encuentra la obtención de roles y la consulta de información de usuarios.
9. Relación con la arquitectura de la aplicación
El módulo se integra dentro de una estructura en la que las responsabilidades se encuentran separadas.
De forma general, el flujo puede representarse de la siguiente manera:

PRESENTACIÓN          
FrmRegistroUsuario      

               
ACCESO A DATOS         
                              
UsuarioDAO           
              

BASE DE DATOS          
                               
Usuarios / Roles          

El formulario pertenece a la parte de presentación, mientras que UsuarioDAO concentra las operaciones de acceso a datos.
Esta separación facilita que los cambios realizados en la interfaz no tengan que modificar directamente todas las operaciones relacionadas con la base de datos.
10. Flujo general del registro
El funcionamiento general del módulo puede resumirse de la siguiente manera:
Inicio
  
  
Abrir formulario
  
  
Cargar roles
  
  
Introducir información
  
  
Seleccionar rol
  
  
Seleccionar estado
  
  
Validar información
  
Información incorrecta
          
Mostrar aviso
  
  
UsuarioDAO
  
  
Base de datos
  
  
Usuario registrado/actualizado
Cuando el formulario se abre, se cargan los roles disponibles mediante UsuarioDAO. Posteriormente, el usuario introduce la información correspondiente y el sistema realiza las validaciones antes de continuar con la operación.
11. Seguridad
El módulo contempla medidas relacionadas con la protección de las credenciales del usuario.
Las contraseñas se manejan mediante campos protegidos visualmente en el formulario. Además, la gestión de usuarios se realiza mediante el UsuarioDAO, evitando colocar directamente las operaciones de base de datos dentro del código de la interfaz.
La asignación de roles también constituye un mecanismo importante de seguridad, ya que permite establecer diferentes niveles de acceso dentro del sistema.
12. Tecnologías utilizadas
Para el desarrollo del módulo se utilizan las siguientes tecnologías:
Lenguaje: C#
Interfaz gráfica: Windows Forms
Entorno de desarrollo: Visual Studio
Base de datos: PostgreSQL
Acceso a datos: Npgsql
Patrón de acceso a datos: DAO
Control de versiones: Git y GitHub
13. Estado actual del módulo
A diferencia de la primera versión de la documentación, el módulo ya no se encuentra solamente en etapa de diseño visual.
Actualmente cuenta con implementación para:
Cargar roles.
Registrar usuarios.
Validar información.
Consultar usuarios.
Editar usuarios.
Gestionar estados.
Gestionar contraseñas.
Trabajar con UsuarioDAO.
Interactuar con la base de datos.
Por lo tanto, el módulo puede considerarse una funcionalidad desarrollada e integrada al proyecto, aunque todavía puede continuar ampliándose conforme avance el sistema.
14. Evidencias del desarrollo
Para la documentación final se recomienda incluir capturas de:
Figura 1. Formulario de registro de usuarios.
Insertar captura de FrmRegistroUsuario.

Figura 2. Formulario de gestión/listado de usuarios.
Insertar captura de la pantalla donde se visualizan los usuarios.

Figura 3. Inicio de sesión.
Insertar captura de frmLogin.

Figura 4. Sistema funcionando después del inicio de sesión.
Insertar captura de frmMain.
