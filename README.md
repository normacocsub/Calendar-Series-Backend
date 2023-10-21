# Calendar-Series-Backend

# Install BD With Docker

# 1 Download Image from docker hub

``` docker pull mcr.microsoft.com/mssql/server ```

``` docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest ```


# Connection in .Net 

``` "DefaultConnection": "Data Source=sql-server,1433;Initial Catalog=CalendarSeries;User Id=sa;Password=Prueba123*;TrustServerCertificate=true" ```


# Create Migration Databasek

Ir a Infrastructure en la terminal y ejecutar el siguiente comando en caso de no existir la migración

``` dotnet ef migrations add PrimeraMigracion --startup-project ../Presentation/Presentation.csproj --context CalendarSerieContext ```

Ahora es importante ejecutar el siguiente comando para que se ejecute el script creado en la migración.

``` dotnet ef database update --context CalendarSerieContext --startup-project ../Presentation/Presentation.csproj ```

# Excluir archivos autogenerados de git

``` git rm -r --cached Infrastructure/obj/ ```

