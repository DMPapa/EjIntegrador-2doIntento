using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjIntegrador_Entidades
{
    public class Alumno : Persona
    {
        private int _codigo;

        public int Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }

        public Alumno(int codigo, string nom, string ape, DateTime nac) : base (nom, ape, nac)
        {
            this._codigo = codigo;   
        }

        public override string GetCredencial()
        {
            return string.Format("Codigo: {0} - Apellido y nombre: {1} {2}", this._codigo, this.Apellido, this.Nombre);
        }
        public override string ToString()
        {
            return GetCredencial();
        }
    }
}
