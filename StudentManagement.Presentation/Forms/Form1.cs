using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagement.BusinessLogic.InterfaceServices;
using StudentManagement.DataAccess.Entities;
using StudentManagement.BusinessLogic.Services;

namespace StudentManagement.Presentation
{
    public partial class Form1 : Form
    {
        private readonly IFacultyService _facultyService;
        public Form1(IFacultyService facultyService)
        {
            InitializeComponent();
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dgvFaculties.CellClick += dgvFaculties_CellClick;
            _facultyService = facultyService;
            LoadFaculties();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoadFaculties()
        {
            dgvFaculties.DataSource = _facultyService.GetAllFaculties();
            dgvFaculties.Columns["Majors"].Visible = false;
        }
        private void dgvFaculties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFaculties.SelectedCells.Count > 0) // Kiểm tra xem có phải là dòng hợp lệ không
            {
                DataGridViewRow selectedRow = dgvFaculties.SelectedCells[0].OwningRow;

                txtFacultyCode.Text = selectedRow.Cells["FacultyCode"].Value.ToString();
                txtFacultyName.Text = selectedRow.Cells["FacultyName"].Value.ToString();
            }
        }
        private void ClearFields()
        {
            txtFacultyCode.Clear();
            txtFacultyName.Clear();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {   
            string facultyCode = txtFacultyCode.Text.Trim();
            string facultyName = txtFacultyName.Text.Trim();

            // Kiểm tra xem facultyCode đã tồn tại chưa
            if (_facultyService.FacultyExists(facultyCode))
            {
                MessageBox.Show("Mã khoa đã tồn tại. Vui lòng nhập mã khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu không tồn tại, tiếp tục thêm mới
            var faculty = new Faculty
            {
                FacultyCode = facultyCode,
                FacultyName = facultyName
            };

            _facultyService.AddFaculty(faculty);

            LoadFaculties();

            MessageBox.Show("Thêm khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFields();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
           
            if (dgvFaculties.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khoa để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ DataGridView
            string oldFacultyCode = dgvFaculties.SelectedRows[0].Cells["facultyCode"].Value?.ToString();

            // Lấy dữ liệu từ TextBox
            string newFacultyCode = txtFacultyCode.Text.Trim();
            string newFacultyName = txtFacultyName.Text.Trim();

            // Kiểm tra nếu FacultyCode tồn tại trong DB
            if (!_facultyService.FacultyExists(oldFacultyCode))
            {
                MessageBox.Show("Khoa không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy Faculty từ DB dựa trên FacultyCode cũ
            var existingFaculty = _facultyService.GetFacultyByFacultyCode(oldFacultyCode);
            if (existingFaculty == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật dữ liệu
            existingFaculty.FacultyCode = newFacultyCode;
            existingFaculty.FacultyName = newFacultyName;

            // Gửi dữ liệu cập nhật vào DB
            _facultyService.UpdateFaculty(existingFaculty.Id, existingFaculty);

            // Làm mới danh sách
            LoadFaculties();

            // Hiển thị thông báo thành công
            MessageBox.Show("Cập nhật khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFaculties.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khoa để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy FacultyCode từ DataGridView
            string facultyCode = dgvFaculties.SelectedRows[0].Cells["facultyCode"].Value?.ToString();

            // Kiểm tra xem khoa có tồn tại không
            if (!_facultyService.FacultyExists(facultyCode))
            {
                MessageBox.Show("Khoa không tồn tại hoặc đã bị xóa trước đó!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khoa này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            // Lấy Faculty từ DB và xóa
            var faculty = _facultyService.GetFacultyByFacultyCode(facultyCode);
            if (faculty != null)
            {
                _facultyService.DeleteFaculty(faculty.Id);
                LoadFaculties();
                MessageBox.Show("Xóa khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin khoa để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
