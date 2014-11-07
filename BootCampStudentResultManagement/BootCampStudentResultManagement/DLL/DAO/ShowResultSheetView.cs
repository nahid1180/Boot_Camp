using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BootCampStudentResultManagement.DLL.DAO
{
    public class ShowResultSheetView
    {
        public int CourseCode { set; get; }
        public string CourseTitle { set; get; }
        public double Score { set; get; }
        public string GradeLetter { set; get; }

    }
}
