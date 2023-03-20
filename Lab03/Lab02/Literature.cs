using System.ComponentModel.DataAnnotations;

namespace Lab03
{
    [Serializable]
    public class Literature
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public DateTime Year { get; set; }
    }
}
