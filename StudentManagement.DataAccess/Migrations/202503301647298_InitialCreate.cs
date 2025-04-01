namespace StudentManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClassCode = c.String(nullable: false, maxLength: 10),
                        ClassName = c.String(nullable: false, maxLength: 100),
                        MajorCode = c.String(nullable: false, maxLength: 10),
                        EducationType = c.String(nullable: false, maxLength: 50),
                        ClassSection = c.String(nullable: false, maxLength: 5),
                        Major_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Majors", t => t.Major_Id)
                .Index(t => t.Major_Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GradeCode = c.Int(nullable: false),
                        StudentCode = c.String(),
                        CourseCode = c.String(),
                        ClassCode = c.String(),
                        Grade0 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Grade1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeCode = c.String(),
                        Class_Id = c.Guid(),
                        Employee_Id = c.Guid(),
                        Course_Id = c.Guid(),
                        Student_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Class_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseCode = c.String(nullable: false, maxLength: 10),
                        CourseName = c.String(nullable: false, maxLength: 100),
                        Semester = c.String(nullable: false, maxLength: 20),
                        CreditCount = c.Int(nullable: false),
                        EmployeeCode = c.String(nullable: false, maxLength: 10),
                        ProgramCode = c.String(nullable: false, maxLength: 10),
                        Employee_Id = c.Guid(),
                        Program_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.TrainingPrograms", t => t.Program_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Program_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployeeCode = c.String(nullable: false, maxLength: 10),
                        EmployeeName = c.String(nullable: false, maxLength: 100),
                        EmployeeType = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Hometown = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingPrograms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProgramCode = c.String(nullable: false, maxLength: 10),
                        ProgramType = c.String(nullable: false, maxLength: 50),
                        CreditCount = c.Int(nullable: false),
                        TrainingYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentCode = c.String(nullable: false, maxLength: 10),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 10),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 200),
                        Hometown = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 15),
                        EnrollmentYear = c.Int(nullable: false),
                        ClassCode = c.String(nullable: false, maxLength: 10),
                        ProgramCode = c.String(nullable: false, maxLength: 10),
                        Class_Id = c.Guid(),
                        Program_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id)
                .ForeignKey("dbo.TrainingPrograms", t => t.Program_Id)
                .Index(t => t.Class_Id)
                .Index(t => t.Program_Id);
            
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MajorCode = c.String(nullable: false, maxLength: 10),
                        MajorName = c.String(nullable: false, maxLength: 100),
                        FacultyCode = c.String(nullable: false, maxLength: 10),
                        Faculty_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.Faculty_Id)
                .Index(t => t.Faculty_Id);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FacultyCode = c.String(nullable: false, maxLength: 10),
                        FacultyName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Majors", "Faculty_Id", "dbo.Faculties");
            DropForeignKey("dbo.Classes", "Major_Id", "dbo.Majors");
            DropForeignKey("dbo.Students", "Program_Id", "dbo.TrainingPrograms");
            DropForeignKey("dbo.Grades", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Courses", "Program_Id", "dbo.TrainingPrograms");
            DropForeignKey("dbo.Grades", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Grades", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Courses", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Grades", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Majors", new[] { "Faculty_Id" });
            DropIndex("dbo.Students", new[] { "Program_Id" });
            DropIndex("dbo.Students", new[] { "Class_Id" });
            DropIndex("dbo.Courses", new[] { "Program_Id" });
            DropIndex("dbo.Courses", new[] { "Employee_Id" });
            DropIndex("dbo.Grades", new[] { "Student_Id" });
            DropIndex("dbo.Grades", new[] { "Course_Id" });
            DropIndex("dbo.Grades", new[] { "Employee_Id" });
            DropIndex("dbo.Grades", new[] { "Class_Id" });
            DropIndex("dbo.Classes", new[] { "Major_Id" });
            DropTable("dbo.Faculties");
            DropTable("dbo.Majors");
            DropTable("dbo.Students");
            DropTable("dbo.TrainingPrograms");
            DropTable("dbo.Employees");
            DropTable("dbo.Courses");
            DropTable("dbo.Grades");
            DropTable("dbo.Classes");
        }
    }
}
