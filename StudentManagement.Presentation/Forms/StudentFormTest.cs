using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using StudentManagement.BusinessLogic.InterfaceServices;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.Presentation.Forms
{
    public partial class StudentFormTest : Form
    {
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
        private readonly ITrainingProgramService _trainingProgramService;
        private List<Class> _classList;
        private List<TrainingProgram> _programList;

        public StudentFormTest(IStudentService studentService, IClassService classService, ITrainingProgramService trainingProgramService)
        {
            InitializeComponent();
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            dgvStudents.CellClick += dgvStudents_CellClick;
            _studentService = studentService;
            _classService = classService;
            _trainingProgramService = trainingProgramService;
            LoadData();
        }

        private void LoadData()
        {
            LoadGenders();
            _classList = _classService.GetAllClasses().ToList();
            _programList = _trainingProgramService.GetAllTrainingPrograms().ToList();
            LoadClasses();
            LoadTrainingPrograms();
            LoadStudents();
        }

        private void LoadGenders()
        {
            cboGender.Items.AddRange(new[] { "Nam", "Nữ" });
        }

        private void LoadClasses()
        {
            cboClass.DataSource = _classList;
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassCode";
        }

        private void LoadTrainingPrograms()
        {
            cboProgram.DataSource = _programList;
            cboProgram.DisplayMember = "ProgramType";
            cboProgram.ValueMember = "ProgramCode";
        }
         private void ConfigureStudentGridColumns()
        {
            dgvStudents.AutoGenerateColumns = true;
            dgvStudents.Columns["StudentCode"].HeaderText = "Mã sinh viên";
            dgvStudents.Columns["FullName"].HeaderText = "Họ và tên";
            dgvStudents.Columns["Gender"].HeaderText = "Giới tính";
            dgvStudents.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            dgvStudents.Columns["Address"].HeaderText = "Địa chỉ";
            dgvStudents.Columns["Hometown"].HeaderText = "Quê quán";
            dgvStudents.Columns["Email"].HeaderText = "Email";
            dgvStudents.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            dgvStudents.Columns["EnrollmentYear"].HeaderText = "Năm nhập học";
            dgvStudents.Columns["ClassName"].HeaderText = "Tên lớp";
            dgvStudents.Columns["ProgramType"].HeaderText = "Loại chương trình";
        }
        private void LoadStudents()
        {
            var classes = _classService.GetAllClasses().ToDictionary(c => c.ClassCode, c => c.ClassName);
            var programs = _trainingProgramService.GetAllTrainingPrograms().ToDictionary(p => p.ProgramCode, p => p.ProgramType);
            var students = _studentService.GetAllStudents().Select(s => new
            {
                s.StudentCode,
                s.FullName,
                s.Gender,
                s.DateOfBirth,
                s.Address,
                s.Hometown,
                s.Email,
                s.PhoneNumber,
                s.EnrollmentYear,
                ClassName = classes.TryGetValue(s.ClassCode, out var name) ? name : "Unknown",
                ProgramType = programs.TryGetValue(s.ProgramCode, out var type) ? type : "Unknown"
            }).ToList();

            dgvStudents.DataSource = students;
            ConfigureStudentGridColumns();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvStudents.Rows[e.RowIndex];
            txtStudentCode.Text = row.Cells["StudentCode"].Value.ToString();
            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            cboGender.SelectedItem = row.Cells["Gender"].Value.ToString();
            dtpDateOfBirth.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
            txtAddress.Text = row.Cells["Address"].Value.ToString();
            txtHometown.Text = row.Cells["Hometown"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
            txtEnrollmentYear.Text = row.Cells["EnrollmentYear"].Value.ToString();
            cboClass.SelectedValue = _studentService.GetByStudentCode(txtStudentCode.Text)?.ClassCode;
            cboProgram.SelectedValue = _studentService.GetByStudentCode(txtStudentCode.Text)?.ProgramCode;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentInput()) return;

            var student = new Student
            {
                StudentCode = txtStudentCode.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Gender = cboGender.SelectedItem?.ToString(),
                DateOfBirth = dtpDateOfBirth.Value,
                Address = txtAddress.Text.Trim(),
                Hometown = txtHometown.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                EnrollmentYear = int.Parse(txtEnrollmentYear.Text),
                ClassCode = (string)cboClass.SelectedValue,
                ProgramCode = (string)cboProgram.SelectedValue
            };

            if (_studentService.StudentExists(student.StudentCode))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _studentService.AddStudent(student);
            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadStudents();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0) return;
            if (!ValidateStudentInput()) return;

            var studentCode = dgvStudents.SelectedRows[0].Cells["StudentCode"].Value.ToString();
            var student = _studentService.GetByStudentCode(studentCode);
            if (student == null) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin sinh viên?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            student.FullName = txtFullName.Text.Trim();
            student.Gender = cboGender.SelectedItem?.ToString();
            student.DateOfBirth = dtpDateOfBirth.Value;
            student.Address = txtAddress.Text.Trim();
            student.Hometown = txtHometown.Text.Trim();
            student.Email = txtEmail.Text.Trim();
            student.PhoneNumber = txtPhoneNumber.Text.Trim();
            student.EnrollmentYear = int.Parse(txtEnrollmentYear.Text);
            student.ClassCode = (string)cboClass.SelectedValue;
            student.ProgramCode = (string)cboProgram.SelectedValue;

            _studentService.UpdateStudent(student.Id, student);
            MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0) return;

            var studentCode = dgvStudents.SelectedRows[0].Cells["StudentCode"].Value.ToString();
            var student = _studentService.GetByStudentCode(studentCode);
            if (student == null) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            _studentService.DeleteStudent(student.Id);
            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadStudents();
        }

        private bool ValidateStudentInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentCode.Text))
            {
                MessageBox.Show("Mã sinh viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Họ và tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cboGender.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) // Kiểm tra định dạng email
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtPhoneNumber.Text, @"^\d{10}$")) // Kiểm tra số điện thoại có đúng 10 chữ số
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtEnrollmentYear.Text, out int year) || year < 2000 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Năm nhập học không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}