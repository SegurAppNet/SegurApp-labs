# Laboratorios de Seguridad en ASP.NET Core

¡Bienvenido al repositorio de laboratorios de SegurApp! Este proyecto es una colección de aplicaciones de ASP.NET Core diseñadas para enseñar y practicar conceptos fundamentales de seguridad web de forma aislada.

## Propósito

El objetivo de este repositorio es servir como material práctico complementario. Cada carpeta representa un mecanismo de seguridad y contiene uno o más proyectos de laboratorio enfocados en prácticas de seguridad específicas.

## Estructura del proyecto

El repositorio está organizado en carpetas, donde cada carpeta corresponde a un mecanismo de seguridad fundamental:

- **/AntiforgeryTokens** (Laboratorios de Tokens Antifalsificación)
- **/Authentication** (Laboratorios de Autenticación, ej. JWT, 2FA)
- **/Authorization** (Laboratorios de Autorización, ej. RBAC, Policies)
- **/Cors** (Laboratorios de Configuración de CORS)
- **/DataProtection** (Laboratorios de Cifrado con Data Protection API)
- **/EnforceHTTPS** (Laboratorios de HSTS y Encabezados Seguros)
- **/HTMLEncoder** (Laboratorios de Prevención de XSS, ej. CSP)
- **/SecretsManagement** (Laboratorios de Secret Manager y Key Vault)

## Requisitos Previos

Para ejecutar estos laboratorios, necesitarás tener instalado el siguiente software:

- **SDK de .NET 8**
- **Visual Studio 2022** o **Visual Studio Code**
- **SQL Server** para los laboratorios que utilizan ASP.NET Core Identity.
- **Postman** o un cliente API similar para probar los laboratorios de Web API.

## ¿Cómo Empezar?

1. **Clonar el Repositorio**: Descarga el proyecto completo a tu máquina local.

```javascript
git clone https://github.com/SegurAppNet/SegurApp-labs.git
```

2. **Abrir la Solución**: Abre el archivo de solución (.sln) principal del repositorio.

3. **Elige un Laboratorio**: En el Explorador de Soluciones, busca el proyecto correspondiente a la práctica que deseas realizar (ej. JwtApi, AntiforgeryMvc)

4. **Consulta la Guía**: Abre la Guía de Seguridad en la página web y localiza la sección correspondiente a esa práctica.

5. **Lee el README Específico**: Algunos laboratorios (especialmente los que usan ASP.NET Core Identity) contienen un archivo README.md en su interior con instrucciones de configuración inicial, como la creación de la base de datos.

6. **Completa el Código**: Abre los archivos del proyecto. Encontrarás comentarios en las áreas que debes completar.

7. **Sigue las Instrucciones**: Tu tarea es rellenar esos bloques de código siguiendo los pasos de implementación descritos en la guía web.

8. **Prueba y Verifica**: Ejecuta el proyecto y utiliza las herramientas (navegador, Postman) y la rúbrica de la guía para verificar que tu implementación es correcta

9. **Analiza y Aprende**: No solo copies y pegues el código. Analiza por qué estás añadiendo esa línea, qué vulnerabilidad previene y cómo funciona. ¡El objetivo es entender!
