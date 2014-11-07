using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampStudentResultManagement.DLL.DAO;

namespace BootCampStudentResultManagement.DLL.Gateway
{
    class StudentGateway
    {
        SqlConnection aConnection=new SqlConnection();
        public StudentGateway()
        {
            string connection = @"server=BITM-301-PC00;database=BootCamp;integrated security=true";
            aConnection.ConnectionString = connection;
        }

        public bool Findstudent(int registerNo)
        {
            aConnection.Open();
            Student aStudent=new Student();
            string query = string.Format("select * from Student_Table where StudentRegisterNo={0}", registerNo);
            SqlCommand aCommand=new SqlCommand(query,aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            bool chk = aReader.HasRows;
            aConnection.Close();
            if (chk)
            {
                return true;
            }
            return false;
        }

        public Student GetStudent(int registerNo)
        {
            aConnection.Open();
            Student aStudent = new Student();
            string query = string.Format("select * from Student_Table where StudentRegisterNo={0}", registerNo);
            SqlCommand aCommand = new SqlCommand(query, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    aStudent.StudentId =(int) aReader[1];
                    aStudent.Name = aReader[2].ToString();
                    aStudent.Email = aReader[3].ToString();
                }
            }
            aConnection.Close();
            return aStudent;

        }
    }
}
