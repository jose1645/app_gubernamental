# ![Logo de Reporta Baches](Resources/AppIcon/iconosombrero.png)

# Reporta Baches

Reporta Baches es una aplicación móvil diseñada para reportar baches en la comunidad de manera sencilla y eficiente. Los usuarios pueden registrar baches con información relevante como ubicación, descripción y fotos, mientras que las autoridades pueden visualizar estos reportes en un mapa interactivo.

## Características

1. **Reportar un Bache**:
   - Captura la ubicación geográfica mediante GPS.
   - Incluye una descripción detallada del bache y una foto.
   - Envía la información al servidor para su gestión.

2. **Mapa Interactivo**:
   - Visualiza los reportes de baches existentes en un mapa.
   - Los marcadores incluyen información sobre el estado del bache.

3. **Gestión de Estados**:
   - Actualiza el estado de un bache como "Resuelto" una vez atendido.

4. **Sincronización en Tiempo Real**:
   - La información de los reportes se almacena en un servidor y se sincroniza dinámicamente.

## Estructura del Proyecto

ReportaBaches/
│   .gitattributes
│   .gitignore
│   App.xaml                # Configuración general de la app
│   AppShell.xaml           # Definición de la estructura de navegación
│   MainPage.xaml           # Página principal de la aplicación
│   MauiProgram.cs          # Configuración inicial y servicios
│   README.md               # Documentación del proyecto
│   sombrero.sln            # Solución principal
│
├───Botonosersonalizados    # Contiene botones personalizados para la interfaz
├───Controls                # Componentes personalizados para el diseño del menú
├───GoogleServices          # Servicios para autenticación y gestión de usuarios
├───ImportGoogleCalendar    # Implementación para importar eventos desde Google Calendar
├───models                  # Modelos de datos utilizados en la aplicación
├───objetos                 # Clases específicas como representación de baches
├───paginas                 # Páginas principales de la aplicación
├───Platforms               # Archivos específicos de cada plataforma (Android, iOS, etc.)
├───Properties              # Configuraciones del proyecto
├───Resources               # Recursos como imágenes, estilos y fuentes
├───services                # Servicios de backend como la gestión de reportes de baches
├───viewmodels              # Lógica para conectar vistas y datos
└───views                   # Interfaces de usuario adicionales

## Tecnologías Utilizadas

- **Frontend**:
  - .NET MAUI para desarrollo multiplataforma (Android/iOS).
  - Microsoft.Maui.Controls.Maps para visualización interactiva.
  - Google Maps API para geolocalización.

- **Backend**:
  - Lambda AWS.
  - DynamoDB para el almacenamiento de reportes.

- **Infraestructura**:
  - AWS Lambda para el procesamiento de datos.
  - AWS API Gateway para la gestión de solicitudes HTTP.
  - AWS EC2 para el despliegue del backend.

## Requisitos del Sistema

### Cliente
- Android 8.0 o superior
- iOS 13 o superior
- Conexión a Internet
- GPS habilitado

### Backend
- AWS CLI configurado
- DynamoDB y S3 habilitados en tu cuenta de AWS

## Instalación

### 1. Clonar el Repositorio
git clone https://github.com/tu-usuario/reportabaches.git
cd reportabaches

### 2. Configurar el Backend
1. Configura las credenciales de AWS en un archivo .env:
   AWS_ACCESS_KEY_ID=your-access-key-id
   AWS_SECRET_ACCESS_KEY=your-secret-access-key
   AWS_REGION=us-east-1
   Tambien vas a requirir agregar las llaves de las Apis Solicitadas en el codigo

### 3. Configurar el Frontend
1. Configura la API Key de Google Maps en el archivo AndroidManifest.xml:
   <meta-data android:name="com.google.android.geo.API_KEY" android:value="YOUR_GOOGLE_MAPS_API_KEY" />

2. Compila y ejecuta la aplicación:
   cd frontend
   dotnet build
   dotnet run

## Uso de la Aplicación
1. **Autenticate con google**
2. **Reportar un Bache**:
   - Presiona el botón "Reportar".
   - Envía el reporte.

3. **Visualizar Reportes**:
   - Abre el mapa para ver los baches reportados en tu área.

4. **Actualizar el Estado**:
   - Haz clic en un marcador para actualizar el estado del reporte.



5. La data se almacena en dynamo DB de la siguiente manera
  | ID                                    | Existe | Fecha                | Latitud     | Longitud     | Fabricante | Modelo       | Nombre             | SO   | Tipo | Versión |
|---------------------------------------|--------|----------------------|-------------|--------------|------------|--------------|--------------------|------|------|---------|
| fc0dba28-a209-42d8-be08-d75c0ffb809d | 1      | 2024,12,10 11:56:42 | 19.4386353  | -102.009564  | Xiaomi     | M2103K19PG   | POCO M3 Pro 5G    | {}   | 1    | 13.0    |
| 9059b1cd-314b-4fc2-8a05-5f8f6ac098f2 | 0      | 2024,09,04 18:27:49 | 19.4283909  | -102.0485393 | HUAWEI     | STK-LX3      | STK-LX3           | {}   | 1    | 10.0    |
| 9d0032a7-3207-4bd8-b6c1-468bc46a3e24 | 0      | 2024,09,04 18:27:21 | 19.4283909  | -102.0485393 | HUAWEI     | STK-LX3      | STK-LX3           | {}   | 1    | 10.0    |
| d5ce0f41-374a-4d42-b3d3-fe1865a0d1f9 | 1      | 2024,09,03 10:54:49 | 19.4386142  | -102.0095164 | Xiaomi     | M2103K19PG   | POCO M3 Pro 5G    | {}   | 1    | 13.0    |
| 0863010e-fe10-4494-994a-f5065b4b0262 | 0      | 2024,09,02 12:52:28 | 19.4385878  | -102.0095416 | Xiaomi     | M2103K19PG   | POCO M3 Pro 5G    | {}   | 1    | 13.0



## Contribuciones

1. Crea un fork del repositorio.
2. Crea una rama nueva:
   git checkout -b mi-nueva-funcionalidad
3. Haz tus cambios y realiza un commit:
   git commit -m "Agrega nueva funcionalidad"
4. Envía tus cambios:
   git push origin mi-nueva-funcionalidad
5. Abre un Pull Request.

## Contacto

Si tienes dudas o sugerencias, por favor contáctanos en:
- Email: contacto@lasombreriza.com
- GitHub: https://github.com/tu-usuario

¡Gracias por usar Reporta Baches! 🚧
