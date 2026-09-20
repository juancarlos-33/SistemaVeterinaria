# Sistema de Gestión Veterinaria (Prueba Técnica)

Proyecto desarrollado en ASP.NET Core MVC con Entity Framework Core y SQL Server, cumpliendo con todos los requerimientos de la prueba técnica para Backend Developer.

## Requisitos previos
- .NET SDK instalado.
- SQL Server (puedes usar el LocalDB que viene por defecto con Visual Studio o SQL Express).

## Configuración de Base de Datos

Tienes dos opciones para levantar la base de datos (elige la que prefieras):

**Opción 1: Migraciones de EF Core (Recomendado)**
El proyecto ya tiene las migraciones listas. Solo abre tu terminal en la carpeta del proyecto y ejecuta:
```bash
dotnet ef database update
```
*(Ojo: revisa que la cadena de conexión en `appsettings.json` apunte a tu servidor de base de datos local).*

**Opción 2: Script SQL manual**
Si prefieres crear todo a mano, dejé un archivo llamado `VeterinariaDB_Script.sql` en la raíz del proyecto. Solo córrelo en tu SQL Server Management Studio y te creará la base de datos con las tablas y algunos datos iniciales (especies y razas) para probar.

## Cómo correr el proyecto

Desde Visual Studio solo dale al botón de Play (F5). Si usas la terminal o VS Code, corre:
```bash
dotnet run
```

## Notas técnicas de la implementación
- **Arquitectura:** Inyecté el `DbContext` directo en los controladores tal como pedía la prueba (cero repositorios).
- **Frontend:** Vistas de Razor usando clases estándar de Bootstrap 5.
- **Formulario Mascotas:** Usé Javascript puro (Fetch API) para el filtrado en cascada de Especie a Raza, para no meter librerías pesadas. Las fotos de las mascotas se guardan directo en `wwwroot/images/`.
