namespace StudentManagement.Presentation.Forms
{
    partial class StudentFormTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbHomeTown = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbGender = new System.Windows.Forms.Label();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtStudentCode = new System.Windows.Forms.TextBox();
            this.lbFullName = new System.Windows.Forms.Label();
            this.lbStudentCode = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbPhoneNumber = new System.Windows.Forms.Label();
            this.lbDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lbEnrollmentYear = new System.Windows.Forms.Label();
            this.lbClassName = new System.Windows.Forms.Label();
            this.lbTrainingProgramType = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.cboProgram = new System.Windows.Forms.ComboBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtHometown = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtEnrollmentYear = new System.Windows.Forms.TextBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHomeTown
            // 
            this.lbHomeTown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHomeTown.AutoSize = true;
            this.lbHomeTown.Location = new System.Drawing.Point(710, 267);
            this.lbHomeTown.Name = "lbHomeTown";
            this.lbHomeTown.Size = new System.Drawing.Size(118, 29);
            this.lbHomeTown.TabIndex = 58;
            this.lbHomeTown.Text = "Quê quán";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtAddress.Location = new System.Drawing.Point(235, 432);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(452, 35);
            this.txtAddress.TabIndex = 57;
            // 
            // lbAddress
            // 
            this.lbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(41, 435);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(91, 29);
            this.lbAddress.TabIndex = 56;
            this.lbAddress.Text = "Địa Chỉ";
            // 
            // lbGender
            // 
            this.lbGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbGender.AutoSize = true;
            this.lbGender.Location = new System.Drawing.Point(41, 270);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(101, 29);
            this.lbGender.TabIndex = 54;
            this.lbGender.Text = "Giới tính";
            // 
            // dgvStudents
            // 
            this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(57, 758);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 92;
            this.dgvStudents.RowTemplate.Height = 37;
            this.dgvStudents.Size = new System.Drawing.Size(1318, 167);
            this.dgvStudents.TabIndex = 53;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.Location = new System.Drawing.Point(904, 630);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 55);
            this.btnDelete.TabIndex = 52;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.Location = new System.Drawing.Point(636, 630);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 55);
            this.btnUpdate.TabIndex = 51;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(371, 630);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 55);
            this.btnAdd.TabIndex = 50;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtFullName.Location = new System.Drawing.Point(235, 178);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(452, 35);
            this.txtFullName.TabIndex = 49;
            // 
            // txtStudentCode
            // 
            this.txtStudentCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudentCode.Location = new System.Drawing.Point(445, 73);
            this.txtStudentCode.Name = "txtStudentCode";
            this.txtStudentCode.Size = new System.Drawing.Size(631, 35);
            this.txtStudentCode.TabIndex = 48;
            // 
            // lbFullName
            // 
            this.lbFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbFullName.AutoSize = true;
            this.lbFullName.Location = new System.Drawing.Point(41, 181);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(113, 29);
            this.lbFullName.TabIndex = 47;
            this.lbFullName.Text = "Họ và tên";
            // 
            // lbStudentCode
            // 
            this.lbStudentCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStudentCode.AutoSize = true;
            this.lbStudentCode.Location = new System.Drawing.Point(251, 76);
            this.lbStudentCode.Name = "lbStudentCode";
            this.lbStudentCode.Size = new System.Drawing.Size(83, 29);
            this.lbStudentCode.TabIndex = 46;
            this.lbStudentCode.Text = "Mã SV";
            // 
            // lbEmail
            // 
            this.lbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(710, 178);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(74, 29);
            this.lbEmail.TabIndex = 60;
            this.lbEmail.Text = "Email";
            // 
            // lbPhoneNumber
            // 
            this.lbPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbPhoneNumber.AutoSize = true;
            this.lbPhoneNumber.Location = new System.Drawing.Point(710, 352);
            this.lbPhoneNumber.Name = "lbPhoneNumber";
            this.lbPhoneNumber.Size = new System.Drawing.Size(154, 29);
            this.lbPhoneNumber.TabIndex = 62;
            this.lbPhoneNumber.Text = "Số điện thoại";
            // 
            // lbDateOfBirth
            // 
            this.lbDateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbDateOfBirth.AutoSize = true;
            this.lbDateOfBirth.Location = new System.Drawing.Point(41, 357);
            this.lbDateOfBirth.Name = "lbDateOfBirth";
            this.lbDateOfBirth.Size = new System.Drawing.Size(119, 29);
            this.lbDateOfBirth.TabIndex = 64;
            this.lbDateOfBirth.Text = "Ngày sinh";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtpDateOfBirth.Location = new System.Drawing.Point(235, 352);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(452, 35);
            this.dtpDateOfBirth.TabIndex = 65;
            // 
            // lbEnrollmentYear
            // 
            this.lbEnrollmentYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbEnrollmentYear.AutoSize = true;
            this.lbEnrollmentYear.Location = new System.Drawing.Point(710, 432);
            this.lbEnrollmentYear.Name = "lbEnrollmentYear";
            this.lbEnrollmentYear.Size = new System.Drawing.Size(168, 29);
            this.lbEnrollmentYear.TabIndex = 67;
            this.lbEnrollmentYear.Text = "Năm nhập học";
            // 
            // lbClassName
            // 
            this.lbClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbClassName.AutoSize = true;
            this.lbClassName.Location = new System.Drawing.Point(41, 512);
            this.lbClassName.Name = "lbClassName";
            this.lbClassName.Size = new System.Drawing.Size(96, 29);
            this.lbClassName.TabIndex = 68;
            this.lbClassName.Text = "Tên lớp";
            // 
            // lbTrainingProgramType
            // 
            this.lbTrainingProgramType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbTrainingProgramType.AutoSize = true;
            this.lbTrainingProgramType.Location = new System.Drawing.Point(710, 512);
            this.lbTrainingProgramType.Name = "lbTrainingProgramType";
            this.lbTrainingProgramType.Size = new System.Drawing.Size(131, 29);
            this.lbTrainingProgramType.TabIndex = 69;
            this.lbTrainingProgramType.Text = "Loại CTDT";
            // 
            // cboClass
            // 
            this.cboClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(230, 509);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(452, 37);
            this.cboClass.TabIndex = 70;
            // 
            // cboProgram
            // 
            this.cboProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cboProgram.FormattingEnabled = true;
            this.cboProgram.Location = new System.Drawing.Point(899, 504);
            this.cboProgram.Name = "cboProgram";
            this.cboProgram.Size = new System.Drawing.Size(452, 37);
            this.cboProgram.TabIndex = 71;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(899, 351);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(452, 35);
            this.txtPhoneNumber.TabIndex = 72;
            // 
            // txtHometown
            // 
            this.txtHometown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtHometown.Location = new System.Drawing.Point(899, 267);
            this.txtHometown.Name = "txtHometown";
            this.txtHometown.Size = new System.Drawing.Size(452, 35);
            this.txtHometown.TabIndex = 73;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtEmail.Location = new System.Drawing.Point(899, 175);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(452, 35);
            this.txtEmail.TabIndex = 74;
            // 
            // txtEnrollmentYear
            // 
            this.txtEnrollmentYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtEnrollmentYear.Location = new System.Drawing.Point(899, 429);
            this.txtEnrollmentYear.Name = "txtEnrollmentYear";
            this.txtEnrollmentYear.Size = new System.Drawing.Size(452, 35);
            this.txtEnrollmentYear.TabIndex = 75;
            // 
            // cboGender
            // 
            this.cboGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(235, 267);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(452, 37);
            this.cboGender.TabIndex = 76;
            // 
            // StudentFormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 1001);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.txtEnrollmentYear);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtHometown);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.cboProgram);
            this.Controls.Add(this.cboClass);
            this.Controls.Add(this.lbTrainingProgramType);
            this.Controls.Add(this.lbClassName);
            this.Controls.Add(this.lbEnrollmentYear);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.lbDateOfBirth);
            this.Controls.Add(this.lbPhoneNumber);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbHomeTown);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.lbGender);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtStudentCode);
            this.Controls.Add(this.lbFullName);
            this.Controls.Add(this.lbStudentCode);
            this.Name = "StudentFormTest";
            this.Text = "StudentFormTest";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbHomeTown;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtStudentCode;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.Label lbStudentCode;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPhoneNumber;
        private System.Windows.Forms.Label lbDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lbEnrollmentYear;
        private System.Windows.Forms.Label lbClassName;
        private System.Windows.Forms.Label lbTrainingProgramType;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.ComboBox cboProgram;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtHometown;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtEnrollmentYear;
        private System.Windows.Forms.ComboBox cboGender;
    }
}