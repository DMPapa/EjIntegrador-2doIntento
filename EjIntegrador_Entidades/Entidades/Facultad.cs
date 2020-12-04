using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjIntegrador_Entidades;

namespace EjIntegrador_Entidades
{
    public class Facultad
    {
        private List<Alumno> _alumnos;
        private List<Empleado> _empleados;
        private int _cantidadSedes;
        private string _nombre;
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
        }
        public List<Empleado> Empleados
        {
            get { return this._empleados; }
        }

        public int CantidadSedes
        {
            get { return this._cantidadSedes; }
            set { this._cantidadSedes = value; }
        }
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; } 
        }
        public Facultad(string nombre, int cantidadsedes)
        {
            _nombre = nombre;
            _cantidadSedes = cantidadsedes;
            this._empleados = new List<Empleado>();
            this._alumnos = new List<Alumno>();
        }

        public void AgregarAlumno(Alumno alumno)
        {
            if (this._alumnos.SingleOrDefault(x => x.Codigo == alumno.Codigo) != null)
                throw new PersonaExisteException("El alumno ya existe");

            if (alumno.Edad < 18)
                throw new Exception("El alumno no puede ser menor a 18");

            this._alumnos.Add(alumno);
        }
        public void AgregarAlumno (string nombre, string apellido, int codigo, DateTime nacimiento)
        {
            Alumno al = new Alumno(codigo, nombre, apellido, nacimiento);

            this._alumnos.Add(al);
        }
        public void AgregarEmpleado(Empleado emp, int tipo, string apodo)
        {
            Empleado empleado;


            switch (tipo)
            {
                case 1:
                    empleado = new Bedel(apodo, emp.Nombre, emp.Apellido, emp.FechaNacimiento, emp.FechaIngreso, emp.Legajo);
                    break;

                case 2:
                    empleado = new Docente(emp.Nombre, emp.Apellido, emp.FechaNacimiento, emp.Legajo, emp.FechaIngreso);
                    break;

                case 3:
                    empleado = new Directivo(emp.Nombre, emp.Apellido, emp.FechaNacimiento, emp.Legajo, emp.FechaIngreso);
                    break;
                default:
                    throw new Exception("Tipo inválido.");
            }


            if (this._empleados.SingleOrDefault(x => x.Legajo == empleado.Legajo) != null)
                throw new PersonaExisteException("el empleado ya existe");

            _empleados.Add(empleado);
        }

        public void IngresarSalario(int legajo, Salario salario)
        {
            foreach (Empleado emp in this._empleados)
            {
                if (emp.Legajo == legajo)
                    emp.AgregarSalario(salario);
            }
        }

        public void EliminarAlumno(int c)
        {
            Alumno alumno = this._alumnos.SingleOrDefault(x => x.Codigo == c);

            if (alumno != null)
            {
                this._alumnos.Remove(alumno);
            }
            else
            {
                throw new PersonaNoExisteException("El alumno no está registrado en esta facultad.");
            }
        }

        public void EliminarEmpleado(int l)
        {
            Empleado emp = this._empleados.SingleOrDefault(x => x.Legajo == l);

            if (emp != null)
            {
                this._empleados.Remove(emp);
            }
            else
            {
                throw new PersonaNoExisteException("El empleado no está registrado en esta facultad.");
            }
        }

        public void ModificarEmpleado(string apellido, string nombre, int legajo, string apodo)
        {
            if (this._empleados.SingleOrDefault(x => x.Legajo == legajo) == null)
                throw new Exception("El empleado no existe");
            else
            {
                foreach (Empleado emp in _empleados)
                {
                    if(emp.Legajo == legajo)
                    {
                        emp.Apellido = apellido;
                        emp.Nombre = nombre;
                        if (emp is Bedel)
                            ((Bedel)emp).Apodo = apodo;
                    }
                }
            }

        }

        public Empleado TraerEmpleadoPorLegajo(int l)
        {
            Empleado empleado = null;

            foreach (Empleado emp in _empleados)
            {
            if (emp.Legajo == l)
                empleado = emp;
            }
            return empleado;

        }

        public List<Empleado> TraerEmpleadoPorNombre(string nombre)
        {

            List<Empleado> empleados = new List<Empleado>();
            foreach (Empleado emp in _empleados)
            {
                if (emp.GetCredencial().ToUpper().Contains(nombre.ToUpper()))
                    empleados.Add(emp);
            }
            return empleados;
        }

        public int TraerUltimoLegajo()
        {
            if (_empleados.Count > 0)
                return _empleados.Max(x => x.Legajo) + 1;
            else
                return 1;

        }
        public int TraerUltimoCodigo()
        {
            if (_alumnos.Count > 0)
                return _alumnos.Max(x => x.Codigo) + 1;
            else
                return 1;
        }
        public string ListarEmpleados()
        {
            string listado = "";
            foreach (Empleado emp in _empleados)
            {
                listado += emp.ToString() + "\n";
            }
            return listado;
        }
        public string ListarAlumnos()
        {
            string listado = "";
            foreach (Alumno al in _alumnos)
            {
                listado += al.ToString() + "\n";
            }
            return listado;
        }
        public void AgregarNuevoSalario(int l, Salario salario)
        {
            if (salario.Bruto < 0)
                throw new Exception("El salario no puede ser negativo");
            else
            {
                try
                {
                    Empleado emp = (this._empleados.SingleOrDefault(x => x.Legajo == l));
                    emp.AgregarSalario(salario);
                } catch { throw new Exception("Error al cargar el salario"); }

            }
        }
    }
}
