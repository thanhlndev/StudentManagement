using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagement.BusinessLogic.Interfaces;
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
            _facultyService = facultyService;
            LoadFaculties();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoadFaculties()
        {
            dataGridViewFaculties.DataSource = _facultyService.GetAllFaculties();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var faculty = new Faculty
            {
                FacultyID = txtFacultyID.Text,
                FacultyName = txtFacultyName.Text
            };
            _facultyService.AddFaculty(faculty);
            LoadFaculties();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewFaculties.SelectedRows.Count > 0)
            {
                var faculty = (Faculty)dataGridViewFaculties.SelectedRows[0].DataBoundItem;
                faculty.FacultyName = txtFacultyName.Text;
                _facultyService.UpdateFaculty(faculty);
                LoadFaculties();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewFaculties.SelectedRows.Count > 0)
            {
                var faculty = (Faculty)dataGridViewFaculties.SelectedRows[0].DataBoundItem;
                _facultyService.DeleteFaculty(faculty.FacultyID);
                LoadFaculties();
            }
        }
    }
}
