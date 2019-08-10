using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.bp.pasic.Exceptions
{
    public class PasicInitException : Exception
    {

        public PasicInitException(string errorLocation) : base(errorLocation)
        {

        }

    }
}
