using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.BusinessLogic.Interfaces;
using StudentManagement.BusinessLogic.Services;
using StudentManagement.DataAccess.DbContexts;
using StudentManagement.DataAccess.Repositories;

namespace StudentManagement.Presentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
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

            // 🔹 Retrieve connection string from app.config
            string connectionString = ConfigurationManager.ConnectionStrings["StudentDbContext"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'StudentDbContext' not found in app.config.");
            }

            // 🔹 Register DbContext for EF6 (manually)
            services.AddScoped<StudentDbContext>(_ => new StudentDbContext());

            // 🔹 Register Repositories
            services.AddScoped<IFacultyRepository, FacultyRepository>();

            // 🔹 Register Services
            services.AddScoped<IFacultyService, FacultyService>();

            return services.BuildServiceProvider();
        }

    }
}
