using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampStudentResultManagement.DLL.DAO;
using BootCampStudentResultManagement.DLL.Gateway;

namespace BootCampStudentResultManagement.BLL
{
    class ResultBLL
    {
        public int GetCourseId(string course)
        {
            CourseGateway aCourseGateway=new CourseGateway();
            int CourseId = aCourseGateway.GetCourseId(course);
            return CourseId;
        }

        public string SetScoreOnDatabase(Enroll aEnroll)
        {
            EnrollmentGateWay aEnrollmentGateWay=new EnrollmentGateWay();
            string msg="";
            if (aEnrollmentGateWay.CheckCourseAlreadyExist(aEnroll.CourseId, aEnroll.StudentId))
            {
                if (aEnrollmentGateWay.EnrolledStudentScore(aEnroll))
                {
                    msg= "Score Enrolled";
                }
                else
                {
                     msg = "This course Already exist";
                }
                
            }
            else
            {
                msg = "This Student Do not take This course";
            }
            return msg;
        }

       
    }
}
