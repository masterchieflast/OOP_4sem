using System.ComponentModel.DataAnnotations;

namespace Lab02
{
    [Serializable]
    public class Lecturer
    {
        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Full name must be between {2} and {1} characters")]
        public string FullName { get; set; }

        public string Auditorium { get; set; }
    }
}
