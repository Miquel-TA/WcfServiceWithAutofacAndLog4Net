using System;
using System.IO;
using System.Text;

namespace WcfServiceWithAutofacAndLog4Net.Infrastructure
{
    public class Repo : IRepo
    {
        public string ReadData()
        {
            try
            {
                var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var path = Path.Combine(myDocuments + "output.txt");
                var lines = File.ReadAllLines(path);

                StringBuilder sb = new StringBuilder();
                foreach (var line in lines)
                {
                    sb.AppendLine(line + ", ");
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public string WriteData(string text)
        {
            try
            {
                var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                File.AppendAllText(myDocuments + "output.txt", text + Environment.NewLine);
                return "Ok!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

    }
}
