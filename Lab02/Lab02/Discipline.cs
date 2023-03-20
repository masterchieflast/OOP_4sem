namespace Lab02
{
    [Serializable]
    public class Discipline
    {
        public string Name { get; set; }
        public string Semestor { get; set; }
        public int Course { get; set; }
        public string Specialization { get; set; }
        public int CountLecture { get; set; }
        public int CountExercise { get; set; }
        public TypeСontrol Сontrol { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
