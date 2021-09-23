using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio_Botta.Clases
{
    class Pack : Producto
    {
        public int Cantidad { get; set; }

        public Pack(int cod, string nom, double pre, int cant) :  base(cod, nom, pre)
        {
            this.Cantidad = cant;
        }

        // Polimorfismo por Abstraccion
        public override double CalcularPrecio()
        {
            return this.Precio * this.Cantidad;
        }

        // Polimorfismo por Herencia
        public override string ToString()
        {
            return "Pack: " + base.ToString() + " | " + Cantidad.ToString();
        }
    }
}
