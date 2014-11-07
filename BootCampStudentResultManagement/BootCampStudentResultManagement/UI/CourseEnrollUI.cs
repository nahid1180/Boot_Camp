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
    public partial class CourseEnrollUI : Form
    {
        public CourseEnrollUI()
        {
            InitializeComponent();
            AddToCombobox();
        }
        Student aStudent=new Student();
        CourseEnrollBLL aCourseEnrollBll=new CourseEnrollBLL();
        private int registerNo;
        CourseGateway aCourseGateway=new CourseGateway();

        public void AddToCombobox()
        {
            courseComboBox.DisplayMember = "courseTitle";
            courseComboBox.DataSource = aCourseEnrollBll.AddToCombobox();
        }
        private void findButton_Click(object sender, EventArgs e)
        {
            registerNo = Convert.ToInt32(registerNoTextBox.Text);
            aStudent=aCourseEnrollBll.FindStudentOnDatabase(registerNo);
            nameTextBox.Text = aStudent.Name;
            emailTextBox.Text = aStudent.Email;
            List<AddToListView>courseList=new List<AddToListView>();
            //courseList = aCourseEnrollBll.Course(aStudent.StudentId);
            courseList= aCourseGateway.GetCourseList(aStudent.StudentId);
           
            CourseAddtDataGridView.DataSource = courseList;
            //courseShowListView.Items.Add(listViewItems);
            // aCourseGateway.GetCourseList(aStudent.StudentId);

        }

        private void enrollButton_Click(object sender, EventArgs e)
        {
            AddToListView addToListView = new AddToListView();
            Enroll aEnroll=new Enroll();

            aEnroll.CourseEnrollDate = Convert.ToDateTime(enrollDateTimePicker.Text);
            string course = courseComboBox.Text;
            aEnroll.StudentId = aStudent.StudentId;
            aEnroll.CourseId = aEnroll.CourseId;
            aEnroll.CourseTitle = course;
            string msg = aCourseEnrollBll.EnrollStudentCourse(aEnroll, course);
            MessageBox.Show(msg);

            
            //courseShowListView.Items.Add(addToListView.EnrollDate);
        }
    }
}
