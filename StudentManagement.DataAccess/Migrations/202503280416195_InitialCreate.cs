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
                        ClassID = c.String(),
                        ClassName = c.String(),
                        MajorID = c.String(),
                        EducationType = c.String(),
                        Course = c.String(),
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
                        GradeID = c.Int(nullable: false),
                        StudentID = c.String(),
                        CourseID = c.String(),
                        ClassID = c.String(),
                        Grade0 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Grade1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeID = c.String(),
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
                        CourseID = c.String(),
                        CourseName = c.String(),
                        Semester = c.String(),
                        CreditCount = c.Int(nullable: false),
                        EmployeeID = c.String(),
                        ProgramID = c.String(),
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
                        EmployeeID = c.String(),
                        EmployeeName = c.String(),
                        EmployeeType = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Hometown = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingPrograms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProgramID = c.String(),
                        ProgramType = c.String(),
                        CreditCount = c.Int(nullable: false),
                        TrainingYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentID = c.String(),
                        FullName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(),
                        Hometown = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        EnrollmentYear = c.Int(nullable: false),
                        ClassID = c.String(),
                        ProgramID = c.String(),
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
                        MajorID = c.String(),
                        MajorName = c.String(),
                        FacultyID = c.String(),
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
                        FacultyID = c.String(),
                        FacultyName = c.String(),
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
