using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.BusinessLogic.InterfaceServices;
using StudentManagement.BusinessLogic.Services;
using StudentManagement.DataAccess.DbContexts;
using StudentManagement.DataAccess.InterfaceRepositories;
using StudentManagement.DataAccess.InterfaceRepository;
using StudentManagement.DataAccess.Repositories;
using StudentManagement.Presentation.Forms;

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

            // 🔹 Resolve Services from DI
            var facultyService = serviceProvider.GetRequiredService<IFacultyService>();
            var employeeService = serviceProvider.GetRequiredService<IEmployeeService>();
            var majorService = serviceProvider.GetRequiredService<IMajorService>();
            var classService = serviceProvider.GetRequiredService<IClassService>();
            var trainingProgramService = serviceProvider.GetRequiredService<ITrainingProgramService>();
            var studentService = serviceProvider.GetRequiredService<IStudentService>();
            // 🔹 Start Main Form and Inject Services
            var mainForm = new Form1(facultyService);
            var employeeForm = new EmployeeFormTest(employeeService);
            var majorForm = new MajorFormTest(majorService, facultyService);
            var classForm = new ClassFormTest(classService, majorService);
            var trainingProgramForm = new TrainingProgramFormTest(trainingProgramService);
            var studentForm = new StudentFormTest(studentService, classService, trainingProgramService);
            Application.Run(mainForm);
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
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMajorRepository, MajorRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ITrainingProgramRepository, TrainingProgramRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            // 🔹 Register Services
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ITrainingProgramService, TrainingProgramService>();
            services.AddScoped<IStudentService, StudentService>();

            return services.BuildServiceProvider();
        }

    }
}
