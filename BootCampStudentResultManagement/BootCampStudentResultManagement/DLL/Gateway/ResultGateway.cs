using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using BootCampStudentResultManagement.DLL.DAO;

namespace BootCampStudentResultManagement.DLL.Gateway
{
    class ResultGateway
    {
        SqlConnection aConnection=new SqlConnection();
        public ResultGateway()
        {
            string connection = @"server=BITM-301-PC00;database=BootCamp;integrated security=true";
            aConnection.ConnectionString = connection;
        }

        public List<Enroll> GetAllCourseAndScore(int studentid)
        {
            aConnection.Open();
            List<Enroll>enrollList=new List<Enroll>();
            string query = string.Format("select*from EnrollmentScore_table where StudentId={0}", studentid);
            
            SqlCommand aCommand=new SqlCommand(query,aConnection);
            SqlDataReader aDataReader = aCommand.ExecuteReader();
            if (aDataReader.HasRows)
            {
                while (aDataReader.Read())
                {
                    {
                        Enroll aEnroll=new Enroll();
                        Result aResult = new Result();
                        aEnroll.aResult = aResult;
                        aEnroll.CourseId =(int) aDataReader[2];
                        aEnroll.aResult.Score =(double) aDataReader[4];
                        enrollList.Add(aEnroll);
                        
                    }
                }
                
                
            }
            aConnection.Close(); 
            return enrollList;
        }
    }
}
