using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampStudentResultManagement.DLL.DAO;
using BootCampStudentResultManagement.DLL.Gateway;

namespace BootCampStudentResultManagement.BLL
{
    class CourseEnrollBLL
    {
        StudentGateway aStudentGateway=new StudentGateway();
        CourseGateway aCourseGateway=new CourseGateway();
        Student aStudent=new Student();
        EnrollmentGateWay aEnrollmentGateWay = new EnrollmentGateWay();
        List<Course> courselList = new List<Course>();
        public Student FindStudentOnDatabase(int registerNo)
        {
     
            if (!aStudentGateway.Findstudent(registerNo))
            {
                aStudent.Email = "";
                aStudent.Name = "";
            }
            else
            {
               aStudent= aStudentGateway.GetStudent(registerNo);

            }

            return aStudent;
        }

        public List<Course> AddToCombobox()
        {
            return aCourseGateway.GetAllCourseList();
        }

        public string EnrollStudentCourse(Enroll aEnroll,string course)
        {
            int courseId = aCourseGateway.GetCourseId(course);
            string msg="";

            if (!CheckCousreAlreadyExist(courseId, aEnroll.StudentId))
            {
                aEnroll.CourseId = courseId;
                if (aEnrollmentGateWay.EnrolledStudentCourse(aEnroll))
                {
                    msg = "Enrolled Course Sucess";
                }
                else
                {
                    msg = "Enrolled Failed Database Problem";
                }

            }
            else
            {
                msg = "Course Already Exist";
            }
            return msg;
        }
        public bool CheckCousreAlreadyExist(int courseId,int studentId)
        {

            
            if (aEnrollmentGateWay.CheckCourseAlreadyExist(courseId,studentId))
            {
                return true;
            }
            return false;
            
        }
      
    }
}
