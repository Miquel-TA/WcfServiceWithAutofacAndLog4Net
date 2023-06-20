using System.IO;
using System;
using VuelingExam.Infrastructure;
using VuelingExam.Transversal.Models;
using System.Text.Json;
using System.Collections.Generic;


namespace VuelingExam.Infrastructure
{
    public class Repo : IRepo
    {
        private readonly IFileWrapper _fileWrapper;

        public Repo(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
        }

        public List<StudentDto> ReadData()
        {
            var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(myDocuments + Path.DirectorySeparatorChar + "output.txt");
            var json = _fileWrapper.ReadAllText(path);

            return JsonSerializer.Deserialize<List<StudentDto>>(json);
        }

        public string WriteData(StudentDto student)
        {
            if (student == null) throw new ArgumentNullException("Student is NULL");
            if (student.Values == null || student.Name == null || student.Surname == null) throw new ArgumentNullException("One ore more of the student values is NULL.");

            var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(myDocuments + Path.DirectorySeparatorChar + "output.txt");

            var json = _fileWrapper.Exists(path) ? _fileWrapper.ReadAllText(path) : "";
            var students = json != "" ? JsonSerializer.Deserialize<List<StudentDto>>(json) : new List<StudentDto>();

            students.Add(student);

            json = JsonSerializer.Serialize(students);
            _fileWrapper.WriteAllText(path, json);

            return "Ok!";
        }
    }

}
