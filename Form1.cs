using Comercio_Botta.Clases;
using Comercio_Botta.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercio_Botta
{
    public partial class Frm_Productos : Form
    {
        // List<Producto> lProductos = new List<Producto>();

        // Es una Lista de IPrecio, funciona pq un pack es un producto y un suelto es un producto y como cualquier cosa que sea UN PRODUCTO se comprometio a implementar
        // un COMPORTAMIENTO que es el CalcularPrecio, yo me puedo dar el lujo de manejar una lista de cosas que sean IPrecio
        // A esta lista me pueden agregar cualquier cosa a la que yo le pueda calcular un precio y puedo mezclar cosas que no necesariamente estan en la misma jerarquia,
        // en este caso si pq forman parte de lo mismo pero podria darme el lujo de agregar cualquier cosa a la que le pueda asignar un precio, entonces yo podria tener
        // una lista de pack, suelto y posteriormente podria agregar vuelos o cuaquier cosa a la que le pueda calcular precios.
        // Las interfaces me dan reutilizacion y flexibildiad que es lo que buscamos simpre cuando programamos.
        // Que uno programe contra interfaces quiere decir que siempre en el codigo que uno escribe no use las clases concretes, sino que referencie a traves de interfaces,
        // pq las clases concretas son las implementaciones de las interfaces y eso puede variar, pero si vos siempre a los objetos los miras a traves de las interfaces
        // que implementan tu codigo es mil veces mas flexible.
        // Programar en interfaces me independiza o me divide el que del como, el chiste es el como varie pero el que sea siempre el mismo.

        private List<IPrecio> lProductos = new List<IPrecio>();

        TipoProducto miTipo; // defino mi variable de tipo TipoProducto que puede tomar los valores de Suelto o Pack
        private enum TipoProducto // implementar a Insert o Update carpinteria
        {
            Suelto,
            Pack,
            Envasado = 10
        }

        public Frm_Productos()
        {
            InitializeComponent();
            rbSuelto.Checked = true;
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtExtra.Text = "";
        }

        private void rbSuelto_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
            lblExtra.Text = "Medida";
            miTipo = TipoProducto.Suelto;
        }

        private void rbPack_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
            lblExtra.Text = "Cantidad";
            miTipo = TipoProducto.Pack;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCodigo.Text)
                || String.IsNullOrEmpty(txtNombre.Text)
                || String.IsNullOrEmpty(txtPrecio.Text)
                || String.IsNullOrEmpty(txtExtra.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            int cod;
            string nom;
            double pre;
            int cantMed;

            try
            {
                cod = Int32.Parse(txtCodigo.Text);
                pre = Double.Parse(txtPrecio.Text);
                cantMed = int.Parse(txtExtra.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valor de Campo Numerico incorrecto!");
                return;
            }
            nom = txtNombre.Text;


            Producto nuevo = null;
            // if (rbPack.Checked)
            if(miTipo == TipoProducto.Pack)
            {
                // Cargar Pack (implementable no como Producto que es abstracto)
                nuevo = new Pack(cod, nom, pre, cantMed);
            } else
            {
                // Cargar Suelto (implementable no como Producto que es abstracto)
                nuevo = new Suelto(cod, nom, pre, cantMed);
            }
            lProductos.Add(nuevo);
            lstProductos.Items.Clear();

            // La lista sola al agregar llama al propio ToString() de cada objeto que se encuentra dentro de la List
            lstProductos.Items.AddRange(lProductos.ToArray());
        }

        private void btnActualizarTotal_Click(object sender, EventArgs e)
        {
            double total = 0;
            //for(int i = 0; i < lProductos.Count; i++)
            //{
            //    total += lProductos[i].CalcularPrecio();
            //}

            foreach (IPrecio x in lProductos)
            {
                total += x.CalcularPrecio();
            }

            txtTotal.Text = total.ToString();
        }
    }
}
