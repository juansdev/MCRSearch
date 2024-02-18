# Autenticación en Swagger - Pasos Detallados

A continuación, se describen los pasos detallados para autenticarse en Swagger utilizando los EndPoints proporcionados en la API de MCRSearch. 

## 1. Registrar un Usuario

Para comenzar, registre un usuario utilizando el siguiente EndPoint:

- **POST -> /api/users/register**: Este EndPoint le permitirá registrar un nuevo usuario. Proporcione los detalles necesarios en el cuerpo de la solicitud para crear un nuevo usuario.

Ejemplo de solicitud (puede utilizar este formato en Swagger):
```json
{
  "username": "nombreUsuario",
  "password": "tuContraseña",
  "email": "tuCorreo@dominio.com"
}
```

## 2. Autenticarse con el Usuario Registrado

Después de registrar un usuario, proceda a autenticarse utilizando el siguiente EndPoint:

- **POST -> /api/users/login**: Proporcione las credenciales del usuario recién registrado para obtener el token de autenticación.

Ejemplo de solicitud (puede utilizar este formato en Swagger):
```json
{
  "username": "nombreUsuario",
  "password": "tuContraseña"
}
```

## 3. Copiar el Token del Response

Después de autenticarse, el response contendrá un token. Copie este token para usarlo en la autorización de Swagger.

## 4. Autorizar en Swagger

Diríjase a la interfaz de Swagger y siga estos pasos:

- Encuentre y haga clic en el botón "Authorize" en la esquina superior derecha de Swagger.

- En el cuadro de diálogo que aparece, escriba lo siguiente en el cuadro de "value":
  ```
  Bearer [TOKEN_COPIADO]
  ```
  Asegúrese de reemplazar "[TOKEN_COPIADO]" con el token que copió del response de la autenticación.

- Haga clic en el botón "Authorize" en el cuadro de diálogo para aplicar la autorización.

# Información Adicional sobre Roles de Usuario

## Roles de Usuario

En el sistema de autenticación, los usuarios registrados mediante el EndPoint `/api/users/register` obtendrán automáticamente el rol "user". Sin embargo, si deseas autenticarte con el rol "admin" para acceder a ciertos EndPoints protegidos, utiliza las siguientes credenciales:

- **Nombre de usuario**: admin
- **Contraseña**: Admin123*

Estas credenciales permitirán que te autentiques con el rol de administrador y accedas a los EndPoints protegidos destinados solo para usuarios con este rol.