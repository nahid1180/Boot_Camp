using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BootCampStudentResultManagement.BLL;
using BootCampStudentResultManagement.DLL.DAO;

namespace BootCampStudentResultManagement.UI
{
    public partial class EnterResultUI : Form
    {
        public EnterResultUI()
        {
            InitializeComponent();
            AddToCombobox();
        }
        Student aStudent = new Student();
        CourseEnrollBLL aCourseEnrollBll = new CourseEnrollBLL();
        Enroll aEnroll = new Enroll();
        ResultBLL aResultBll = new ResultBLL();
        private int registerNo;
        public void AddToCombobox()
        {
            courseComboBox.DisplayMember = "courseTitle";
            courseComboBox.DataSource = aCourseEnrollBll.AddToCombobox();
        }
       
        private void findButton_Click(object sender, EventArgs e)
        {
              
            registerNo = Convert.ToInt32(registerNoTextBox.Text);           
            aStudent = aCourseEnrollBll.FindStudentOnDatabase(registerNo);
            nameTextBox.Text = aStudent.Name;
            emailTextBox.Text = aStudent.Email;

        }

        private void saveButtton_Click(object sender, EventArgs e)
        {
            DateTime date;
            string course; 
            date = Convert.ToDateTime(resultPublishDateTimePicker.Text);
            course = courseComboBox.Text;
            double score= Convert.ToDouble(scoreTextBox.Text);
            Result aResult=new Result(score,date);
            aEnroll.CourseId = aResultBll.GetCourseId(course);
            aEnroll.StudentId = aStudent.StudentId;
            aEnroll.aResult = aResult;
            MessageBox.Show(aResultBll.SetScoreOnDatabase(aEnroll));
        }

        private void viewResultSheetButton_Click(object sender, EventArgs e)
        {
            ShowResultSheetUI aShowResultSheetUi = new ShowResultSheetUI();
            aShowResultSheetUi.ShowDialog();
        }
    }
}
