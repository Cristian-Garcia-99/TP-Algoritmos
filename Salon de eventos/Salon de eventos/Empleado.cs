﻿using System;
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

        public Empleado(string nombre, string dni, string cargo, string legajo, int sueldo)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.cargo = cargo;
            this.legajo = legajo;
            this.sueldo = sueldo;
        }

        public string Nombre { get { return nombre; } }
        public string Dni { get { return dni; } }
        public string Cargo { get { return cargo; } }
        public int Sueldo { set { this.sueldo = value; } get { return sueldo; } }

    }
}