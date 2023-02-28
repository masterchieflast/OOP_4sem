using Lab02;
using Microsoft.VisualBasic.Devices;

namespace Lab03
{
    public partial class Search : Form
    {
        public event search? OnSearch;
        public Search()
        {
            InitializeComponent();
        }
        
        private void Filter_Click(object sender, EventArgs e)
        {
            var lecturer = LectureName.Text;
            var semester = 0;
            if (sem1.Checked)
            {
                semester = 1;
            }
            if (sem2.Checked)
            {
                semester += 20;
            }

            OnSearch?.Invoke(lecturer, semester, CourseBar.Value);
        }

        private void CourseBar_Scroll(object sender, EventArgs e)
        {
            try
            {
                Course.Text = @"Course: " + CourseBar.Value;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
