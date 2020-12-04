using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjIntegrador_Entidades
{
    public abstract class Persona
    {
        protected string _nombre;
        protected string _apellido;
        protected DateTime _fechaNac;
        
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return this._fechaNac; }
            set { this._fechaNac = value; }
        }
        public int Edad
        {
            get { return (DateTime.Now.Year - this._fechaNac.Year); }
   
        }
        public Persona() { }
        public Persona(string nombre, string apellido, DateTime nacimiento)
        {
            _nombre = nombre;
            _apellido = apellido;
            _fechaNac = nacimiento;
        }

        public abstract string GetCredencial();

        public virtual string GetNombreCompleto()
        {
            return string.Format("Apellido y nombre: {0}, {1}", this._apellido, this._nombre);
        }
    }
}
