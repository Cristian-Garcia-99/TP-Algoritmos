using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_eventos
{
    public class HayEventoExeption : Exception
    {
        public string motivo;

        public HayEventoExeption(string motivo)
        {
            this.motivo = motivo;
        }
    }
}
