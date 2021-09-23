using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio_Botta.Interfaces
{
    interface IPrecio
    {
        // Se dice que es un contrato pq todo lo que este en la Interfaz la Clase tiene que implementarlo
        // Cumple la funcion de obligar a una clase a implementar determinados metodos
        // Polimorfismo por interfaz
        double CalcularPrecio();
    }
}
