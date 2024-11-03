# User Registration API

## Descripción

Esta API RESTful permite crear usuarios en una base de datos SQL Server. Incluye validación de correo y contraseña mediante expresiones regulares configurables y la posibilidad de registrar múltiples teléfonos para cada usuario.

## Estructura del Proyecto

- **Backend**: .NET 6+.
- **Base de Datos**: SQL Server (aunque el script puede adaptarse para MySQL o PostgreSQL).
- **Formato de Respuesta y Solicitud**: JSON.

## Características

- Registro de usuarios con los campos `nombre`, `correo`, `contraseña` y un listado de `teléfonos`.
- Generación de un `UUID` único para el `id` de usuario y un token de autenticación (UUID o JWT).
- Respuesta de datos adicionales como fecha de creación, última modificación, último inicio de sesión y estado de activación.
- Validación del formato del correo y contraseña usando expresiones regulares.
- Persistencia del token junto con los datos del usuario.
- Mensaje de error en caso de que el correo ya esté registrado en la base de datos.

## Formato de Solicitud

Ejemplo de JSON para registro de usuario:

```json
{
  "name": "Juan Rodriguez",
  "email": "juan@rodriguez.org",
  "password": "Juanr123",
  "phones": [
    {
      "number": "1234567",
      "citycode": "1",
      "contrycode": "57"
    }
  ]
}
