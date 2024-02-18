# Sistema de Búsqueda de Vehículos para Miles Car Rental

## Introducción

Este proyecto implementa un Sistema de Búsqueda de Vehículos para Miles Car Rental, una empresa líder en la industria de alquiler de vehículos. El sistema proporciona una interfaz avanzada que permite a los clientes encontrar vehículos disponibles de manera eficiente y precisa, basándose en criterios específicos de búsqueda.

## Requerimientos Técnicos

- **Versión de .NET**: .NET 7
- **Dependencias Principales**:
  - AutoMapper 13.0.1
  - Microsoft.AspNetCore.Authentication.JwtBearer v7.0.16
  - Microsoft.AspNetCore.Identity.EntityFrameworkCore v7.0.16
  - Microsoft.AspNetCore.Mvc.Testing v7.0.16
  - Microsoft.AspNetCore.OpenApi v7.0.14
  - Microsoft.EntityFrameworkCore 7.0.16
  - Microsoft.EntityFrameworkCore.InMemory v7.0.16
  - Microsoft.EntityFrameworkCore.Tools 7.0.16
  - Microsoft.NET.Test.Sdk 17.9.0
  - Moq 4.20.70
  - MSTest.TestAdapter 3.2.1
  - MSTest.TestFramework 3.2.1
  - MySql.EntityFrameworkCore 7.0.14
  - Serilog.Extensions.Logging.File 3.0.0
  - Swashbuckle.AspNetCore 6.5.0
  - XAct.Core.PCL 0.0.5014

## Características Principales

- **Autenticación y Autorización**: Sistema de autenticación y autorización de usuarios mediante JWT Token.
- **Persistencia de Datos**: Utilización de MySQL como base de datos para la persistencia de datos.
- **Arquitectura Hexagonal**: Implementación de la arquitectura hexagonal para una estructura modular y mantenible.
- **Principios SOLID**: Aplicación de los principios SOLID para un diseño de código eficiente y escalable.
- **Automapper**: Utilización de Automapper para el mapeo de objetos entre capas.
- **DTOs**: Empleo de Objetos de Transferencia de Datos para una separación clara entre capas.
- **Servicios y Repositorios**: Uso de servicios y repositorios para una organización lógica y eficiente del código.
- **Logging**: Registro de errores y respuestas de las peticiones para un seguimiento detallado.
- **Swagger**: Integración de Swagger para documentar y probar la API de manera interactiva.

## Estructura del Proyecto

- **MCRSearch (Solución)**
  - **MCRSearch (Proyecto)**
    - **Logs**: Carpeta donde se guardan los archivos de registro.
    - **Migrations**: Carpeta donde se guardan las migraciones de Entity Framework Core.
    - **src**
      - **MCRSearch.Application**: Capa de aplicación
        - **Dtos**: Almacena los Data Transfer Objects utilizados en la capa de aplicación.
        - **Mapper**: Lógica del AutoMapper.
        - **Services**: Servicios de la aplicación.
      - **MCRSearch.Core**: Capa de lógica de negocio
        - **Entities**: Entidades de la aplicación.
      - **MCRSearch.Infrastructure**: Capa de infraestructura
        - **Filters**: Filtros de acción utilizados en la API.
        - **Middleware**: Middlewares utilizados para interceptar las peticiones y respuestas.
        - **Repositories**: Repositorios siguiendo el patrón de diseño repository.
        - **ApplicationDbContext.cs**: Configuración del IdentityDbContext y seeders.
      - **MCRSearch.Presentation**: Capa de presentación (API)
        - **Controllers**: Controladores de la API.
    - **SharedDtos**: Almacena los Data Transfer Objects compartidos entre diversas capas.
    - **Program.cs**: Configuración y arranque del proyecto.
    - **Startup.cs**: Configuración de servicios y configuración general.

## Instrucciones de Ejecución

1. Clona el repositorio desde [GitHub](https://github.com/juansdev/MCRSearch.git).
2. Abre el proyecto en Visual Studio o tu IDE preferido.
3. Actualiza la URL de conexión en el appsettings.json, del cual se explica en la siguiente sección.
4. Actualiza la base de datos ejecutando los siguientes comandos en la Consola de Administrador de Paquetes (Package Manager Console):
   ```shell
   Update-Database
   Add-Migration InitialMigration
   Update-Database
   ```
5. Ejecuta la aplicación.

## Actualización de URL de Conexión en appsettings.json

Para actualizar la URL de conexión en la llave "ConnectionSql" en el archivo appsettings.json, siga los pasos a continuación:

1. Abra el archivo appsettings.json ubicado en la raíz del proyecto.

2. Ubique la sección "ConnectionStrings" y encuentre la llave "ConnectionSql". La cadena de conexión tiene el siguiente formato:

    ```json
    "ConnectionStrings": {
      "ConnectionSql": "server=localhost;port=3306;user=root;password=thor;database=mcr_search;"
    },
    ```

3. Modifique la URL de conexión según sus necesidades. Asegúrese de proporcionar la información correcta para el servidor, puerto, nombre de usuario, contraseña y base de datos.

   Por ejemplo, si desea cambiar el servidor a "nuevoservidor" y el puerto a "1234", la cadena de conexión se vería así:

    ```json
    "ConnectionStrings": {
      "ConnectionSql": "server=nuevoservidor;port=1234;user=root;password=thor;database=mcr_search;"
    },
    ```

4. Guarde los cambios en el archivo appsettings.json.

## Datos Prefabricados

Se incluyen datos prefabricados para facilitar la ejecución y pruebas de la aplicación:

- **20 Vehículos Disponibles en Total**
  - **Colombia**:
    - 2 Vehículos disponibles en Bogotá - Tunja.
    - 1 Vehículo disponible en Tunja - Bogotá.
    - 3 Vehículos disponibles en Tunja - Tunja.
    - 5 Vehículos disponibles en Bogotá - Bogotá.
  - **Brasil**:
    - 1 Vehículo disponible en Goiânia - Goiânia.
    - 4 Vehículos disponibles en Goiânia - Brasilia.
    - 4 Vehículos disponibles en Brasilia - Brasilia.
- **1 Usuario Disponible**
  - Nombre de usuario: admin
  - Contraseña: Admin123*

## Habilitación de CORS en la API

La API ha configurado el Cross-Origin Resource Sharing (CORS) para permitir solicitudes desde "localhost:8080".

## Contacto

Para cualquier consulta o problema, puedes contactar al desarrollador principal [Juan Serrano](https://github.com/juansdev).