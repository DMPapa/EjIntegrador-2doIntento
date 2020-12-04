using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjIntegrador_Entidades
{
    public class Directivo : Empleado
    {
        public Directivo(string nombre, string apellido, DateTime nacimiento, int legajo, DateTime ingreso ) : base (nombre, apellido, nacimiento, legajo, ingreso) { }

        public override string GetNombreCompleto()
        {
            return string.Format("Sr Director {0}", this.Apellido);
        }
    }
}
