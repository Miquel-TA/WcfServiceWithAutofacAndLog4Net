using System;
using log4net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace VuelingExam.WCF.Configs
{
    public class GlobalErrorHandler : IErrorHandler
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public bool HandleError(Exception error)
        {
            log.Error(error.Message);
            log.Error(error.StackTrace);
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            var newEx = new FaultException(
                string.Format("Exception caught at Service Application GlobalErrorHandler{0}Method: {1}{2}Message: {3}",
                Environment.NewLine, error.TargetSite.Name, 
                Environment.NewLine, error.Message));

            MessageFault msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);
        }


    }
}