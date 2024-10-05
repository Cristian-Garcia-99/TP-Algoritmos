using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_eventos
{
    public class Servicio
    {
        private string nombre;
        private string catering;
        private string descripcion;
        private int cantidad;
        private int costo_unitario;
        private int costo;

        public Servicio(string nombre, string catering, string descripcion, int cantidad, int costo_unitario)
        {
            this.nombre = nombre;
            this.catering = catering;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.costo_unitario = costo_unitario;
            this.costo = costo_unitario * cantidad;
        }

        public string Nombre { get { return nombre; } }
        public string Catering { get { return catering; } }
        public string Descripcion { get { return descripcion; } }
        public int Costo { get { return costo; } }
    }
}
