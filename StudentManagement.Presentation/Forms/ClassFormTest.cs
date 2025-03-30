using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentManagement.BusinessLogic.InterfaceServices;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.Presentation.Forms
{
    public partial class ClassFormTest : Form
    {
        private readonly IClassService _classService;
        private readonly IMajorService _majorService;

        public ClassFormTest(IClassService classService, IMajorService majorService)
        {
            InitializeComponent();
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            dgvClasses.CellClick += dgvClasses_CellClick;
            _classService = classService;
            _majorService = majorService;
            LoadMajors(); // Load danh sách Major vào ComboBox
            LoadClasses();
        }

        private void LoadMajors()
        {
            var majors = _majorService.GetAllMajors().ToList();
            cboMajor.DataSource = majors;
            cboMajor.DisplayMember = "MajorName"; // Hiển thị MajorName
            cboMajor.ValueMember = "MajorCode";   // Giá trị là MajorCode
        }

        private void LoadClasses()
        {   var majors = _majorService.GetAllMajors().ToDictionary(m => m.MajorCode, m => m.MajorName);
            var classes = _classService.GetAllClasses().Select(c => new
            {
                c.ClassCode,
                c.ClassName,
                c.MajorCode,
                MajorName = majors.TryGetValue(c.MajorCode, out var name) ? name : "Unknown",
                c.EducationType,
                c.ClassSection
            }).ToList();
            dgvClasses.DataSource = classes;
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClasses.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dgvClasses.SelectedCells[0].OwningRow;

                txtClassCode.Text = selectedRow.Cells["ClassCode"].Value.ToString();
                txtClassName.Text = selectedRow.Cells["ClassName"].Value.ToString();
                cboMajor.SelectedValue = selectedRow.Cells["MajorCode"].Value.ToString();
                txtEducationType.Text = selectedRow.Cells["EducationType"].Value.ToString();
                txtClassSection.Text = selectedRow.Cells["ClassSection"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtClassCode.Clear();
            txtClassName.Clear();
            cboMajor.SelectedIndex = -1;
            txtEducationType.Clear();
            txtClassSection.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string classCode = txtClassCode.Text.Trim();
            string className = txtClassName.Text.Trim();
            string educationType = txtEducationType.Text.Trim();
            string classSection = txtClassSection.Text.Trim();

            if (cboMajor.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một ngành học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedMajor = (Major)cboMajor.SelectedItem;
            string majorCode = selectedMajor.MajorCode;

            if (string.IsNullOrEmpty(classCode) || string.IsNullOrEmpty(className) || string.IsNullOrEmpty(majorCode))
            {
                MessageBox.Show("Mã lớp, tên lớp và ngành học không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_classService.ClassExists(classCode))
            {
                MessageBox.Show("Mã lớp đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var classEntity = new Class
            {
                ClassCode = classCode,
                ClassName = className,
                MajorCode = majorCode,
                EducationType = educationType,
                ClassSection = classSection
            };

            try
            {
                _classService.AddClass(classEntity);
                LoadClasses();
                MessageBox.Show("Thêm lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvClasses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldClassCode = dgvClasses.SelectedRows[0].Cells["ClassCode"].Value?.ToString();
            string newClassCode = txtClassCode.Text.Trim();
            string newClassName = txtClassName.Text.Trim();
            string newEducationType = txtEducationType.Text.Trim();
            string newClassSection = txtClassSection.Text.Trim();

            if (cboMajor.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một ngành học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedMajor = (Major)cboMajor.SelectedItem;
            string newMajorCode = selectedMajor.MajorCode;

            if (string.IsNullOrEmpty(newClassCode) || string.IsNullOrEmpty(newClassName) || string.IsNullOrEmpty(newMajorCode))
            {
                MessageBox.Show("Mã lớp, tên lớp và ngành học không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existingClass = _classService.GetByClassCode(oldClassCode);
            if (existingClass == null)
            {
                MessageBox.Show("Lớp học không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            existingClass.ClassCode = newClassCode;
            existingClass.ClassName = newClassName;
            existingClass.MajorCode = newMajorCode;
            existingClass.EducationType = newEducationType;
            existingClass.ClassSection = newClassSection;

            try
            {
                _classService.UpdateClass(existingClass.Id, existingClass);
                LoadClasses();
                MessageBox.Show("Cập nhật lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClasses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string classCode = dgvClasses.SelectedRows[0].Cells["ClassCode"].Value?.ToString();

            if (!_classService.ClassExists(classCode))
            {
                MessageBox.Show("Lớp học không tồn tại hoặc đã bị xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            var classEntity = _classService.GetByClassCode(classCode);
            if (classEntity != null)
            {
                _classService.DeleteClass(classEntity.Id);
                LoadClasses();
                MessageBox.Show("Xóa lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
        }

        private void ClassFormTest_Load(object sender, EventArgs e)
        {

        }
    }
}