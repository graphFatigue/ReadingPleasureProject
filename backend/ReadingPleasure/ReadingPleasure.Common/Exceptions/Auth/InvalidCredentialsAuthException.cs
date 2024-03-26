using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPleasure.Common.Exceptions.Auth
{
    public class InvalidCredentialsAuthException : Exception
    {
        public InvalidCredentialsAuthException() : base("Invalid email or password")
        {
        }
    }
}
