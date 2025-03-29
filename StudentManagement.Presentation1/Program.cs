using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using StudentManagement.DataAccess.DbContexts;
using StudentManagement.DataAccess.Repositories;
using StudentManagement.BusinessLogic.Services;
using StudentManagement.BusinessLogic.Interfaces;

namespace StudentManagement.Presentation
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 🔹 Setup Dependency Injection (DI) Container
            var serviceProvider = ConfigureServices();

            // 🔹 Resolve FacultyService from DI
            var facultyService = serviceProvider.GetRequiredService<IFacultyService>();

            // 🔹 Start Form1 and Inject Service
            Application.Run(new Form1(facultyService));
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // 🔹 Register DbContext with Scoped Lifetime
            services.AddDbContext<StudentDbContext>();

            // 🔹 Register Repositories
            services.AddScoped<IFacultyRepository, FacultyRepository>();

            // 🔹 Register Services
            services.AddScoped<IFacultyService, FacultyService>();

            return services.BuildServiceProvider();
        }
    }
}
