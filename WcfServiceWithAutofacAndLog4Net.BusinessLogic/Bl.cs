using log4net;
using System;
using WcfServiceWithAutofacAndLog4Net.Infrastructure;

namespace WcfServiceWithAutofacAndLog4Net.BusinessLogic
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

        public string ReadData()
        {
            return _repository.ReadData();
        }
        public string WriteData(string text)
        {
            return _repository.WriteData(text);
        }
    }
}
