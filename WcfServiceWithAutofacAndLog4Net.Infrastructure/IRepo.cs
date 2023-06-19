using System;

namespace WcfServiceWithAutofacAndLog4Net.Infrastructure
{
    public interface IRepo
    {
        string ReadData();
        string WriteData(string data);
    }
}
