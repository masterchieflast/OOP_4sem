using System.ComponentModel.DataAnnotations;

namespace Lab02
{
    [Serializable]
    public class Discipline
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Semester is required")]
        [RegularExpression(@"^[1-9]$|^1[0-9]$|^2[0]$",
            ErrorMessage = "Semester must be a number between 1 and 20")]
        public string Semestor { get; set; }

        [Required(ErrorMessage = "Course is required")]
        [Range(1, 6, ErrorMessage = "Course must be a number between {1} and {2}")]
        public int Course { get; set; }
        
        public string Specialization { get; set; }

        [Range(0, 100, ErrorMessage = "CountLecture must be a number between {1} and {2}")]
        public int CountLecture { get; set; }

        [Range(0, 100, ErrorMessage = "CountExercise must be a number between {1} and {2}")]
        public int CountExercise { get; set; }

        [Required(ErrorMessage = "Control type is required")]
        public TypeСontrol Сontrol { get; set; }

        [Required(ErrorMessage = "Lecturer is required")]
        public Lecturer Lecturer { get; set; }
    }
}
