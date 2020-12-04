using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjIntegrador_Entidades
{
    class PersonaExisteException : Exception
    {
        public PersonaExisteException(string message) : base(message)
        {
        }

    }
}
