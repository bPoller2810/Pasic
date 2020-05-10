using System;
using System.Collections.Generic;
using System.Text;

namespace PasicCompiler.InputParameter.Exceptions
{
    internal class InputParserException : Exception
    {

        public InputParserException(string message, Exception inner) : base(message, inner)
        {

        }

    }
}
