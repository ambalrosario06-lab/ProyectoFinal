# Gestor de Contraseñas

## Descripción del proyecto

El Gestor de Contraseñas es una aplicación de consola desarrollada en C# que permite administrar y almacenar contraseñas de manera organizada.

La aplicación permite agregar, visualizar, actualizar y eliminar registros de contraseñas. La información se almacena de forma persistente utilizando una base de datos SQLite.

El proyecto fue desarrollado aplicando Programación Orientada a Objetos, arquitectura por capas y Entity Framework Core para la gestión de los datos.

## Tecnologías utilizadas

- C#
- .NET
- Entity Framework Core
- SQLite
- Spectre.Console

## Arquitectura del proyecto

El proyecto está organizado en diferentes capas para separar las responsabilidades:

- **Database:** configuración del contexto de la base de datos y conexión con SQLite.
- **Models:** contiene las entidades utilizadas por el sistema.
- **Repositories:** gestiona el acceso y las operaciones sobre los datos mediante Entity Framework Core.
- **Services:** contiene la lógica de negocio de la aplicación.
- **Screens:** contiene la interfaz de usuario desarrollada con Spectre.Console.

## Funcionalidades

- Agregar contraseñas.
- Visualizar contraseñas.
- Actualizar contraseñas.
- Eliminar contraseñas.
- Almacenar los datos utilizando SQLite.

## Instrucciones para ejecutar

1. Clonar o descargar el repositorio.
2. Abrir la carpeta del proyecto en Visual Studio Code.
3. Abrir una terminal dentro de la carpeta del proyecto.
4. Ejecutar la aplicación con:

```bash
dotnet run
