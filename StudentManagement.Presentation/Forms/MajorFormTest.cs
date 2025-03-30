using System;
using System.Collections.Generic;
using System.Linq;
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
            LoadFaculties(); // Load danh sách Faculty vào ComboBox
            LoadMajors();
        }
        private void MajorFormTest_Load(object sender, EventArgs e)
        {
        }
        private void LoadFaculties()
        {
            var faculties = _facultyService.GetAllFaculties().ToList(); // Giả sử có phương thức này
            cboFaculty.DataSource = faculties;
            cboFaculty.DisplayMember = "FacultyName"; // Hiển thị FacultyName
            cboFaculty.ValueMember = "FacultyCode";   // Giá trị là FacultyCode
        }

        private void LoadMajors()
        {
            var majors = _majorService.GetAllMajors().Select(m => new
            {
                m.MajorCode,
                m.MajorName,
                m.FacultyCode,
                FacultyName = m.Faculty?.FacultyName
            }).ToList();
            dgvMajors.DataSource = majors;
        }

        private void dgvMajors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMajors.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMajors.SelectedCells[0].OwningRow;

                txtMajorCode.Text = selectedRow.Cells["MajorCode"].Value.ToString();
                txtMajorName.Text = selectedRow.Cells["MajorName"].Value.ToString();
                cboFaculty.SelectedValue = selectedRow.Cells["FacultyCode"].Value.ToString(); // Chọn Faculty trong ComboBox
            }
        }

        private void ClearFields()
        {
            txtMajorCode.Clear();
            txtMajorName.Clear();
            cboFaculty.SelectedIndex = -1; // Reset ComboBox
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
            string facultyCode = selectedFaculty.FacultyCode; // Lấy FacultyCode từ object Faculty

            if (string.IsNullOrEmpty(majorCode) || string.IsNullOrEmpty(majorName) || string.IsNullOrEmpty(facultyCode))
            {
                MessageBox.Show("Tất cả các trường đều không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            // Lấy Faculty từ ComboBox
            if (cboFaculty.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedFaculty = (Faculty)cboFaculty.SelectedItem;
            string newFacultyCode = selectedFaculty.FacultyCode; // Lấy FacultyCode từ object Faculty

            if (string.IsNullOrEmpty(newMajorCode) || string.IsNullOrEmpty(newMajorName) || string.IsNullOrEmpty(newFacultyCode))
            {
                MessageBox.Show("Tất cả các trường đều không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}