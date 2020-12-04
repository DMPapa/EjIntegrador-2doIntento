using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjIntegrador_Entidades
{
    public class Salario
    {
        private double _bruto;
        private string _codigoTransferencia;
        private double _descuentos;
        private DateTime _fecha;

        public double Bruto
        {
            get { return this._bruto; }
            set { this._bruto = value; }
        }
        public string CodigoTransferencia
        {
            get { return this._codigoTransferencia; }
            set { this._codigoTransferencia = value; }
        }
        public double Descuentos
        {
            get { return this._descuentos; }
            set { this._descuentos = value; }
        }
        public DateTime Fecha
        {
            get { return this._fecha; }
        }

        public Salario(double bruto, string codigotransferencia)
        {
            this._bruto = bruto;
            this._codigoTransferencia = codigotransferencia;
            this._descuentos = bruto * 0.17;
            this._fecha = DateTime.Now;
        }
            public double GetSalarioNeto()
        {
            return (this._bruto - this._descuentos);
        }
    }
}
