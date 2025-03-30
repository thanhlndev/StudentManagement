using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StudentManagement.BusinessLogic.InterfaceServices;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.Presentation.Forms
{
    public partial class EmployeeFormTest : Form
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeFormTest(IEmployeeService employeeService)
        {
            InitializeComponent();
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            _employeeService = employeeService;
            LoadEmployees();
        }

        private void EmployeeFormTest_Load(object sender, EventArgs e)
        {

        }

        private void LoadEmployees()
        {
            dgvEmployees.DataSource = _employeeService.GetAllEmployees();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployees.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dgvEmployees.SelectedCells[0].OwningRow;

                txtEmployeeCode.Text = selectedRow.Cells["EmployeeCode"].Value.ToString();
                txtEmployeeName.Text = selectedRow.Cells["EmployeeName"].Value.ToString();
                txtEmployeeType.Text = selectedRow.Cells["EmployeeType"].Value.ToString();
                dtpDateOfBirth.Value = Convert.ToDateTime(selectedRow.Cells["DateOfBirth"].Value);
                txtHometown.Text = selectedRow.Cells["Hometown"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtEmployeeCode.Clear();
            txtEmployeeName.Clear();
            txtEmployeeType.Clear();
            dtpDateOfBirth.Value = DateTime.Now;
            txtHometown.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string employeeCode = txtEmployeeCode.Text.Trim();
            string employeeName = txtEmployeeName.Text.Trim();
            string employeeType = txtEmployeeType.Text.Trim();
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            string hometown = txtHometown.Text.Trim();

            if (_employeeService.EmployeeExists(employeeCode))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var employee = new Employee
            {
                EmployeeCode = employeeCode,
                EmployeeName = employeeName,
                EmployeeType = employeeType,
                DateOfBirth = dateOfBirth,
                Hometown = hometown
            };

            _employeeService.AddEmployee(employee);
            LoadEmployees();

            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldEmployeeCode = dgvEmployees.SelectedRows[0].Cells["EmployeeCode"].Value?.ToString();
            string newEmployeeCode = txtEmployeeCode.Text.Trim();
            string newEmployeeName = txtEmployeeName.Text.Trim();
            string newEmployeeType = txtEmployeeType.Text.Trim();
            DateTime newDateOfBirth = dtpDateOfBirth.Value;
            string newHometown = txtHometown.Text.Trim();

            if (!_employeeService.EmployeeExists(oldEmployeeCode))
            {
                MessageBox.Show("Nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existingEmployee = _employeeService.GetByEmployeeCode(oldEmployeeCode);
            if (existingEmployee == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            existingEmployee.EmployeeCode = newEmployeeCode;
            existingEmployee.EmployeeName = newEmployeeName;
            existingEmployee.EmployeeType = newEmployeeType;
            existingEmployee.DateOfBirth = newDateOfBirth;
            existingEmployee.Hometown = newHometown;

            _employeeService.UpdateEmployee(existingEmployee.Id, existingEmployee);

            LoadEmployees();

            MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string employeeCode = dgvEmployees.SelectedRows[0].Cells["EmployeeCode"].Value?.ToString();

            if (!_employeeService.EmployeeExists(employeeCode))
            {
                MessageBox.Show("Nhân viên không tồn tại hoặc đã bị xóa trước đó!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            var employee = _employeeService.GetByEmployeeCode(employeeCode);
            if (employee != null)
            {
                _employeeService.DeleteEmployee(employee.Id);
                LoadEmployees();
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin nhân viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
