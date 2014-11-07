using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BootCampStudentResultManagement.UI;

namespace BootCampStudentResultManagement
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void enrollButton_Click(object sender, EventArgs e)
        {
             CourseEnrollUI aCourseEnrollUi=new CourseEnrollUI();
             aCourseEnrollUi.ShowDialog();
        }

        private void enterResultButton_Click(object sender, EventArgs e)
        {
            EnterResultUI aEnterResultUi=new EnterResultUI();
            aEnterResultUi.ShowDialog();

        }

        private void showresultSheetButton_Click(object sender, EventArgs e)
        {
            ShowResultSheetUI aResultSheetUi=new ShowResultSheetUI();
            aResultSheetUi.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}