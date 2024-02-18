# API de Búsqueda de Vehículos - Endpoints

## Controlador "AppUser"

- **GET -> /api/users**: Obtiene todos los usuarios. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/users/{id}**: Obtiene un usuario específico por ID. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **POST -> /api/users/register**: Registra un usuario.
- **POST -> /api/users/login**: Autentica un usuario.

## Controlador "AvailableVehicle"

- **GET -> /api/availableVehicle/{localizedCustomerCountryName}/{pickUpCityName}/{returnCityName}**: Verifica la disponibilidad de un vehículo por el nombre del país de la ubicación del usuario, por el nombre de la ciudad de recogida y por el nombre de la ciudad de retorno.
- **GET -> /api/availableVehicle/{localizedCustomerCountryName}/{pickUpCityName}/{returnCityName}**: Verifica la disponibilidad de un vehículo por el país de la ubicación del usuario, la ciudad de recogida y la ciudad de retorno por sus IDs.
- **GET -> /api/availableVehicle/{id}**: Obtiene la disponibilidad de un vehículo por ID.
- **DELETE -> /api/availableVehicle/{id}**: Elimina la disponibilidad de un vehículo por ID. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/availableVehicle/vehicle/{vehicleId}**: Obtiene un vehículo entre los vehículos disponibles por ID.
- **GET -> /api/availableVehicle/city/{cityId}**: Obtiene los vehículos disponibles en una ciudad por ID.
- **POST -> /api/availableVehicle**: Agrega un vehículo a la disponibilidad. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **PATCH -> /api/availableVehicle**: Actualiza un vehículo de la disponibilidad. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).

## Controlador "City"

- **GET -> /api/city**: Obtiene todas las ciudades.
- **POST -> /api/city**: Agrega una ciudad. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **PATCH -> /api/city**: Actualiza una ciudad. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/city/{id}**: Obtiene una ciudad por ID.
- **DELETE -> /api/city/{id}**: Elimina una ciudad por ID. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/city/{name}**: Obtiene una ciudad por su nombre.

## Controlador "Country"

- **GET -> /api/country**: Obtiene todos los países.
- **POST -> /api/country**: Agrega un país. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **PATCH -> /api/country**: Actualiza un país. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/country/{id}**: Obtiene un país por ID.
- **DELETE -> /api/country/{id}**: Elimina un país por ID. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/country/{name}**: Obtiene un país por su nombre.

## Controlador "Department"

- **GET -> /api/department**: Obtiene todos los departamentos.
- **POST -> /api/department**: Agrega un departamento. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **PATCH -> /api/department**: Actualiza un departamento. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/department/{id}**: Obtiene un departamento por ID.
- **DELETE -> /api/department/{id}**: Elimina un departamento por ID. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/department/{name}**: Obtiene un departamento por su nombre.

## Controlador "Vehicle"

- **GET -> /api/vehicles**: Obtiene todos los vehículos.
- **POST -> /api/vehicles**: Agrega un vehículo. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **PATCH -> /api/vehicle**: Actualiza un vehículo. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/vehicle/{id}**: Obtiene un vehículo por ID.
- **DELETE -> /api/vehicle/{id}**: Elimina un vehículo por ID. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/vehicle/{modelName}/{typeName}/{brandName}**: Obtiene un vehículo por el nombre del modelo, nombre del tipo y el nombre de la

 marca. 
- **GET -> /api/vehicle/{modelId}/{typeId}/{brandId}**: Obtiene un vehículo por el modelo, tipo y marca por sus IDs.
- **GET -> /api/vehicle/model/{modelId}**: Obtiene todos los vehículos por el modelo según ID.
- **GET -> /api/vehicle/type/{typeId}**: Obtiene todos los vehículos por el tipo según ID.
- **GET -> /api/vehicle/brand/{brandId}**: Obtiene todos los vehículos por la marca según ID.

## Controlador "VehicleBrand"

- **GET -> /api/vehiclebrand**: Obtiene todas las marcas de los vehículos.
- **POST -> /api/vehiclebrand**: Agrega una marca de vehículo. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **PATCH -> /api/vehiclebrand**: Actualiza una marca de vehículo. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/vehiclebrand/{id}**: Obtiene una marca de vehículo por ID.
- **DELETE -> /api/vehiclebrand/{id}**: Elimina una marca de vehículo por ID. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/vehiclebrand/{name}**: Obtiene una marca de vehículo por su nombre.

## Controlador "VehicleModel"

- **GET -> /api/vehiclemodel**: Obtiene todos los modelos de los vehículos.
- **POST -> /api/vehiclemodel**: Agrega un modelo de vehículo. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **PATCH -> /api/vehiclemodel**: Actualiza un modelo de vehículo. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/vehiclemodel/{id}**: Obtiene un modelo de vehículo por ID.
- **DELETE -> /api/vehiclemodel/{id}**: Elimina un modelo de vehículo por ID. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/vehiclemodel/{name}**: Obtiene un modelo de vehículo por su nombre.

## Controlador "VehicleType"

- **GET -> /api/vehicletype**: Obtiene todos los tipos de los vehículos.
- **POST -> /api/vehicletype**: Agrega un tipo de vehículo. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **PATCH -> /api/vehicletype**: Actualiza un tipo de vehículo. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/vehicletype/{id}**: Obtiene un tipo de vehículo por ID.
- **DELETE -> /api/vehicletype/{id}**: Elimina un tipo de vehículo por ID. (EndPoint protegido, solo usuarios con el rol "admin" pueden acceder).
- **GET -> /api/vehicletype/{name}**: Obtiene un tipo de vehículo por su nombre.