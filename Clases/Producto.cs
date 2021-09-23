using Comercio_Botta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio_Botta.Clases
{
    abstract class Producto : IPrecio
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(int cod, string nom, double pre)
        {
            this.Codigo = cod;
            this.Nombre = nom;
            this.Precio = pre;
        }

        public abstract double CalcularPrecio();

        public override string ToString()
        {
            // this.CalcularPrecio().ToString() funciona pq cuando el producto se agrega a la lista hace dos cosas,
            // por un lado atualiza su colecion de items y almacena mi objeto y por otra muesta la lista el objeto suelto o pack
            // cuando ese objeto es agregado a la lista se llama al ToString() del nuevo, cuando llama al ToString() del producto
            // el this.CalcularPrecio apunta al objeto real en memoria que seria un suelto o pack por eso puede ir a calcular
            // precio
            // Primero se ejecuta en las clases hijas, de ahi llama a la clase padre o base cuando la necesita
            // Polimorfismo -> dependiendo de cual sea el objeto el mensaje me va a responder de una forma u otra
            return Codigo.ToString() + " | " + Nombre + " | $" + this.CalcularPrecio().ToString();
        }
    }
}
