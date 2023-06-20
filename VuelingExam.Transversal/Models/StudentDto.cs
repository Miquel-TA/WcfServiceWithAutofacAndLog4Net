using System;
using System.Runtime.Serialization;

namespace VuelingExam.Transversal.Models
{
    [DataContract]
    public class StudentDto
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public int[] Values { get; set; }

        public StudentDto(string name, string surname, int[] values)
        {
            Name = name;
            Surname = surname;
            Values = values;
        }
    }
}