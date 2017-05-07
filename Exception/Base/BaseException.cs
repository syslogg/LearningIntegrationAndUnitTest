using Infrastructure.Log;
using System;

namespace Exceptions.Base
{
    public class BaseException : System.Exception
    {

        private IBKLog _bkLog;

        public BaseException() : base()
        {
            _bkLog = BKLog.GetInstance;
            _bkLog.LogException(this);
        }

        public BaseException(string message) : base(message)
        {
            _bkLog = BKLog.GetInstance;
            _bkLog.LogMessage(message);
        }

        public BaseException(string message, System.Exception innerException) : base(message,innerException)
        {
            _bkLog = BKLog.GetInstance;
            _bkLog.LogMessage(message);
            _bkLog.LogException(innerException);
        }

        public BaseException(System.Exception exception) : base(exception.Message)
        {
            _bkLog = BKLog.GetInstance;
            _bkLog.LogException(exception);
        }

    }
}
