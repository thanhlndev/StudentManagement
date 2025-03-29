namespace StudentManagement.Presentation
{
    partial class Form1
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
            this.lbFacultyID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFacultyID = new System.Windows.Forms.TextBox();
            this.txtFacultyName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewFaculties = new System.Windows.Forms.DataGridView();
            this.FacultyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacultyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaculties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFacultyID
            // 
            this.lbFacultyID.AutoSize = true;
            this.lbFacultyID.Location = new System.Drawing.Point(118, 57);
            this.lbFacultyID.Name = "lbFacultyID";
            this.lbFacultyID.Size = new System.Drawing.Size(115, 29);
            this.lbFacultyID.TabIndex = 0;
            this.lbFacultyID.Text = "Faculty Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Faculty Name";
            // 
            // txtFacultyID
            // 
            this.txtFacultyID.Location = new System.Drawing.Point(430, 57);
            this.txtFacultyID.Name = "txtFacultyID";
            this.txtFacultyID.Size = new System.Drawing.Size(307, 35);
            this.txtFacultyID.TabIndex = 2;
            // 
            // txtFacultyName
            // 
            this.txtFacultyName.Location = new System.Drawing.Point(430, 115);
            this.txtFacultyName.Name = "txtFacultyName";
            this.txtFacultyName.Size = new System.Drawing.Size(307, 35);
            this.txtFacultyName.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(138, 233);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 36);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(389, 233);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 36);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(627, 233);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 36);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFaculties
            // 
            this.dataGridViewFaculties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFaculties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FacultyID,
            this.FacultyName});
            this.dataGridViewFaculties.Location = new System.Drawing.Point(82, 380);
            this.dataGridViewFaculties.Name = "dataGridViewFaculties";
            this.dataGridViewFaculties.RowHeadersWidth = 92;
            this.dataGridViewFaculties.RowTemplate.Height = 37;
            this.dataGridViewFaculties.Size = new System.Drawing.Size(774, 150);
            this.dataGridViewFaculties.TabIndex = 7;
            // 
            // FacultyID
            // 
            this.FacultyID.HeaderText = "Faculty ID";
            this.FacultyID.MinimumWidth = 11;
            this.FacultyID.Name = "FacultyID";
            this.FacultyID.Width = 225;
            // 
            // FacultyName
            // 
            this.FacultyName.HeaderText = "Faculty Name";
            this.FacultyName.MinimumWidth = 11;
            this.FacultyName.Name = "FacultyName";
            this.FacultyName.Width = 225;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 566);
            this.Controls.Add(this.dataGridViewFaculties);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtFacultyName);
            this.Controls.Add(this.txtFacultyID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbFacultyID);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaculties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFacultyID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFacultyID;
        private System.Windows.Forms.TextBox txtFacultyName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewFaculties;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacultyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacultyName;
    }
}

