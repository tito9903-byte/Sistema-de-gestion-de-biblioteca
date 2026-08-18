# Sistema de Gestión de Biblioteca

Proyecto realizado para la asignatura **Ingeniería de Software II** de la Universidad Abierta para Adultos (UAPA).

## Sobre el proyecto

Este proyecto consiste en desarrollar un sistema para llevar el control de una biblioteca.

La idea es poder registrar los libros, administrar los usuarios y llevar el control de los préstamos y devoluciones. También se manejarán diferentes tipos de usuarios para controlar lo que cada persona puede hacer dentro del sistema.

## Funciones principales

Entre las funciones que tendrá el sistema están:

* Inicio de sesión.
* Registro de usuarios.
* Manejo de roles y permisos.
* Registro de libros.
* Consulta de libros.
* Edición y eliminación de libros.
* Registro de préstamos.
* Registro de devoluciones.
* Consulta de libros disponibles y prestados.

Durante el desarrollo pueden agregarse otras funciones que sean necesarias.

## Organización del proyecto

El proyecto estará organizado inicialmente de la siguiente manera:

```text
SistemaGestionBiblioteca/
│
├── Clases/
├── Conexion/
├── Presentacion/
└── README.md
```

### Clases

Aquí estarán las clases utilizadas por el sistema, incluyendo las clases DAO encargadas de realizar las operaciones con los datos.

Algunas de ellas serán:

* UsuarioDAO
* LibroDAO
* PrestamoDAO
* RolDAO

### Conexion

Aquí estará la clase encargada de realizar la conexión con la base de datos.

### Presentacion

Aquí estarán los formularios y las pantallas que utilizará el usuario, como el inicio de sesión, registro de usuarios, libros y préstamos.

## Patrón DAO

Para trabajar con la base de datos utilizaremos el patrón **DAO (Data Access Object)**.

Esto nos permitirá mantener las consultas y operaciones de la base de datos separadas de los formularios del sistema.

## Participantes

**Grupo M**

* Luis Emilio Garcia Pichardo — 100083094
* Brian Amaury Lora De Dios — 100089342
* Elio De Jesus Dilone — 100092874

## Asignatura

Ingeniería de Software II

## Institución

Universidad Abierta para Adultos (UAPA)

## Estado

Proyecto en desarrollo.
