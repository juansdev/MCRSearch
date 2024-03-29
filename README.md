# Sistema de B�squeda de Veh�culos para Miles Car Rental

## Introducci�n

Este proyecto implementa un Sistema de B�squeda de Veh�culos para Miles Car Rental, una empresa l�der en la industria de alquiler de veh�culos. El sistema proporciona una interfaz avanzada que permite a los clientes encontrar veh�culos disponibles de manera eficiente y precisa, bas�ndose en criterios espec�ficos de b�squeda.

## Requerimientos T�cnicos

- **Versi�n de .NET**: .NET 7
- **Versi�n de Visual Studio**: VS 2022 v17.8.2
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

## Caracter�sticas Principales

- **Autenticaci�n y Autorizaci�n**: Sistema de autenticaci�n y autorizaci�n de usuarios mediante JWT Token.
- **Persistencia de Datos**: Utilizaci�n de MySQL como base de datos para la persistencia de datos.
- **Arquitectura Hexagonal**: Implementaci�n de la arquitectura hexagonal para una estructura modular y mantenible.
- **Principios SOLID**: Aplicaci�n de los principios SOLID para un dise�o de c�digo eficiente y escalable.
- **Automapper**: Utilizaci�n de Automapper para el mapeo de objetos entre capas.
- **DTOs**: Empleo de Objetos de Transferencia de Datos para una separaci�n clara entre capas.
- **Servicios y Repositorios**: Uso de servicios y repositorios para una organizaci�n l�gica y eficiente del c�digo.
- **Logging**: Registro de errores y respuestas de las peticiones para un seguimiento detallado.
- **Swagger**: Integraci�n de Swagger para documentar y probar la API de manera interactiva.
- **Pruebas Unitarias e Integraci�n**: Implementaci�n de pruebas unitarias e integraci�n para garantizar la calidad del c�digo.
- **CORS**: Configuraci�n de CORS para permitir solicitudes desde "localhost:8080".
- **Datos Prefabricados**: Inclusi�n de datos prefabricados para facilitar la ejecuci�n y pruebas de la aplicaci�n.

## Estructura del Proyecto

- **MCRSearch (Soluci�n)**
  - **MCRSearch (Proyecto)**
    - **Logs**: Carpeta donde se guardan los archivos de registro.
    - **Migrations**: Carpeta donde se guardan las migraciones de Entity Framework Core.
    - **src**
      - **MCRSearch.Application**: Capa de aplicaci�n
        - **Dtos**: Almacena los Data Transfer Objects utilizados en la capa de aplicaci�n.
        - **Mapper**: L�gica del AutoMapper.
        - **Services**: Servicios de la aplicaci�n.
      - **MCRSearch.Core**: Capa de l�gica de negocio
        - **Entities**: Entidades de la aplicaci�n.
      - **MCRSearch.Infrastructure**: Capa de infraestructura
        - **Filters**: Filtros de acci�n utilizados en la API.
        - **Middleware**: Middlewares utilizados para interceptar las peticiones y respuestas.
        - **Repositories**: Repositorios siguiendo el patr�n de dise�o repository.
        - **ApplicationDbContext.cs**: Configuraci�n del IdentityDbContext y seeders.
      - **MCRSearch.Presentation**: Capa de presentaci�n (API)
        - **Controllers**: Controladores de la API.
    - **SharedDtos**: Almacena los Data Transfer Objects compartidos entre diversas capas.
    - **Program.cs**: Configuraci�n y arranque del proyecto.
    - **Startup.cs**: Configuraci�n de servicios y configuraci�n general.
  - **MCRSearch.Tests (Proyecto)**
    - **Commons**: Clases comunes utilizadas en diveros tipos de pruebas.
    - **IntegrationTests**: Pruebas de integraci�n.
    - **UnitTests**: Pruebas unitarias.
    - **Helpers**: Clases de ayuda para las pruebas.

## Instrucciones de Ejecuci�n

1. Clona el repositorio desde [GitHub](https://github.com/juansdev/MCRSearch.git).
2. Abre el proyecto en Visual Studio o tu IDE preferido ejecutando el archivo ubicado en "MCRSearch/MCRSearch/MCRSearch.sln".
3. Actualiza la URL de conexi�n en el appsettings.json, del cual se explica en la siguiente secci�n.
4. Actualiza la base de datos ejecutando los siguientes comandos en la Consola de Administrador de Paquetes (Package Manager Console):
   ```shell
   Update-Database
   Add-Migration InitialMigration
   Update-Database
   ```
5. Ejecuta la aplicaci�n.

## Actualizaci�n de URL de Conexi�n en appsettings.json

Para actualizar la URL de conexi�n en la llave "ConnectionSql" en el archivo appsettings.json, siga los pasos a continuaci�n:

1. En el Explorador de Soluciones, expande el proyecto `MCRSearch`, accede al archivo appsettings.json.
2. Ubique la secci�n "ConnectionStrings" y encuentre la llave "ConnectionSql". La cadena de conexi�n tiene el siguiente formato:

    ```json
    "ConnectionStrings": {
      "ConnectionSql": "server=localhost;port=3306;user=root;password=thor;database=mcr_search;"
    },
    ```
3. Modifique la URL de conexi�n seg�n sus necesidades. Aseg�rese de proporcionar la informaci�n correcta para el servidor, puerto, nombre de usuario, contrase�a y base de datos.
   Por ejemplo, si desea cambiar el servidor a "nuevoservidor" y el puerto a "1234", la cadena de conexi�n se ver�a as�:
    ```json
    "ConnectionStrings": {
      "ConnectionSql": "server=nuevoservidor;port=1234;user=root;password=thor;database=mcr_search;"
    },
    ```
4. Guarde los cambios en el archivo appsettings.json.

## Instrucci�n de Ejecuci�n de Pruebas Unitarias y de Integraci�n

Para ejecutar las pruebas unitarias e integraci�n en el proyecto, sigue los siguientes pasos:

1. Abre el proyecto en Visual Studio o tu IDE preferido ejecutando el archivo ubicado en "MCRSearch/MCRSearch/MCRSearch.sln".
2. En el Explorador de Soluciones, expande el proyecto `MCRSearch.Tests`.
3. Ver�s dos carpetas principales: `UnitTests` y `IntegrationTests`. Cada una contiene las pruebas unitarias e integraci�n respectivamente.
4. Para ejecutar todas las pruebas, ve a la barra de men� y selecciona `Prueba > Ejecutar todas las pruebas`. Esto ejecutar� todas las pruebas unitarias e integraci�n en el proyecto.
5. Para ejecutar pruebas espec�ficas, puedes hacer clic derecho en una prueba o un conjunto de pruebas y seleccionar `Ejecutar Pruebas`.
6. Despu�s de ejecutar las pruebas, los resultados se mostrar�n en la ventana de `Resultados de Pruebas`.

## Datos Prefabricados

Se incluyen datos prefabricados para facilitar la ejecuci�n y pruebas de la aplicaci�n:

- **20 Veh�culos Disponibles en Total**
  - **Colombia**:
    - 2 Veh�culos disponibles en Bogot� D.C. (Ciudad de Recogida) - Tunja (Ciudad de Retorno).
    - 1 Veh�culo disponible en Tunja - Bogot� D.C..
    - 3 Veh�culos disponibles en Tunja - Tunja.
    - 5 Veh�culos disponibles en Bogot� D.C. - Bogot� D.C..
  - **Brasil**:
    - 1 Veh�culo disponible en Goi�nia - Goi�nia.
    - 4 Veh�culos disponibles en Goi�nia - Brasilia.
    - 4 Veh�culos disponibles en Brasilia - Brasilia.
- **2 Departamentos Disponibles en Total**
  - **Colombia**:
	- Cundinamarca.
  - **Brasil**:
	- Goi�s
- **20 Marcas de Vehiculos en Total**
- **20 Modelos de Vehiculos en Total**
- **4 Tipos de Vehiculos en Total**
- **20 Vehiculos en Total**
- **1 Usuario Disponible**
  - Nombre de usuario: admin
  - Contrase�a: Admin123*
  - Rol: admin

## Habilitaci�n de CORS en la API

La API ha configurado el Cross-Origin Resource Sharing (CORS) para permitir solicitudes desde "localhost:8080".

## Contacto

Para cualquier consulta o problema, puedes contactar al desarrollador principal [Juan Serrano](https://github.com/juansdev).