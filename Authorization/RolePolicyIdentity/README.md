# Laboratorio de Seguridad en ASP.NET Core

## Acerca de este Laboratorio

Este proyecto está diseñado para que implementes una práctica de seguridad en una aplicación ASP.NET Core MVC que ya utiliza ASP.NET Core Identity.

Antes de comenzar a implementar la lógica de la práctica, es fundamental que configures la base de

### 1. Configuración de la Base de Datos (Requisito Previo)
Este proyecto utiliza Entity Framework Core para gestionar la base de datos de usuarios:

#### Paso 1: Crear la Migración
Este comando leerá los modelos de Identity (como IdentityUser) y preparará los archivos de migración para crear las tablas:

```javascript
dotnet ef migrations add InitialCreate
```

#### Paso 2: Aplicar la Migración
Este comando ejecutará la migración y creará físicamente la base de datos y sus tablas en tu SQL Server.

```javascript
dotnet ef database update
```

### 2. Solución de Problemas
Es posible que encuentres errores al ejecutar los comandos anteriores. Aquí están las soluciones más comunes.

**Error**: "El término 'dotnet ef' no se reconoce..."

Si ves este error, significa que la herramienta de Entity Framework Core no está instalada en tu máquina.

**Solución**: Instala la herramienta globalmente ejecutando el siguiente comando:

```javascript
dotnet tool install --global dotnet-ef
```

Una vez instalado, vuelve a intentar el **Paso 1**.

**Error**: "Error al conectar con la base de datos..." o similar

Si el **Paso 2 (dotnet ef database update)** falla con un error de conexión, es muy probable que tu servidor de SQL Server no se llame localhost.

**Solución:**

1. Abre el archivo **appsettings.json**.
2. Busca la sección **ConnectionStrings**:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=IdentityProject;Trusted_Connection=true;TrustServerCertificate=true;"
     }
   }
   ```

3. Modifica el valor de **Server=localhost** para que coincida con el nombre de tu instancia local de SQL Server.  
   Nombres comunes son:

   - **Server=.\\SQLEXPRESS** (para SQL Server Express)
   - **Server=(localdb)\\mssqllocaldb** (para LocalDB)
   - **Server=NOMBRE_DE_TU_PC**

4. Guarda el archivo y vuelve a ejecutar **dotnet ef database update**.

### 3. Pasos del Laboratorio

Una vez que la base de datos esté configurada, sigue las instrucciones de la guía de seguridad en la página web para implementar la práctica correspondiente.
