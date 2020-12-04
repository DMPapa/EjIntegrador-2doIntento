using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjIntegrador_Entidades;

namespace EjIntegrador
{
    class Program
    {
        static void Main(string[] args)
        {
            Facultad f1 = new Facultad("La Dieguito Maradona", 1);

            Console.WriteLine("Bienvenido a " + f1.Nombre + " - Presione -ENTER- para continuar..");

            bool finalizar = false;
            

            do
            {
                int eleccion = ConsolaHelper.PedirNumero("\nSelecione opción: \n1 - Agregar Alumno \n" +
                    "2- Agregar Empleado \n3- Eliminar Alumno \n4- Eliminar Empleado \n5- Modificar Empleado \n" +
                    "6- Traer Alumnos \n7- Traer Empleados x legajo \n8- Traer Empleados \n" +
                    "9- Traer Empleados x nombre \n10- Agregar Salario \n11- Apagar \n");

                if (eleccion > 11)
                    throw new Exception("Eliga una opción válida");
                else
                {
                    switch (eleccion)
                    {
                        case 1:
                            Alumno al = new Alumno(f1.TraerUltimoCodigo(), ConsolaHelper.PedirTexto("Ingrese nombre"), ConsolaHelper.PedirTexto("Ingrese apellido"), ConsolaHelper.PedirFecha("Ingrese fecha de nacimiento"));
                            f1.AgregarAlumno(al);
                            Console.WriteLine("\nSe ha ingresado el alumno con éxito");
                            break;

                        case 2:
                            int tipo = ConsolaHelper.PedirNumero("Ingrese el tipo de empleado: 1-Bedel 2 -Docente 3 - Directivo");
                            switch (tipo)
                                {
                                    case 1:
                                        Bedel bedel = new Bedel(ConsolaHelper.PedirTexto("Ingrese apodo"),ConsolaHelper.PedirTexto("Ingrese nombre"), ConsolaHelper.PedirTexto("Ingrese apellido"), ConsolaHelper.PedirFecha("Ingrese fecha de nacimiento"), ConsolaHelper.PedirFecha("Ingrese fecha de ingreso"), f1.TraerUltimoLegajo());
                                        f1.AgregarEmpleado(bedel, tipo, bedel.Apodo);
                                        Console.WriteLine("\nSe ha ingresado el empleado con éxito");
                                        break;

                                    case 2:
                                        Docente docente = new Docente(ConsolaHelper.PedirTexto("Ingrese nombre"), ConsolaHelper.PedirTexto("Ingrese apellido"), ConsolaHelper.PedirFecha("Ingrese fecha de nacimiento"), f1.TraerUltimoLegajo(), ConsolaHelper.PedirFecha("Ingrese fecha de ingreso"));
                                        Console.WriteLine("\nSe ha ingresado el empleado con éxito");
                                        break;

                                    case 3:
                                        Directivo directivo = new Directivo(ConsolaHelper.PedirTexto("Ingrese nombre"), ConsolaHelper.PedirTexto("Ingrese apellido"), ConsolaHelper.PedirFecha("Ingrese fecha de nacimiento"), f1.TraerUltimoLegajo(), ConsolaHelper.PedirFecha("Ingrese fecha de ingreso"));
                                        Console.WriteLine("\nSe ha ingresado el empleado con éxito");
                                        break;
                                }
                            break;

                        case 3:
                            f1.EliminarAlumno(ConsolaHelper.PedirNumero("Ingrese código del alumno"));
                            Console.WriteLine("\nSe ha eliminado el alumno con éxito");
                            break;

                        case 4:
                            f1.EliminarEmpleado(ConsolaHelper.PedirNumero("Ingrese legajo del empleado"));
                            Console.WriteLine("\nSe ha eliminado el empleado con éxito");
                            break;

                        case 5:
                            Empleado amodificar = f1.TraerEmpleadoPorLegajo(ConsolaHelper.PedirNumero("Ingrese número de legajo"));
                            Console.WriteLine(amodificar.GetNombreCompleto());
                            f1.ModificarEmpleado(ConsolaHelper.PedirTexto("Ingrese nuevo apellido"), ConsolaHelper.PedirTexto("Ingrese nuevo nombre"), amodificar.Legajo, ConsolaHelper.PedirTexto("En caso de ser bedel ingrese apodo"));
                            Console.WriteLine("\nSe ha modificado el empleado con éxito");
                            break;

                        case 6:
                            Console.WriteLine(f1.ListarAlumnos());
                            break;

                        case 7:
                            Console.WriteLine(f1.TraerEmpleadoPorLegajo(ConsolaHelper.PedirNumero("Ingrese legajo")));
                            break;

                        case 8:
                            Console.WriteLine(f1.ListarEmpleados());
                            break;

                        case 9:
                            string listado = "";
                            foreach (Empleado emp in f1.TraerEmpleadoPorNombre(ConsolaHelper.PedirTexto("Ingrese nombre")))
                            { listado += emp.GetNombreCompleto() + "\n"; }
                            Console.WriteLine("\n" + listado);
                            break;

                        case 10:
                            Console.WriteLine(f1.ListarEmpleados());
                            f1.AgregarNuevoSalario(ConsolaHelper.PedirNumero("Ingrese el legajo del empleado a ingresar salario"), new Salario(ConsolaHelper.PedirDouble("Ingrese sueldo bruto"), ConsolaHelper.PedirTexto("Ingrese código de transferencia")));
                            Console.WriteLine("\nSe ha agregado el nuevo salario con éxito");
                            break;

                        case 11:
                            finalizar = true;
                            break;

                    }
                }
            } while (finalizar == false);
        }
    }
}
