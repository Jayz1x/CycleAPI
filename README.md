#Features

#CycleAPI

####Descripción del Proyecto: CRUD de Productos Prueba Tecnica Cycle

El proyecto de CRUD de productos es una aplicación desarrollada en .NET utilizando Entity Framework Core para la capa de persistencia, Master Key para la validación de datos, Swagger para la documentación de la API y SQL Server como base de datos. Además, se ha implementado la arquitectura hexagonal para organizar y separar las responsabilidades del sistema de manera clara y mantenible.


------------


#### Características Principales CRUD de Productos: 

- Permite crear, leer, actualizar y eliminar productos desde una interfaz de usuario intuitiva.

- **Validación con Master Key: **Utiliza Master Key para validar los datos ingresados por el usuario y garantizar su integridad. 

- **Documentación con Swagger:** La API está documentada con Swagger, lo que facilita la comprensión y el uso de los endpoints disponibles. 

- **Base de Datos SQL Server:** Almacena la información de los productos y sus detalles en una base de datos SQL Server para un acceso eficiente y seguro. 

------------


## Tecnologías Utilizadas 

- **ASP.NET Core:** Para el desarrollo del backend de la aplicación. 
- Entity Framework Core: Para el mapeo objeto-relacional y la gestión de la base de datos SQL Server. 
- **Master Key:** Biblioteca de validación de datos para garantizar la consistencia y corrección de la información ingresada.
- **Swagger:** Herramienta de documentación de API para facilitar la comprensión y el uso de los servicios expuestos. 
- **SQL Server**: Como base de datos principal para almacenar y gestionar la información de los productos. 
- **Arquitectura Hexagonal** La aplicación sigue el patrón de arquitectura hexagonal (también conocido como puertos y adaptadores) para separar claramente las responsabilidades y capas del sistema:

- **Dominio: **Contiene las reglas de negocio y la lógica principal de la aplicación, independiente de las tecnologías externas. 

- **Aplicación**: Implementa la lógica de aplicación utilizando los servicios del dominio y adaptándolos a los puertos de entrada y salida. 

- **Infraestructura:** Se encargan de la integración con tecnologías externas como la base de datos, la interfaz de usuario y servicios externos.

------------


### Rutas Protegidas

La aplicación cuenta con algunas rutas protegidas que requieren autorización para su acceso. Las rutas protegidas son todas las operaciones CRUD excepto las siguientes:

- GET /api/productos: Obtener todos los productos. 

- GET /api/productos/{id}: Obtener un producto por su ID. 

Para acceder a las rutas protegidas, debes seguir estos pasos en Swagger:

1. Haz clic en el botón "Authorize".
2. Ingresa cualquiera de las siguientes keys de autorización: 
> "validkey1" "validkey2" "validkey3" "validkey4"

3. Una vez autorizado, podrás utilizar las rutas protegidas según los permisos asignados a la key de autorización utilizada.

**Nota: **Al utilizar la ruta POST para enviar imágenes, asegúrate de que la imagen esté en formato de ruta de acceso y que cualquier barra diagonal invertida(\) se sustituya por dos barras diagonales invertidas (\\). Por ejemplo:

Si la ruta de acceso a la imagen es `"C:\Users\Usuario\Imágenes\imagen.jpg"`, en el cuerpo de la solicitud POST debes utilizar la ruta `"C:\\Users\\Usuario\\Imágenes\\imagen.jpg"` para que sea reconocida correctamente por la API.

**Importante:** En el caso de .NET y el formato JSON, no es posible simplemente poner la barra diagonal invertida (\) en una cadena JSON debido a cómo se interpreta el formato. La barra diagonal invertida (\) se utiliza para caracteres de escape en cadenas JSON y, por lo tanto, debe manejarse de manera especial. Al enviar rutas de acceso de archivos en formato JSON, se deben duplicar las barras diagonales (\\) para asegurar que la cadena sea interpretada correctamente por la API.

 **Recuerda: Para que el servidor pueda arrancar correctamente, asegúrate de establecer CycleAPI como proyecto de inicio en tu entorno de desarrollo.**
 
>  Agradecimientos
 
 > Quiero Expresar Mi Agradecimiento Por Darme La Oportunidad De Realizar Esta Prueba Técnica. Ha Sido Un Desafío Emocionante Trabajar En Este Proyecto Y Estoy Agradecido Por La Oportunidad De Demostrar Mis Habilidades Y Conocimientos. Estoy Ansioso Por Recibir Sus Comentarios Sobre Mi Trabajo.

> ¡Muchas gracias nuevamente y espero tener la oportunidad de contribuir a su equipo!
