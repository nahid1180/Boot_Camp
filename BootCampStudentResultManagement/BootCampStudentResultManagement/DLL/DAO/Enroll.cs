using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampStudentResultManagement.DLL.DAO
{
    class Enroll
    {       
        public int StudentId { get; set; }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
  
        public DateTime CourseEnrollDate { set; get; }

        public  Result aResult;


    }
}
