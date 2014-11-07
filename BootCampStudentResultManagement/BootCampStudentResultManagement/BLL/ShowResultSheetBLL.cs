using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BootCampStudentResultManagement.DLL.DAO;
using BootCampStudentResultManagement.DLL.Gateway;
using BootCampStudentResultManagement.UI;

namespace BootCampStudentResultManagement.BLL
{
    class ShowResultSheetBLL
    {
       ResultGateway aResultGateway=new ResultGateway();
        public double GetAverageScore(int studentid)
        {
            Enroll aEnroll=new Enroll();
            double averageScore=0;
            List<Enroll>enrollList=new List<Enroll>(); 
            enrollList= aResultGateway.GetAllCourseAndScore(studentid);
            foreach (var enroll in enrollList)
            {
                averageScore += enroll.aResult.Score;
            }
            return averageScore/enrollList.Count;
        }

        public string GetAverageGradeLetter(double averageScore)
        {
           // string gradeLetter;
            if (averageScore >= 90)
            {
                return "A";
            }
            else if(averageScore>=70&&averageScore<90)
            {
                return "B";
            }
            else if (averageScore>=50&&averageScore<70)
            {
                return "C";
            }
            return "F";
        }

        public List<ShowResultSheetView> GetAllResultInformation(int studentId)
        {

            List<ShowResultSheetView>aResultSheetViews=new List<ShowResultSheetView>();
            EnrollmentGateWay aEnrollmentGateWay=new EnrollmentGateWay();
            aResultSheetViews = aEnrollmentGateWay.GetShowResultSheetView(studentId);
            foreach (var aresult in aResultSheetViews)
            {
                if (aresult.Score >= 90)
                {
                    aresult.GradeLetter = "A";
                }
                else if (aresult.Score >= 70 && aresult.Score < 90)
                {
                    aresult.GradeLetter = "B";
                }
                else if (aresult.Score >= 50 && aresult.Score <= 70)
                {
                    aresult.GradeLetter = "C";
                }
                else if (aresult.Score < 50)
                {
                    aresult.GradeLetter = "F";
                }
                else
                {
                    aresult.GradeLetter = "this student dont get score";
                }
            }
            return aResultSheetViews;
        }
       
    }
}
