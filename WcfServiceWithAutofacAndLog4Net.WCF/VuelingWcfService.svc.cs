using log4net;
using System;
using VuelingExam.BusinessLogic;
using VuelingExam.WCF.Configs;
using VuelingExam.Transversal.Models;
using System.Collections.Generic;

namespace VuelingExam.WCF
{
    [GlobalErrorBehaviorAttribute(typeof(GlobalErrorHandler))]
    public class VuelingWcfService : IVuelingWcfService
    {
        private readonly ILog log;
        private readonly IBl bl;

        public VuelingWcfService(ILog log, IBl bl)
        {
            this.log = log;
            this.bl = bl;
        }

        public string WriteData(StudentDto student)
        {
            if (student == null) throw new ArgumentNullException("Student is NULL");
            if (student.Values == null || student.Name == null || student.Surname == null) throw new ArgumentNullException("One ore more of the student values is NULL.");

            return bl.WriteData(student);
        }
        public List<StudentDto> ReadData()
        {
            return bl.ReadData();
        }

    }
}
