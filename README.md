# CycleAPI


![hexagonalArchitecture](https://github.com/Jayz1x/CycleAPI/assets/100038518/91a7668f-9874-4dcb-bcff-cbd6fa4645a6)


Descripción del Proyecto: CRUD de Productos Prueba Tecnica Cycle


El proyecto de CRUD de productos es una aplicación desarrollada en .NET utilizando Entity Framework Core para la capa de persistencia, Master Key para la validación de datos, Swagger para la documentación de la API y SQL Server como base de datos. Además, se ha implementado la arquitectura hexagonal para organizar y separar las responsabilidades del sistema de manera clara y mantenible.

Características Principales
CRUD de Productos: Permite crear, leer, actualizar y eliminar productos desde una interfaz de usuario intuitiva.
Validación con Master Key: Utiliza Master Key para validar los datos ingresados por el usuario y garantizar su integridad.
Documentación con Swagger: La API está documentada con Swagger, lo que facilita la comprensión y el uso de los endpoints disponibles.
Base de Datos SQL Server: Almacena la información de los productos y sus detalles en una base de datos SQL Server para un acceso eficiente y seguro.
Tecnologías Utilizadas
ASP.NET Core: Para el desarrollo del backend de la aplicación.
Entity Framework Core: Para el mapeo objeto-relacional y la gestión de la base de datos SQL Server.
Master Key: Biblioteca de validación de datos para garantizar la consistencia y corrección de la información ingresada.
Swagger: Herramienta de documentación de API para facilitar la comprensión y el uso de los servicios expuestos.
SQL Server: Como base de datos principal para almacenar y gestionar la información de los productos.
Arquitectura Hexagonal
La aplicación sigue el patrón de arquitectura hexagonal (también conocido como puertos y adaptadores) para separar claramente las responsabilidades y capas del sistema:

Dominio: Contiene las reglas de negocio y la lógica principal de la aplicación, independiente de las tecnologías externas.
Aplicación: Implementa la lógica de aplicación utilizando los servicios del dominio y adaptándolos a los puertos de entrada y salida.
Adaptadores: Se encargan de la integración con tecnologías externas como la base de datos, la interfaz de usuario y servicios externos.
Rutas Protegidas
La aplicación cuenta con algunas rutas protegidas que requieren autorización para su acceso. Las rutas protegidas son todas las operaciones CRUD excepto las siguientes:

GET /api/productos: Obtener todos los productos.
GET /api/productos/{id}: Obtener un producto por su ID.
Para acceder a las rutas protegidas, debes seguir estos pasos en Swagger:

Haz clic en el botón "Authorize".
Ingresa cualquiera de las siguientes keys de autorización:
"validkey1"
"validkey2"
"validkey3"
"validkey4"
Una vez autorizado, podrás utilizar las rutas protegidas según los permisos asignados a la key de autorización utilizada.
