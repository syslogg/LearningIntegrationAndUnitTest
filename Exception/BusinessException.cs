using Exceptions.Base;

namespace Exception
{
    public class BusinessException : BaseException
    {
        public BusinessException() : base()
        {

        }

        public BusinessException(string message) : base(message) 
        {

        }

        public BusinessException(System.Exception ex) : base(ex)
        {

        }

        public BusinessException(string message, System.Exception innerException) : base(message, innerException)
        {

        }
    }
}
