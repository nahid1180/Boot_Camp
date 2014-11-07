using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampStudentResultManagement.DLL.DAO
{
    class Result
    {
        public double Score { get; set; }
        public DateTime Date{ get; set; }

        public Result()
        {
            
        }

        public Result(double score, DateTime date)
        {
            Score = score;
            Date = date;
        }
    }
}
