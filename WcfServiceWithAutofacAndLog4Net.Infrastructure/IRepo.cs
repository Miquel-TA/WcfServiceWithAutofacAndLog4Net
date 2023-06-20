using System;
using System.Collections.Generic;
using VuelingExam.Transversal.Models;

namespace VuelingExam.Infrastructure
{
    public interface IRepo
    {
        List<StudentDto> ReadData();
        string WriteData(StudentDto data);
    }
}
