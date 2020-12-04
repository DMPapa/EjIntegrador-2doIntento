using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EjIntegrador_Entidades
{
    public static class ConsolaHelper
    {

        public static string PedirTexto(string ingreso)
        {
            bool estexto = true;
            int numero;
            string texto;
            do
            {
                Console.WriteLine(ingreso);
                estexto = true;
                texto = Console.ReadLine();
                if (int.TryParse(texto, out numero) == true)
                {
                    estexto = false;
                    Console.WriteLine("\n--Lo ingresado es número, debe ser texto --\n");
                }
            } while (estexto == false);
            return texto;
        }
        public static int PedirNumero(string ingreso)
        {
            bool esnumero = false;
            int numero;
            do
            {
                Console.WriteLine(ingreso);
                if (int.TryParse(Console.ReadLine(), out numero) == true)
                    
                    esnumero = true;
                else Console.WriteLine("\n--Lo ingresado no es número --\n");
            } while (esnumero == false);
            return numero;
        }
        public static double PedirDouble(string ingreso)
        {
            bool esdouble = false;
            double numdouble;
            do
            {
                Console.WriteLine(ingreso);
                if (double.TryParse(Console.ReadLine(), out numdouble) == true)
                    esdouble = true;
                else Console.WriteLine("\n--Lo ingresado no es número --\n");
            } while (esdouble == false);
            return numdouble;
        }
        public static DateTime PedirFecha(string ingreso)
        {
            bool esfecha = false;
            DateTime fecha;
            do
            {
                Console.WriteLine(ingreso);
                if (DateTime.TryParse(Console.ReadLine(), out fecha) == true)
                    esfecha = true;
                else Console.WriteLine("\n--Lo ingresado no es fecha --\n");
            } while (esfecha == false);
            return fecha;
        }
        public static void Mensaje(string msj)
        {
            Console.WriteLine(msj);
        }

    }
}
