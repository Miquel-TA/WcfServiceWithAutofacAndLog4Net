using System;
using System.Collections.Generic;
using VuelingExam.Transversal.Models;

namespace VuelingExam.BusinessLogic
{
    public interface IBl
    {
        List<StudentDto> ReadData();
        string WriteData(StudentDto student);
    }
}
