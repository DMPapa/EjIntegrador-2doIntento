using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjIntegrador_Entidades
{
    public static class Validacion
    {
        public static string ValidarNumero(string input, string campoEsperado)
        {
            int nro;
            string error="";
            if (!int.TryParse(input, out nro))
            {
                error = campoEsperado + " debe ser numérico" + "\n";
            }
            else if (nro < 0){
                error = campoEsperado + " debe ser positivo" + "\n";
            }
            return error;
        }
        public static string ValidarFloat(string input, string campoEsperado)
        {
            float nro;
            string error = "";
            if (!float.TryParse(input, out nro))
            {
                error = campoEsperado + " debe ser float" + "\n";
            }
            return error;
        }
        public static string ValidarDouble(string input, string campoEsperado)
        {
            double nro;
            string error = "";
            if (!double.TryParse(input, out nro))
            {
                error = campoEsperado + " debe ser double" + "\n";
            }
            return error;
        }
        public static string ValidarString (string input, string campoEsperado)
        {
            string error = "";
            if (input == "")
            {
                error =campoEsperado + " no puede ser vacío" + "\n";
            }
            return error;
        }
        public static string ValidarComboBox (int num, string campoEsperado)
        {
            string error = "";
            if (num == -1)
            {
                error = "Seleccione un " + campoEsperado + "\n";
            }
            return error;
        }
        public static string ValidarFecha(DateTime input, string campoEsperado)
        {
            string error = "";
            if (input <= DateTime.Today)
            {
                error = campoEsperado + " la fecha debe ser posterior al día de hoy" + "\n";
            }
            return error;
        }

    }
}
