using System.Runtime.Serialization;
using Lab02;

namespace Lab03
{
    [DataContract]
    public class AllData
    {
        [DataMember]
        public List<Lecturer> Lecturers { get; set; }

        [DataMember]
        public List<Literature> Literature { get; set; }

        [DataMember]
        public List<Discipline> Discipline { get; set; }

        [DataMember]
        public Tuple<string, int, int> Filter { get; set; }
    }
}
