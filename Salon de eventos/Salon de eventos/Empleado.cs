using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_eventos
{
    public class Empleado
    {
        protected string nombre;
        protected string dni;
        protected string cargo;
        protected string legajo;
        protected int sueldo;
        
        //Atributo autogenerativo
        protected static int id;
        protected int iden;

        public Empleado(string nombre, string dni, string cargo, string legajo, int sueldo)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.cargo = cargo;
            this.legajo = legajo;
            this.sueldo = sueldo;
            
            //Codigo autogenerativo
            id++;
            this.iden = id;     
        }
        public int ID { get { return iden; } }
        public string Nombre { get { return nombre; } }
        public string Dni { get { return dni; } }
        public string Cargo { get { return cargo; } }
        public string Legajo { get { return legajo; } }
        public int Sueldo { set { this.sueldo = value; } get { return sueldo; } }

    }
}
