# Sistema de Gestión de Biblioteca

Proyecto desarrollado para la asignatura **Ingeniería de Software II** de la Universidad Abierta para Adultos (UAPA).

## Descripción

El proyecto consiste en un Sistema de Gestión de Biblioteca desarrollado en C# utilizando Windows Forms.

En esta etapa se trabajó principalmente el módulo de usuarios, donde se pueden registrar usuarios y asignarles diferentes roles dentro del sistema.

También se agregó un inicio de sesión conectado a la base de datos para validar los usuarios registrados.

## Funciones desarrolladas

Actualmente el sistema permite:

- Iniciar sesión con un usuario registrado.
- Registrar nuevos usuarios.
- Asignar roles a los usuarios.
- Editar usuarios existentes.
- Cambiar la contraseña de un usuario.
- Buscar usuarios por nombre, usuario o rol.
- Activar y desactivar usuarios.
- Eliminar usuarios.
- Validar que no se registren usuarios repetidos.
- Validar que las contraseñas coincidan.
- Consultar los usuarios registrados desde la base de datos.

## Roles

Los roles se encuentran registrados en la base de datos y se cargan automáticamente en el formulario de registro de usuarios.

Entre los roles utilizados se encuentran:

- Administrador
- Bibliotecario
- Usuario

Estos roles permiten identificar el nivel de acceso que tendrá cada usuario dentro del sistema.

## Organización del proyecto

El proyecto está organizado de la siguiente manera:

```text
SistemaDeGestionDeBiblioteca/
│
├── Clases/
│   └── UsuarioDAO.cs
│
├── Conexion/
│   └── ConexionBD.cs
│
├── Presentacion/
│   ├── frmLogin.cs
│   ├── frmMain.cs
│   ├── FrmUsuarios.cs
│   └── FrmRegistroUsuario.cs
│
├── Properties/
│
├── Program.cs
│
└── SistemaDeGestionDeBiblioteca.csproj