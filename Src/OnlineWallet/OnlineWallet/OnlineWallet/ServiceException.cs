using System;

namespace OnlineWallet
{
    public class ServiceException : Exception
    {
        public ServiceException(string message, Exception innerException = null) : base(message, innerException){}
    }
}
