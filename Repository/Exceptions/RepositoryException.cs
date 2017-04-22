using System;

namespace Repository.Exceptions
{
    public class RepositoryException : Exception
    {
        //TODO: Log de exception

        public RepositoryException() : base() { }

        public RepositoryException(string msg) : base(msg) { }

        //public RepositoryException(Exception exception) : base(exception) { }

    }
}
