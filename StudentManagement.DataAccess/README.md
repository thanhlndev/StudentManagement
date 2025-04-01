Install-Package EntityFramework

Install-Package Microsoft.Extensions.DependencyInjection


Enable-Migrations -ProjectName StudentManagement.DataAccess
Add-Migration InitialCreate
Update-Database
