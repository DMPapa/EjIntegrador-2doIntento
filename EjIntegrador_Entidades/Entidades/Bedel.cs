using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjIntegrador_Entidades
{
    public class Bedel : Empleado
    {
        private string _apodo;

        public string Apodo
        {
            get { return this._apodo; }
            set { this._apodo = value; }
        }
        public Bedel(string apodo, string nombre, string apellido,DateTime fechanacimiento, DateTime fechaingreso, int legajo) : base(nombre, apellido, fechanacimiento, legajo, fechaingreso)
        {
            _apodo = apodo;
        }
        public override string GetNombreCompleto()
        {
            return string.Format("Bedel {0}", this._apodo);
        }
    }
}
