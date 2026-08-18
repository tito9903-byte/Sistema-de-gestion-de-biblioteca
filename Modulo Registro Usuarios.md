Módulo de Creación de Usuarios por Roles
1. Descripción del módulo
El módulo de creación de usuarios por roles forma parte del Sistema de Gestión de Biblioteca y tiene como finalidad permitir el registro de las personas que utilizarán el sistema. Además de almacenar los datos básicos de cada usuario, el módulo permite asignarle un rol, de manera que posteriormente se puedan establecer los privilegios y las funciones a las que tendrá acceso dentro de la aplicación.
Este módulo es importante porque el sistema no tendrá el mismo nivel de acceso para todos los usuarios. Por esta razón, la asignación de roles permite organizar los permisos de acuerdo con las responsabilidades de cada persona dentro de la biblioteca.
2. Diseño del formulario
El formulario desarrollado contiene los campos necesarios para registrar la información básica de un usuario. Actualmente se encuentra diseñado en Windows Forms utilizando C# y está preparado para ser integrado posteriormente con la lógica del sistema y la base de datos.
Los campos incluidos son:
Campo	Descripción
Nombre	Permite registrar el nombre del usuario.
Apellido	Permite registrar el apellido del usuario.
Correo	Permite registrar la dirección de correo electrónico del usuario.
Usuario	Permite establecer el nombre que utilizará la persona para identificarse en el sistema.
Contraseña	Permite establecer las credenciales de acceso del usuario.
Rol	Permite seleccionar el nivel de privilegios que tendrá el usuario dentro del sistema.


El formulario también cuenta con los botones Guardar y Limpiar, destinados respectivamente a registrar la información introducida y limpiar los campos del formulario.
3. Roles del sistema
Para el Sistema de Gestión de Biblioteca se han establecido tres roles principales:
Administrador
El administrador tendrá el nivel más alto de privilegios dentro del sistema. Podrá gestionar usuarios y roles, además de tener acceso a las funciones administrativas relacionadas con los libros, préstamos y devoluciones.
Bibliotecario
El bibliotecario estará encargado principalmente de las operaciones relacionadas con el funcionamiento diario de la biblioteca. Entre sus funciones se encuentran la gestión de libros, el registro de préstamos y el registro de devoluciones.
Estudiante
El estudiante tendrá un nivel de acceso limitado a las funciones que necesita como usuario de la biblioteca. Podrá consultar información de los libros, realizar reservas y consultar información relacionada con sus préstamos.
4. Funcionamiento general del módulo
El funcionamiento previsto del módulo comienza cuando un usuario autorizado accede al formulario de registro. En este formulario se introducen los datos personales y las credenciales del nuevo usuario. Posteriormente, se selecciona el rol correspondiente de acuerdo con las funciones que tendrá dentro del sistema.
El proceso general puede representarse de la siguiente manera:
          Inicio
            │
            ▼
   Formulario de registro
            │
            ▼
     Introducir datos
            │
            ▼
      Seleccionar rol
            │
            ▼
    Validar información
            │
            ▼
     Registrar usuario
            │
            ▼
           Fin
La validación y el almacenamiento de la información serán integrados posteriormente con la lógica de negocio y el acceso a la base de datos.
5. Relación con la arquitectura de software
El formulario de creación de usuarios corresponde a la capa de presentación de la arquitectura de la aplicación. Esta capa es la encargada de proporcionar la interfaz mediante la cual el usuario interactúa con el sistema.
La estructura propuesta para el módulo contempla la separación de responsabilidades de la siguiente manera:
┌──────────────────────────────┐
│       PRESENTACIÓN           │
│                              │
│ Formulario de usuarios       │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│      LÓGICA DE NEGOCIO       │
│                              │
│ Validación y gestión         │
│ de usuarios y roles          │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│       ACCESO A DATOS         │
│                              │
│          UsuarioDAO          │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│        BASE DE DATOS         │
└──────────────────────────────┘
Esta organización permite mantener separada la interfaz del usuario de las operaciones relacionadas con los datos. De acuerdo con la estructura definida por el equipo, el acceso a los datos se realizará mediante el patrón DAO (Data Access Object).
En el estado actual del proyecto, el formulario representa principalmente la parte de presentación. La conexión con las demás capas será realizada durante la integración del módulo.
6. Tecnologías utilizadas
Para el desarrollo del módulo se está utilizando:
Lenguaje: C#
Entorno de desarrollo: Visual Studio Community 2026
Tecnología de interfaz: Windows Forms
Control de versiones: Git y GitHub
Arquitectura: 
Acceso a datos: patrón DAO, según la estructura definida para el proyecto.
7. Estado actual del módulo
Actualmente se encuentra diseñado el formulario de creación de usuarios, incluyendo los campos necesarios para registrar los datos del usuario y el selector de roles.
La parte correspondiente a la programación de las validaciones, almacenamiento de los datos y conexión con la base de datos será desarrollada posteriormente como parte de la integración del módulo.
8. Evidencia del desarrollo

Captura del formulario:
