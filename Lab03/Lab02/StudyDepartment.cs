using Lab02;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization.Json;

namespace Lab03
{
    public delegate void search(string lecture, int semester, int course);

    public partial class StudyDepartment : Form
    {
        private List<Lecturer>? _lecturers;
        private List<Literature>? _literature;
        private List<Discipline>? _discipline;
        private List<Lecturer>? _allLecturers;
        private List<Literature>? _allLiterature;
        private List<Discipline>? _allDiscipline;
        private Search _search;
        private Tuple<string, int, int> _filter;
        private bool _initializeAllRecords;
        private bool _isAscendingControl = true;
        private bool _isAscendingControlColumn = true;
        public StudyDepartment()
        {
            InitializeComponent();
            _lecturers = new List<Lecturer>();
            _literature = new List<Literature>();
            _discipline = new List<Discipline>();
            _search = new Search();
            _search.OnSearch += Search;
            _initializeAllRecords = false;
            _filter = new Tuple<string, int, int>("", 0, 0);
            UpdateStatus("Launch");
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

                // Validate the lecturer object
                var validationContext = new ValidationContext(lecturer, null, null);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(lecturer, validationContext, validationResults, true))
                {
                    // If the object is not valid, show the error message
                    var errorMessage = "";
                    foreach (var validationResult in validationResults)
                    {
                        errorMessage += validationResult.ErrorMessage + "\n";
                    }
                    throw new Exception(errorMessage);
                }

                _lecturers.Add(lecturer);
                lectureTable.DataSource = GetLectureData();
                UpdateStatus("Add lecture");
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
                dataTable.Columns.Add("Сontrol", typeof(string));
                dataTable.Columns.Add("Lecturer", typeof(Lecturer));
                
                foreach (var discipline in _discipline.Where(discipline => discipline.Lecturer.FullName == row.Cells[0].Value.ToString()))
                {
                    dataTable.Rows.Add(discipline.Name, discipline.Semestor, discipline.Course, discipline.Specialization, discipline.CountLecture, discipline.CountExercise, discipline.Сontrol.ToString(), discipline.Lecturer);
                }

                disciplineTable.DataSource = dataTable;
                UpdateStatus("Lecture select");
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

                var validationContext = new ValidationContext(item, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                if (Validator.TryValidateObject(item, validationContext, validationResults, validateAllProperties: true))
                {
                    _literature.Add(item);
                    UpdateStatus("Add literature");
                }
                else
                {
                    var errorMessage = string.Join(Environment.NewLine, validationResults.Select(r => r.ErrorMessage));
                    MessageBox.Show(errorMessage);
                }
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


                var attribute = new CustomValidationAttribute();
                var specialization = Specialization.Text;
                if (!CustomValidationAttribute.IsValid(specialization))
                {
                    throw new Exception("Specialization must be one of the following: ISiT, POIT, DIS, POIBM");
                }

                var validationContext = new ValidationContext(item, null, null);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(item, validationContext, validationResults, true))
                {
                    var errorMessage = string.Join(Environment.NewLine, validationResults.Select(r => r.ErrorMessage));
                    throw new Exception(errorMessage);
                }

                _discipline.Add(item);
                UpdateStatus("Add discipline");
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

                RefreshRecords();
                UpdateStatus("Download");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void RefreshRecords()
        {
            lectureTable.DataSource = GetLectureData();
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

                UpdateStatus("Upload");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Specialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatus("Select Specialization");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var version = Application.ProductVersion;
            const string developer = "Drugakov Denis Dmitrievich";

            var message = $"Version: {version}\nDeveloper: {developer}";

            MessageBox.Show(message, "About My Program");
            UpdateStatus("Open about");
        }

        [STAThread]
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_search.IsDisposed)
            {
                _search = new Search();
                _search.OnSearch += Search;
            }

            if (!_search.Visible)
            {
                _search.Show();
            }
            else
            {
                _search.BringToFront();
            }

            UpdateStatus("Open search panel");
        }

        private void Search(string lecture, int semester, int course)
        {
            _filter = new Tuple<string, int, int>(lecture, semester, course);
            FilterReccords();
        }

        private void FilterReccords()
        {
            if (_initializeAllRecords == false)
            {
                _allLecturers = _lecturers;
                _allDiscipline = _discipline;
                _allLiterature = _literature;
                _initializeAllRecords = true;
            }
            
            _lecturers = _allLecturers.Where(lecturer => lecturer.FullName.Contains(_filter.Item1)).ToList();
            _discipline = _allDiscipline.Where(discipline => (_filter.Item2.ToString().Contains(discipline.Semestor.ToString()) || _filter.Item2 == 0) && _filter.Item3.ToString().Contains(discipline.Course.ToString())).ToList();
            _literature = _allLiterature.Where(literature => literature.Author.Contains(_filter.Item1)).ToList();

            RefreshRecords();
            UpdateStatus("filter");
        }

        private void lectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var columnName = "countLectureDataGridViewTextBoxColumn";
            if (_isAscendingControlColumn)
            {
                disciplineTable.Sort(disciplineTable.Columns[columnName], ListSortDirection.Ascending);
                _isAscendingControlColumn = false;
            }
            else
            {
                disciplineTable.Sort(disciplineTable.Columns[columnName], ListSortDirection.Descending);
                _isAscendingControlColumn = true;
            }

            UpdateStatus("sort control");
        }

        private void typeOfControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var columnName = "Сontrol";
            if (_isAscendingControl)
            {
                disciplineTable.Sort(disciplineTable.Columns[columnName], ListSortDirection.Ascending);
                _isAscendingControl = false;
            }
            else
            {
                disciplineTable.Sort(disciplineTable.Columns[columnName], ListSortDirection.Descending);
                _isAscendingControl = true;
            }

            UpdateStatus("sort control");
        }

        private void UpdateStatus(string message)
        {
            statusLabel.Text = message;

            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            
            var objectCount = Math.Max(lectureTable.Rows.Count + literatureTable.Rows.Count + disciplineTable.Rows.Count - 3, 0);
            toolStripStatusLabelObjectCount.Text = $"Object count: {objectCount}";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var allData = new AllData
                {
                    Lecturers = _lecturers,
                    Literature = _literature,
                    Discipline = _discipline,
                    Filter = _filter
                };

                var serializer = new DataContractJsonSerializer(typeof(AllData));
                using (var stream = new FileStream("alldata.json", FileMode.Create))
                {
                    serializer.WriteObject(stream, allData);
                }

                UpdateStatus("load filtered records");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ViewToolStrip_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = !menuStrip1.Visible;

            UpdateStatus("Show/Hide menu");
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allDiscipline = new List<Discipline>();
            _allLecturers = new List<Lecturer>();
            _allLiterature = new List<Literature>();
            _discipline = new List<Discipline>();
            _lecturers = new List<Lecturer>();
            _literature = new List<Literature>();
            RefreshRecords();
            disciplineTable.DataSource = new DataTable();
            literatureTable.DataSource = new DataTable();

            UpdateStatus("Clear all records");
        }
    }
}
