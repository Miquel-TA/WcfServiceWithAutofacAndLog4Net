using System;

namespace VuelingExam.Infrastructure
{
    public interface IFileWrapper
    {
        bool Exists(string path);
        string[] ReadAllLines(string path);
        void AppendAllText(string path, string contents);
        string ReadAllText(string path);
        void WriteAllText(string path, string contents);
    }


}
