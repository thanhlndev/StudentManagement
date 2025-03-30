using System;
using System.Linq;
using System.Windows.Forms;
using StudentManagement.BusinessLogic.InterfaceServices;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.Presentation.Forms
{
    public partial class TrainingProgramFormTest : Form
    {
        private readonly ITrainingProgramService _trainingProgramService;

        public TrainingProgramFormTest(ITrainingProgramService trainingProgramService)
        {
            InitializeComponent();
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            dgvTrainingPrograms.CellClick += dgvTrainingPrograms_CellClick;
            _trainingProgramService = trainingProgramService;
            LoadTrainingPrograms();
        }

        private void LoadTrainingPrograms()
        {
            dgvTrainingPrograms.DataSource = _trainingProgramService.GetAllTrainingPrograms().ToList();
            ConfigureTrainingProgramGridColumns();
        }

        private void ConfigureTrainingProgramGridColumns()
        {
            dgvTrainingPrograms.AutoGenerateColumns = true;
            dgvTrainingPrograms.Columns["ProgramCode"].HeaderText = "Mã chương trình";
            dgvTrainingPrograms.Columns["ProgramType"].HeaderText = "Loại chương trình";
            dgvTrainingPrograms.Columns["CreditCount"].HeaderText = "Số tín chỉ";
            dgvTrainingPrograms.Columns["TrainingYear"].HeaderText = "Năm đào tạo";
            if (dgvTrainingPrograms.Columns.Contains("Id"))
            {
                dgvTrainingPrograms.Columns["Id"].Visible = false;
            }
            if (dgvTrainingPrograms.Columns.Contains("Students"))
            {
                dgvTrainingPrograms.Columns["Students"].Visible = false;
            }
            if (dgvTrainingPrograms.Columns.Contains("Courses"))
            {
                dgvTrainingPrograms.Columns["Courses"].Visible = false;
            }
        }

        private void dgvTrainingPrograms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTrainingPrograms.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTrainingPrograms.SelectedCells[0].OwningRow;

                txtProgramCode.Text = selectedRow.Cells["ProgramCode"].Value?.ToString() ?? "";
                txtProgramType.Text = selectedRow.Cells["ProgramType"].Value?.ToString() ?? "";
                txtCreditCount.Text = selectedRow.Cells["CreditCount"].Value?.ToString() ?? "";
                txtTrainingYear.Text = selectedRow.Cells["TrainingYear"].Value?.ToString() ?? "";
            }
        }

        private void ClearFields()
        {
            txtProgramCode.Clear();
            txtProgramType.Clear();
            txtCreditCount.Clear();
            txtTrainingYear.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            string programCode = txtProgramCode.Text.Trim();
            string programType = txtProgramType.Text.Trim();
            int creditCount = int.Parse(txtCreditCount.Text);
            int trainingYear = int.Parse(txtTrainingYear.Text);

            if (_trainingProgramService.TrainingProgramExists(programCode))
            {
                MessageBox.Show("Mã chương trình đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var program = new TrainingProgram
            {
                ProgramCode = programCode,
                ProgramType = programType,
                CreditCount = creditCount,
                TrainingYear = trainingYear
            };

            try
            {
                _trainingProgramService.AddTrainingProgram(program);
                LoadTrainingPrograms();
                MessageBox.Show("Thêm chương trình đào tạo thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTrainingPrograms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một chương trình để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateFields()) return;

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn cập nhật chương trình này?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            string oldProgramCode = dgvTrainingPrograms.SelectedRows[0].Cells["ProgramCode"].Value?.ToString();
            var existingProgram = _trainingProgramService.GetByProgramCode(oldProgramCode);
            if (existingProgram == null)
            {
                MessageBox.Show("Chương trình không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            existingProgram.ProgramCode = txtProgramCode.Text.Trim();
            existingProgram.ProgramType = txtProgramType.Text.Trim();
            existingProgram.CreditCount = int.Parse(txtCreditCount.Text);
            existingProgram.TrainingYear = int.Parse(txtTrainingYear.Text);

            try
            {
                _trainingProgramService.UpdateTrainingProgram(existingProgram.Id, existingProgram);
                LoadTrainingPrograms();
                MessageBox.Show("Cập nhật chương trình thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTrainingPrograms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một chương trình để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa chương trình này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.No) return;

            string programCode = dgvTrainingPrograms.SelectedRows[0].Cells["ProgramCode"].Value?.ToString();
            var program = _trainingProgramService.GetByProgramCode(programCode);
            if (program != null)
            {
                _trainingProgramService.DeleteTrainingProgram(program.Id);
                LoadTrainingPrograms();
                MessageBox.Show("Xóa chương trình thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtProgramCode.Text.Trim()) ||
                string.IsNullOrEmpty(txtProgramType.Text.Trim()) ||
                !int.TryParse(txtCreditCount.Text, out _) ||
                !int.TryParse(txtTrainingYear.Text, out _))
            {
                MessageBox.Show("Tất cả các trường đều bắt buộc và số tín chỉ, năm đào tạo phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}