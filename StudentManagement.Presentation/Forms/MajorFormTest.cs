using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using StudentManagement.BusinessLogic.InterfaceServices;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.Presentation.Forms
{
    public partial class MajorFormTest : Form
    {
        private readonly IMajorService _majorService;
        private readonly IFacultyService _facultyService;

        public MajorFormTest(IMajorService majorService, IFacultyService facultyService)
        {
            InitializeComponent();
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            dgvMajors.CellClick += dgvMajors_CellClick;
            _majorService = majorService;
            _facultyService = facultyService;
            LoadDatas();
        }
        private void MajorFormTest_Load(object sender, EventArgs e)
        {
        }
        private void LoadDatas()
        {
            LoadFaculties();
            LoadMajors();       
        }
        private void LoadFaculties()
        {
            var faculties = _facultyService.GetAllFaculties().ToList();
            cboFaculty.DataSource = faculties;
            cboFaculty.DisplayMember = "FacultyName"; 
            cboFaculty.ValueMember = "FacultyCode"; 
        }

        private void LoadMajors()
        {
            var faculties = _facultyService.GetAllFaculties().ToDictionary(f => f.FacultyCode, f => f.FacultyName);
            var majors = _majorService.GetAllMajors().Select(m => new
            {
                m.MajorCode,
                m.MajorName,
                m.FacultyCode,
                FacultyName = faculties.TryGetValue(m.FacultyCode, out var name) ? name : "Unknown"
            }).ToList();
            dgvMajors.DataSource = majors;
            ConfigureMajorGridColumns();
        }

        private void dgvMajors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMajors.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMajors.SelectedCells[0].OwningRow;

                txtMajorCode.Text = selectedRow.Cells["MajorCode"].Value.ToString();
                txtMajorName.Text = selectedRow.Cells["MajorName"].Value.ToString();
                cboFaculty.SelectedValue = selectedRow.Cells["FacultyCode"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtMajorCode.Clear();
            txtMajorName.Clear();
            cboFaculty.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string majorCode = txtMajorCode.Text.Trim();
            string majorName = txtMajorName.Text.Trim();

            // Lấy Faculty từ ComboBox
            if (cboFaculty.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedFaculty = (Faculty)cboFaculty.SelectedItem;
            string facultyCode = selectedFaculty.FacultyCode;


            if (!ValidateStudentInput()) return;
            if (_majorService.MajorExists(majorCode))
            {
                MessageBox.Show("Mã ngành đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var major = new Major
            {
                MajorCode = majorCode,
                MajorName = majorName,
                FacultyCode = facultyCode
            };

            try
            {
                _majorService.AddMajor(major);
                LoadMajors();
                MessageBox.Show("Thêm ngành học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (dgvMajors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một ngành để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string oldMajorCode = dgvMajors.SelectedRows[0].Cells["MajorCode"].Value?.ToString();
            string newMajorCode = txtMajorCode.Text.Trim();
            string newMajorName = txtMajorName.Text.Trim();

            

            var selectedFaculty = (Faculty)cboFaculty.SelectedItem;
            string newFacultyCode = selectedFaculty.FacultyCode;

            if (!ValidateStudentInput()) return;
            if (string.IsNullOrEmpty(newFacultyCode))
            {
                MessageBox.Show("Khoa không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var existingMajor = _majorService.GetByMajorCode(oldMajorCode);
            if (existingMajor == null)
            {
                MessageBox.Show("Ngành học không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            existingMajor.MajorCode = newMajorCode;
            existingMajor.MajorName = newMajorName;
            existingMajor.FacultyCode = newFacultyCode;

            try
            {
                _majorService.UpdateMajor(existingMajor.Id, existingMajor);
                LoadMajors();
                MessageBox.Show("Cập nhật ngành học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMajors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một ngành để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string majorCode = dgvMajors.SelectedRows[0].Cells["MajorCode"].Value?.ToString();

            if (!_majorService.MajorExists(majorCode))
            {
                MessageBox.Show("Ngành học không tồn tại hoặc đã bị xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ngành học này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            var major = _majorService.GetByMajorCode(majorCode);
            if (major != null)
            {
                _majorService.DeleteMajor(major.Id);
                LoadMajors();
                MessageBox.Show("Xóa ngành học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
        }
        private void ConfigureMajorGridColumns()
        {
            dgvMajors.Columns["MajorCode"].HeaderText = "Mã Ngành";
            dgvMajors.Columns["MajorName"].HeaderText = "Tên Ngành";
            dgvMajors.Columns["FacultyCode"].HeaderText = "Mã Khoa";
            dgvMajors.Columns["FacultyName"].HeaderText = "Tên Khoa";
        }
        private bool ValidateStudentInput()
        {
            if (string.IsNullOrWhiteSpace(txtMajorCode.Text))
            {
                MessageBox.Show("Mã nghành không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMajorName.Text))
            {
                MessageBox.Show("Tên ngành không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}