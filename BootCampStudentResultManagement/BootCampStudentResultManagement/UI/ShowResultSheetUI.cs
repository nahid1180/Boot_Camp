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
using BootCampStudentResultManagement.DLL.Gateway;

namespace BootCampStudentResultManagement.UI
{
    public partial class ShowResultSheetUI : Form
    {
        public ShowResultSheetUI()
        {
            InitializeComponent();
        }
        Result aResult = new Result();
        Student aStudent = new Student();
        CourseEnrollBLL aCourseEnrollBll = new CourseEnrollBLL();
        Enroll aEnroll = new Enroll();
        ResultBLL aResultBll = new ResultBLL();
        ShowResultSheetBLL resultSheetBll=new ShowResultSheetBLL();
        EnrollmentGateWay aEnrollmentGateWay=new EnrollmentGateWay();
        private int registerNo;
        private void findButon_Click(object sender, EventArgs e)
        {
            
            registerNo = Convert.ToInt32(registerNoTextBox.Text);
            aStudent = aCourseEnrollBll.FindStudentOnDatabase(registerNo);
            nameTextBox.Text = aStudent.Name;
            emailTextBox.Text = aStudent.Email;
            double averageScore=resultSheetBll.GetAverageScore(aStudent.StudentId);
            averageScoreTextBox.Text = averageScore.ToString();
            gradeLetterTextBox.Text = resultSheetBll.GetAverageGradeLetter(averageScore);
            showResultDataGridView.DataSource = resultSheetBll.GetAllResultInformation(aStudent.StudentId);



            //string info = aEnroll.StudentId +"    " + aEnroll.CourseId+"    " + aResult.Score.ToString();


            //resultShowListView.Items.Add(info);
        }
    }
}
