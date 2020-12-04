using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjIntegrador_Entidades
{
    public abstract class Empleado : Persona
    {
        private int _legajo;
        private DateTime _fechaIngreso;
        private List<Salario> _salarios;

        public int Antiguedad
        {
            get { return (DateTime.Today.Year - this._fechaIngreso.Year); }

        }
        public DateTime FechaIngreso
        {
            get { return this._fechaIngreso; }
            set { this._fechaIngreso = value; }
        }
        public int Legajo
        {
            get { return this._legajo; }
            set { this._legajo = value; }
        }
        public List<Salario> Salarios
        {
            get { return this._salarios; }
            set { this._salarios = value; }
        }
        public Empleado(string nombre, string apellido, DateTime nacimiento, int legajo, DateTime fingreso ) : base (nombre, apellido, nacimiento)
        {
            this._legajo = legajo;
            this._fechaIngreso = fingreso;
            _salarios = new List<Salario>();
        }
        public override string GetCredencial()
        {
            return string.Format("Apellido: {0} - Nombre: {1}", this.Apellido, this.Nombre);
        }
        public override string ToString()
        {
            return GetCredencial();
        }
        public override string GetNombreCompleto()
        {
            return base.GetNombreCompleto();
        }
        public void AgregarSalario(Salario salario)
        {
            _salarios.Add(salario);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }

            if (!(obj is Empleado))
            { return false; }

            return (this.Legajo == ((Empleado)obj).Legajo);
        }

    }
}
