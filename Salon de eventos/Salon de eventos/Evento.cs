using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Salon_de_eventos
{
    public class Evento
    {
        private string cliente;
        private DateTime fecha;
        private string tipo;
        private string estadoEvento;
        private Encargado encargado;
        private ArrayList listaServicios;

        public Evento(string cliente, DateTime fecha, string tipo, string estadoEvento, Encargado encargado)
        {
            this.cliente = cliente;
            this.fecha = fecha;
            this.tipo = tipo;
            this.estadoEvento = estadoEvento;
            this.encargado = encargado;
            this.listaServicios = new ArrayList();
        }

        //---------------------------------------------------------

        public string Cliente { get { return cliente; } }
        public DateTime Fecha { get { return fecha; } }
        public string Tipo { get { return tipo; } }
        public string EstadoEvento { get { return estadoEvento; } }
        public Encargado Encargado { set { encargado = value; } get { return encargado; } }

        //---------------------------------------------------------
        public void AgregarServicio(Servicio servicio)
        {
            listaServicios.Add(servicio);
        }
        
        public void EliminarServicio(Servicio servicio)
        {
            listaServicios.Remove(servicio);
        }

        public int CantidadServicio()
        {
            return listaServicios.Count;
        }

        public bool ExisteServicio(Servicio servicio)
        { 
            return listaServicios.Contains(servicio);
        }

        public Servicio VerServicio(int i)
        {
            return (Servicio)listaServicios[i];
        }

        public ArrayList ListaServicios { get { return listaServicios; } }
    }
}
