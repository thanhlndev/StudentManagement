# StudentManagement

#Nhập lệnh tại Tools/Nuget Package Manager/Nuget Package Console

Install-Package EntityFramework -Version 6.4.4 -ProjectName StudentManagement.DataAccess
Install-Package EntityFramework -Version 6.4.4 -ProjectName StudentManagement.BusinessLogic
Install-Package EntityFramework -Version 6.4.4 -ProjectName StudentManagement.Presentation

Install-Package Microsoft.Extensions.DependencyInjection -Version 6.0.0 -ProjectName StudentManagement.Presentation
Install-Package Microsoft.Extensions.DependencyInjection -Version 6.0.0 -ProjectName StudentManagement.BusinessLogic
Install-Package Microsoft.Extensions.DependencyInjection -Version 6.0.0 -ProjectName StudentManagement.DataAccess

NuGet\Install-Package Microsoft.EntityFrameworkCore -Version 3.1.32 -ProjectName StudentManagement.DataAccess


Enable-Migrations -ProjectName StudentManagement.DataAccess
Add-Migration InitialCreate
Update-Database
