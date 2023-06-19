using System;

namespace WcfServiceWithAutofacAndLog4Net.BusinessLogic
{
    public interface IBl
    {
        string ReadData();
        string WriteData(string data);
    }
}
