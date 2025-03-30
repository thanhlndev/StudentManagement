using System.Windows.Forms;

namespace StudentManagement.Presentation.Forms
{
    partial class MajorFormTest
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
        private void InitializeComponent()
        {
            this.dgvMajors = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMajorName = new System.Windows.Forms.TextBox();
            this.txtMajorCode = new System.Windows.Forms.TextBox();
            this.lbMajorName = new System.Windows.Forms.Label();
            this.lbMajorCode = new System.Windows.Forms.Label();
            this.lbFacultyName = new System.Windows.Forms.Label();
            this.cboFaculty = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMajors)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMajors
            // 
            this.dgvMajors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMajors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMajors.Location = new System.Drawing.Point(53, 458);
            this.dgvMajors.Name = "dgvMajors";
            this.dgvMajors.RowHeadersWidth = 92;
            this.dgvMajors.RowTemplate.Height = 37;
            this.dgvMajors.Size = new System.Drawing.Size(1146, 473);
            this.dgvMajors.TabIndex = 23;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.Location = new System.Drawing.Point(819, 328);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 55);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.Location = new System.Drawing.Point(551, 328);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 55);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(286, 328);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 55);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtMajorName
            // 
            this.txtMajorName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMajorName.Location = new System.Drawing.Point(539, 128);
            this.txtMajorName.Name = "txtMajorName";
            this.txtMajorName.Size = new System.Drawing.Size(386, 35);
            this.txtMajorName.TabIndex = 19;
            // 
            // txtMajorCode
            // 
            this.txtMajorCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMajorCode.Location = new System.Drawing.Point(539, 70);
            this.txtMajorCode.Name = "txtMajorCode";
            this.txtMajorCode.Size = new System.Drawing.Size(386, 35);
            this.txtMajorCode.TabIndex = 18;
            // 
            // lbMajorName
            // 
            this.lbMajorName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMajorName.AutoSize = true;
            this.lbMajorName.Location = new System.Drawing.Point(295, 131);
            this.lbMajorName.Name = "lbMajorName";
            this.lbMajorName.Size = new System.Drawing.Size(145, 29);
            this.lbMajorName.TabIndex = 17;
            this.lbMajorName.Text = "Major Name";
            // 
            // lbMajorCode
            // 
            this.lbMajorCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMajorCode.AutoSize = true;
            this.lbMajorCode.Location = new System.Drawing.Point(295, 73);
            this.lbMajorCode.Name = "lbMajorCode";
            this.lbMajorCode.Size = new System.Drawing.Size(139, 29);
            this.lbMajorCode.TabIndex = 16;
            this.lbMajorCode.Text = "Major Code";
            // 
            // lbFacultyName
            // 
            this.lbFacultyName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFacultyName.AutoSize = true;
            this.lbFacultyName.Location = new System.Drawing.Point(295, 192);
            this.lbFacultyName.Name = "lbFacultyName";
            this.lbFacultyName.Size = new System.Drawing.Size(160, 29);
            this.lbFacultyName.TabIndex = 24;
            this.lbFacultyName.Text = "Faculty Name";
            // 
            // cboFaculty
            // 
            this.cboFaculty.FormattingEnabled = true;
            this.cboFaculty.Location = new System.Drawing.Point(539, 189);
            this.cboFaculty.Name = "cboFaculty";
            this.cboFaculty.Size = new System.Drawing.Size(386, 37);
            this.cboFaculty.TabIndex = 25;
            // 
            // MajorFormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 1001);
            this.Controls.Add(this.cboFaculty);
            this.Controls.Add(this.lbFacultyName);
            this.Controls.Add(this.dgvMajors);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMajorName);
            this.Controls.Add(this.txtMajorCode);
            this.Controls.Add(this.lbMajorName);
            this.Controls.Add(this.lbMajorCode);
            this.Name = "MajorFormTest";
            this.Text = "MajorFormTest";
            this.Load += new System.EventHandler(this.MajorFormTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMajors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMajors;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMajorName;
        private System.Windows.Forms.TextBox txtMajorCode;
        private System.Windows.Forms.Label lbMajorName;
        private System.Windows.Forms.Label lbMajorCode;
        private System.Windows.Forms.Label lbFacultyName;
        private ComboBox cboFaculty;
    }
}