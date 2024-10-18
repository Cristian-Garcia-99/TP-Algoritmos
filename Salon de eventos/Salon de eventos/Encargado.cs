using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_eventos
{
    public class Encargado : Empleado 
    {
        private int sueldo_bonificacion;

        public Encargado(string nombre, string dni, string cargo, string legajo, int sueldo, int sueldo_bonificacion) 
            : base(nombre, dni, cargo, legajo, sueldo)
        {
            this.sueldo_bonificacion = sueldo_bonificacion;
            Sueldo = sueldo * ( 1 + sueldo_bonificacion / 100 );
        }
    }
}
