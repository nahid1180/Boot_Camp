using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampStudentResultManagement.DLL.DAO;

namespace BootCampStudentResultManagement.DLL.Gateway
{
    class CourseGateway
    {
        SqlConnection aConnection=new SqlConnection();
        public CourseGateway()
        {
            string connection = @"server=BITM-301-PC00;database=BootCamp;integrated security=true";
            aConnection.ConnectionString = connection;
        }

        public List<Course> GetAllCourseList()
        {
            aConnection.Open();
            
            List<Course> courseList=new List<Course>();
            string query = string.Format("select * from Course_Table");
            SqlCommand aCommand=new SqlCommand(query,aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Course aCourse = new Course();
                    aCourse.CourseTitle = aReader[1].ToString();
                    aCourse.CourseName = aReader[2].ToString();
                    courseList.Add(aCourse);
                }
            }
            aConnection.Close();
            return courseList;
        }

        public int GetCourseId(string course)
        {
            aConnection.Open();
            string query = string.Format("select * from Course_Table where CourseTitle='{0}'", course);
            SqlCommand aCommand = new SqlCommand(query, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            int courseId=0;
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    courseId =(int) aReader[0];
                }
            }
            aConnection.Close();
            return courseId;
        }

        public List<AddToListView> GetCourseList(int StudentId)
        {
            aConnection.Open();
            string query = string.Format("select * from EnrollmentScore_table where StudentId={0}", StudentId);
            SqlCommand aCommand = new SqlCommand(query, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            
            List<AddToListView>listViews=new List<AddToListView>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    AddToListView addToList = new AddToListView();
                    addToList.CourseTitle = aReader[6].ToString();
                    addToList.EnrollDate = aReader[3].ToString();
                    listViews.Add(addToList);

                }
            }
            aConnection.Close();
            return listViews;
        }

       

    }
}
