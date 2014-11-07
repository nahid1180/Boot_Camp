using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BootCampStudentResultManagement.DLL.DAO;

namespace BootCampStudentResultManagement.DLL.Gateway
{
    class EnrollmentGateWay
    {
         SqlConnection aConnection=new SqlConnection();
        public EnrollmentGateWay()
        {
            var connection = @"server=BITM-301-PC00;database=BootCamp;integrated security=true";
            aConnection.ConnectionString = connection;
        }

        public bool CheckCourseAlreadyExist(int courseId,int studentId)
        {
            aConnection.Open();
            var query = string.Format("select * from EnrollmentScore_table where StudentId={0} and CourseId={1} ",studentId, courseId);
            var aCommand = new SqlCommand(query, aConnection);
            var aReader = aCommand.ExecuteReader();
            var chk=aReader.HasRows;
            aConnection.Close();
            if (chk)
            {
                    return true;
            }
            
            return false;
        }

        public bool EnrolledStudentCourse(Enroll aEnroll)
        {
            aConnection.Open();
            string query = string.Format("insert into EnrollmentScore_table  (StudentId,CourseId,CourseEnrollDate,CourseTitle) Values({0},{1},'{2}','{3}')", aEnroll.StudentId, aEnroll.CourseId, aEnroll.CourseEnrollDate,aEnroll.CourseTitle);

            SqlCommand aCommand = new SqlCommand(query, aConnection);
            int chk = aCommand.ExecuteNonQuery();
            aConnection.Close();
            if (chk > 0)
            {
                return true;

            }
            return false;
        }
       
        public bool EnrolledStudentScore(Enroll aEnroll)
        {
            aConnection.Open();

            
            var query = string.Format("UPDATE EnrollmentScore_table SET Score={0},ScoreEnrollmentdate='{1}' WHERE StudentId={2} and CourseId={3}", aEnroll.aResult.Score, aEnroll.aResult.Date, aEnroll.StudentId, aEnroll.CourseId);
            var aCommand = new SqlCommand(query, aConnection);
            var chk = aCommand.ExecuteNonQuery();
            
            aConnection.Close();
            if (chk > 0)
            {
                return true;
            }  
            return false;
        }
        public List<int> GetAllCourseId(int studentId)
        {
            aConnection.Open();
            var query = string.Format("select * from EnrollmentScore_table where StudentId={0}", studentId);
            var aCommand = new SqlCommand(query, aConnection);
            var aReader = aCommand.ExecuteReader();
            var courseIdList=new List<int>();
            int courseId;
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    courseId =(int) aReader[2];
                    courseIdList.Add(courseId);
                }
            }
            aConnection.Close();
            return courseIdList;
        }

        public List<ShowResultSheetView> GetShowResultSheetView(int studentId)
        {
            aConnection.Open();
            var query = string.Format("select * from EnrollmentScore_table where StudentId={0}", studentId);
            var aCommand = new SqlCommand(query, aConnection);
            var aReader = aCommand.ExecuteReader();

            List<ShowResultSheetView> showResultSheetViews= new List<ShowResultSheetView>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    ShowResultSheetView aShowResultSheetView= new ShowResultSheetView();
                    aShowResultSheetView.CourseCode = (int) aReader[2];
                    aShowResultSheetView.CourseTitle = aReader[6].ToString();
                    aShowResultSheetView.Score = (double) aReader[4];
                    showResultSheetViews.Add(aShowResultSheetView);


                }
            }
            aConnection.Close();
            return showResultSheetViews;
        }

    }
}
