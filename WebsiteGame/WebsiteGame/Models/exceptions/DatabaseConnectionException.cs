using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGame.Models.exceptions
{
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException()
        {
        }

        public DatabaseConnectionException(string message): base(message)
        {

        }
    }
}