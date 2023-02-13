using System.Data;
using System.Runtime.Serialization.Json;

namespace Lab02
{
    public partial class StudyDepartment : Form
    {
        private List<Lecturer>? _lecturers;
        private List<Literature>? _literature;
        private List<Discipline>? _discipline;
        public StudyDepartment()
        {
            InitializeComponent();
            _lecturers = new List<Lecturer>();
            _literature = new List<Literature>();
            _discipline = new List<Discipline>();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
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

        private void CountLecture_Scroll(object sender, EventArgs e)
        {
            try
            {
                Lecture.Text = @"Lecture: " + CountLecture.Value;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CountExercise_Scroll(object sender, EventArgs e)
        {
            try
            {
                Exercise.Text = @"Exercise: " + CountExercise.Value;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnAddLectures_Click(object sender, EventArgs e)
        {
            try
            {
                var lecturer = new Lecturer
                {
                    Department = Department.Text,
                    FullName = FullName.Text,
                    Auditorium = Auditorium.Text
                };

                _lecturers.Add(lecturer);
                lectureTable.DataSource = GetLectureData();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private DataTable GetLectureData()
        {
            try
            {
                var table = new DataTable();

                // Add columns to the DataTable
                table.Columns.Add("Department", typeof(string));
                table.Columns.Add("FullName", typeof(string));
                table.Columns.Add("Auditorium", typeof(string));

                // Add data to the DataTable
                foreach (var lecturer in _lecturers)
                {
                    table.Rows.Add(lecturer.Department, lecturer.FullName, lecturer.Auditorium);
                }

                return table;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return new DataTable();
            }
        }

        private void lectureTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_literature.Count == 0)
                    return;

                var row = lectureTable.Rows[e.RowIndex];

                var table = new DataTable();

                // Add columns to the DataTable
                table.Columns.Add("Title", typeof(string));
                table.Columns.Add("Author", typeof(string));
                table.Columns.Add("Year", typeof(string));

                // Add data to the DataTable
                foreach (var lecturer in _literature.Where(lecturer => lecturer.Author == row.Cells[0].Value.ToString()))
                {
                    table.Rows.Add(lecturer.Author, lecturer.Title, lecturer.Year);
                }

                literatureTable.DataSource = table;

                var dataTable = new DataTable();
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("Semestor", typeof(string));
                dataTable.Columns.Add("Course", typeof(int));
                dataTable.Columns.Add("Specialization", typeof(string));
                dataTable.Columns.Add("CountLecture", typeof(int));
                dataTable.Columns.Add("CountExercise", typeof(int));
                dataTable.Columns.Add("Control", typeof(TypeСontrol));
                dataTable.Columns.Add("Lecturer", typeof(Lecturer));

                foreach (var discipline in _discipline.Where(discipline => discipline.Lecturer.FullName == row.Cells[0].Value.ToString()))
                {
                    dataTable.Rows.Add(discipline.Name, discipline.Semestor, discipline.Course, discipline.Specialization, discipline.CountLecture, discipline.CountExercise, discipline.Сontrol, discipline.Lecturer);
                }

                disciplineTable.DataSource = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnAddLiterature_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new Literature
                {
                    Title = Title.Text,
                    Author = Author.Text,
                    Year = Year.SelectionStart
                };

                _literature.Add(item);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void addDiscipline_Click(object sender, EventArgs e)
        {
            try
            {
                var semester = sem1.Checked ? "1" : "2";
                var control = Exam.Checked ? TypeСontrol.Exam : TypeСontrol.Credit;

                var item = new Discipline
                {
                    Name = DisciplineName.Text,
                    Semestor = semester,
                    Course = CourseBar.Value,
                    Specialization = Specialization.Text,
                    CountLecture = CountLecture.Value,
                    CountExercise = CountExercise.Value,
                    Сontrol = control,
                    Lecturer = _lecturers[lectureTable.CurrentCell.RowIndex]
                };

                _discipline.Add(item);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void download_Click(object sender, EventArgs e)
        {
            try
            {
                var jsonFormattedLiterature = new DataContractJsonSerializer(typeof(List<Literature>));
                using (var file = new FileStream("Literature.json", FileMode.OpenOrCreate))
                {
                    _literature = (List<Literature>)jsonFormattedLiterature.ReadObject(file)!;
                }

                var jsonFormattedLecturer = new DataContractJsonSerializer(typeof(List<Lecturer>));
                using (var file = new FileStream("Lecturer.json", FileMode.OpenOrCreate))
                {
                    _lecturers = (List<Lecturer>)jsonFormattedLecturer.ReadObject(file)!;
                }

                var jsonFormattedDiscipline = new DataContractJsonSerializer(typeof(List<Discipline>));
                using (var file = new FileStream("Discipline.json", FileMode.OpenOrCreate))
                {
                    _discipline = (List<Discipline>)jsonFormattedDiscipline.ReadObject(file)!;
                }

                lectureTable.DataSource = GetLectureData();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void upload_Click(object sender, EventArgs e)
        {
            try
            {
                var jsonFormattedLiterature = new DataContractJsonSerializer(typeof(List<Literature>));
                using (var file = new FileStream("Literature.json", FileMode.OpenOrCreate))
                {
                    jsonFormattedLiterature.WriteObject(file, _literature);
                }

                var jsonFormattedLecturer = new DataContractJsonSerializer(typeof(List<Lecturer>));
                using (var file = new FileStream("Lecturer.json", FileMode.OpenOrCreate))
                {
                    jsonFormattedLecturer.WriteObject(file, _lecturers);
                }

                var jsonFormattedDiscipline = new DataContractJsonSerializer(typeof(List<Discipline>));
                using (var file = new FileStream("Discipline.json", FileMode.OpenOrCreate))
                {
                    jsonFormattedDiscipline.WriteObject(file, _discipline);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
