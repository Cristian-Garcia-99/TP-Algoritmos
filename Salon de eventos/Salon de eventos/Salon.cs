using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Salon_de_eventos
{
    public class Salon
    {
        private string nombre;
        private ArrayList listaEventos;
        private ArrayList empleados_fijos;

        public Salon(string nombre)
        {
            this.nombre = nombre;
            this.listaEventos = new ArrayList();
            this.empleados_fijos = new ArrayList();
        }

        //---------------------------------------------------------

        public string Nombre { get { return nombre; } }

        //---------------------------------------------------------

        public void AgregarEmpleado(Empleado empleado)
        {
            empleados_fijos.Add(empleado);
        }

        public void EliminarEmpleado(Empleado empleado)
        { 
            empleados_fijos.Remove(empleado);
        }

        public int CantidadEmpleado()
        { 
            return empleados_fijos.Count;
        }

        public bool ExisteEmpleado(Empleado empleado)
        {
            return empleados_fijos.Contains(empleado);
        }

        public Empleado VerEmpleado(int i)
        {
            return (Empleado)empleados_fijos[i];
        }

        public ArrayList Empleados_fijos { get { return empleados_fijos; } }

        //---------------------------------------------------------

        public void AgregarEvento(Evento evento)
        { 
            listaEventos.Add(evento);
        }

        public void EliminarEvento(Evento evento)
        { 
            listaEventos.Remove(evento);
        }

        public int CantidadEvento(int i)
        {
            return listaEventos.Count;
        }

        public bool ExisteEvento(Evento evento) 
        {
            return listaEventos.Contains(evento);
        }

        public Evento VerEvento(int i)
        { 
            return (Evento)listaEventos[i];
        }

        public ArrayList ListaEventos { get { return listaEventos; } }
    }
}
