using log4net;
using System;
using System.Collections.Generic;
using VuelingExam.Infrastructure;
using VuelingExam.Transversal.Models;

namespace VuelingExam.BusinessLogic
{
    public class Bl : IBl
    {
        private readonly IRepo _repository;
        private readonly ILog _log;

        public Bl(IRepo repository, ILog log)
        {
            _repository = repository;
            _log = log;
        }

        public List<StudentDto> ReadData()
        {
            return _repository.ReadData();
        }
        public string WriteData(StudentDto student)
        {
            if (student == null) throw new ArgumentNullException();
            if (student.Values == null || student.Name == null || student.Surname == null) throw new ArgumentNullException();

            return _repository.WriteData(student);
        }
    }
}
