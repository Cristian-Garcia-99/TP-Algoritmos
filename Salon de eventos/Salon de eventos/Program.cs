using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;
using System.Data;

namespace Salon_de_eventos
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Instancio el salon (NECESARIO)
            Salon molino = new Salon("El Molino");

            //Instancias para debuggear

            //Instancio algunos empleados
            Empleado juan = new Empleado("Juan Rodrigez", "22.000.000", "Cocinero", "111111", 12000);
            Empleado abril = new Empleado("Abril Montes", "24.000.000", "Recepcionista", "222222", 12000);
            Empleado marisol = new Empleado("Marisol Gutierrez", "19.000.000", "Mesa Dulce", "333333", 15000);
            Encargado encargado_marcos = new Encargado("Marcos Di Cecco", "17.000.000", "Encargado", "000000", 15000, 33);
            Encargado encargado_fran = new Encargado("Francisco Lugano", "23.000.000", "Encargado", "010101", 15000, 33);

            //Cargo empleados en salon
            molino.AgregarEmpleado(juan);
            molino.AgregarEmpleado(abril);
            molino.AgregarEmpleado(marisol);
            molino.AgregarEmpleado(encargado_marcos);
            molino.AgregarEmpleado(encargado_fran);

            //Lista servicios predefinido
            ArrayList serviciosPredefinidos = new ArrayList();
            Servicio musica = new Servicio("musica", "dj", "Pasan musica variada", 1, 12000);
            Servicio luces = new Servicio("luces", "técnicos", "Servicio de luces led", 1, 13000);
            Servicio humo = new Servicio("humo", "técnicos", "Servicio de hielo ceco", 1, 9000);
            serviciosPredefinidos.Add(musica);
            serviciosPredefinidos.Add(luces);
            serviciosPredefinidos.Add(humo);

            bool sistema = true;
            string op;

            try 
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al salon {0}", molino.Nombre);

                while (sistema)
                {
                    menu();
                    op = Console.ReadLine();

                    switch (op) 
                    {
                        case "1":
                            sumarServicio(molino); break;
                        case "2":
                            restarServicio(molino); break;
                        case "3":
                          altaEmpleado(molino); break;
                        case "4":
                            bajaEmpleado(molino); break;
                        case "5":
                            reservarEvento(molino, serviciosPredefinidos); break;
                        case "6":
                            cancelarEvento(molino); break;
                        case "7":
                            submenu(molino); break;
                        case "8":
                            sistema = false; break;
                    }    
                }

            }
            catch(Exception)
            {
                Console.WriteLine("Ha ocurrido un error");
            }

            Console.WriteLine("Ha finalizado el programa");
            Console.ReadKey(true);
        }

        //Funciones-------------------------------------------

        //Menu
        static void menu()
        {
            Console.Clear();
            Console.WriteLine("1-Agregar Servicio ");
            Console.WriteLine("2-Eliminar Servicio ");
            Console.WriteLine("3-Alta Empleado ");
            Console.WriteLine("4-Baja Empleado ");
            Console.WriteLine("5-Reservar Evento ");
            Console.WriteLine("6-Cancelar Evento ");
            Console.WriteLine("7-Submenu");
            Console.WriteLine("8-SALIR ");
        }

        //1)AGREGAR SERVICIO----------------------------------

        static void sumarServicio(Salon salon)
        {
            Console.Clear();
            Console.WriteLine("***Agregar Servicio***");

            Console.WriteLine("Fecha del evento que desea modificar");
            Console.Write("dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("mes: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("año: ");
            int año = int.Parse(Console.ReadLine());
            DateTime fecha = new DateTime(año, mes, dia);

            foreach(Evento evento in salon.ListaEventos)
            {
                if(evento.Fecha == fecha)
                {
                    Console.WriteLine("Ingrese nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese Catering: ");
                    string catering = Console.ReadLine();
                    Console.Write("Ingrese descripción: ");
                    string descripcion = Console.ReadLine();
                    int cantidad = 1;
                    Console.Write("Ingrese el costo del servicio: ");
                    int costo_unitario = int.Parse(Console.ReadLine());

                    Servicio servicio = new Servicio(nombre, catering, descripcion, cantidad, costo_unitario);
                    evento.AgregarServicio(servicio);
                    Console.WriteLine("Se ha agregado un servicio");
                    Console.ReadKey(true);
                    return; //Al agregar con éxito el salon sale de la funcion
                }                
            }
            //Si recorrió la lista entera y no encontró el evento
            Console.WriteLine("No se ha econtrado evento con dicha fecha");
            Console.ReadKey(true);
        }

        //2)ELIMINAR SERVICIO---------------------------------

        static void restarServicio(Salon salon)
        {
            Console.Clear();
            Console.WriteLine("***Eliminar Servicio***");

            Console.WriteLine("Fecha del evento que desea modificar");
            Console.Write("dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("mes: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("año: ");
            int año = int.Parse(Console.ReadLine());
            DateTime fecha = new DateTime(año, mes, dia);

            foreach (Evento evento in salon.ListaEventos)
            { 
                if(evento.Fecha == fecha)
                {
                    Console.Write("Escriba el nombre del servicio que desea eliminar: ");
                    string nombre = Console.ReadLine();
                    foreach(Servicio servicio in evento.ListaServicios)
                    {
                        if(servicio.Nombre.ToLower() == nombre.ToLower())
                        {
                            evento.EliminarServicio(servicio);
                            Console.WriteLine("Se ha eliminado el servicio");
                            Console.ReadKey(true);
                            return; //Elimina el servicio y sale de la funcion
                        }
                    }
                    //Si no se encuentra el servicio
                    Console.WriteLine("No se puede eliminar el servicio porque no exiiste");
                    Console.ReadKey(true);
                }
            }
            //Si no se encuentra el evento
            Console.WriteLine("No se ha econtrado evento con dicha fecha");
            Console.ReadKey(true);
        }

        //3)ALTA----------------------------------------------
        static void altaEmpleado(Salon salon)
        {
            Console.Clear();
            Console.WriteLine("***Alta de empleado***");

            Console.Write("Ingrese Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese DNI XX.XXX.XXX: ");
            string dni = Console.ReadLine();
            Console.Write("Ingrese Cargo: ");
            string cargo = Console.ReadLine();
            Console.Write("Ingrese legajo XXXXXX: ");
            string legajo = Console.ReadLine();
            Console.Write("ingrese sueldo: ");
            int sueldo = int.Parse(Console.ReadLine());

            if (cargo.ToLower() == "encargado")
            {
                Console.Write("Ingrese bonificacion (Del 1 al 99): ");
                int bonificacion = int.Parse(Console.ReadLine());
                Encargado encargado = new Encargado(nombre, dni, cargo, legajo, sueldo, bonificacion);
                salon.AgregarEmpleado(encargado);
            }
            else
            {
                Empleado empleado = new Empleado(nombre, dni, cargo, legajo, sueldo); 
                salon.AgregarEmpleado(empleado);
            }
            Console.WriteLine("Se ha dado de alta al empleado");
            Console.ReadKey(true);
        }
        
        //4)BAJA------------------------------------------
        static void bajaEmpleado(Salon salon)
        {
            Console.Clear();
            Console.WriteLine("***Baja de empleado***");

            Console.WriteLine("Esvriba el legajo del empleado que desea dar de baja: ");
            string legajo = Console.ReadLine();
            foreach (Empleado empleado in salon.Empleados_fijos)
            {
                if(empleado.Legajo == legajo)
                {
                    salon.EliminarEmpleado(empleado);
                    Console.WriteLine("Se ha dado de baja al empleado");
                    Console.ReadKey(true);
                    return; //Elimina el empleado y sale de la funcion
                }
            }
            //Si no se ha coincidido el legajo con ningun empleado
            Console.WriteLine("No se ha encontrado el empleado");
            Console.ReadKey(true);
        }

        //5)RESERVAR EVENTO-------------------------------
        static void reservarEvento(Salon salon, ArrayList servicios_predefinidos)
        {
            Console.Clear();
            Console.WriteLine("***Reserva de Evento***");

            Console.Write("Nombre de cliente: ");
            string cliente = Console.ReadLine();
            Console.Write("dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("mes: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("año: ");
            int año = int.Parse(Console.ReadLine());
            DateTime fecha = new DateTime(año, mes, dia);
            //DateTime fecha = DateTime.Now;
            try
            {
                foreach(Evento ev in salon.ListaEventos)
                {
                    if(ev.Fecha == fecha)
                    {
                        //Si la fecha ingresada se encuentra ya registrada se genera el error
                        throw new HayEventoExeption("Ya hay un evento en esta fecha");
                    }
                }
            }
            catch(HayEventoExeption ex)
            {
                //El error se captura y sale de la funcion
                //Evitando llegar a la parte en la que se instancia el Evento mas abajo
                Console.Clear();
                Console.WriteLine(ex.motivo);
                Console.ReadKey(true);
                return;
            }
            //Se continua y se permite instanciar el evento

            Console.Write("Tipoo de evento: ");
            string tipo = Console.ReadLine();
            //Instancio este Encargado para evitar un warning molesto de VScode
            Encargado encargado = new Encargado("aux", "aux", "aux", "aux", 11, 11);
            Console.WriteLine("Lista de encargados");
         
            //Muestra lista de encargados
            foreach(Empleado enc in salon.Empleados_fijos)
            {
                if(enc.Cargo.ToLower() == "encargado")
                    Console.WriteLine("+ Nombre: {0}, Legajo: {1}", enc.Nombre, enc.Legajo);
            }
            Console.Write("Legajo del encargado: ");
            string legajo = Console.ReadLine();
           foreach (Empleado enc in salon.Empleados_fijos)
           {
                if (enc.Legajo == legajo) encargado = (Encargado)enc;     
           }
            Console.Write("Estado del evento: ");
            string estado = Console.ReadLine();

            Evento evento = new Evento(cliente, fecha, tipo, estado, encargado);
            salon.AgregarEvento(evento);
            Console.WriteLine("Se ha creado el evento");
            Console.ReadKey(true);

            Console.WriteLine("Lista de servicios");
            //Estos son los predefinidos, no rompo el encapsulamiento, ya se que los guardé en un array!!!
            foreach(Servicio servicio in servicios_predefinidos)
            {
                Console.WriteLine("Nombre:{0} || Descripción:{1}", servicio.Nombre, servicio.Descripcion);
            }

            Console.WriteLine("Desea Agregar un servicio Existente ?");
            Console.WriteLine("1-si, 2-No");
            string op = Console.ReadLine();
            while (op != "2")
            { 
                Console.Write("Nombre del sevicio: ");
                string nombre = Console.ReadLine();
                foreach (Servicio servicio in servicios_predefinidos)
                    if (servicio.Nombre == nombre)
                        evento.AgregarServicio(servicio);
                
                Console.WriteLine("Desea Agregar un servicio Existente ?");
                Console.WriteLine("1-si, 2-No");
                op = Console.ReadLine();

            }
            Console.ReadKey(true);
        }

        //6)CANCELAR EVENTO---------------------------------------
        static void cancelarEvento(Salon salon)
        {
            Console.Clear();
            Console.WriteLine("***Cancelar Evento***");

            Console.WriteLine("Fecha del evento que desea cancelar");
            Console.Write("dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("mes: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("año: ");
            int año = int.Parse(Console.ReadLine());

            foreach(Evento evento in salon.ListaEventos)
            {
                if(evento.Fecha.Day == dia && evento.Fecha.Month == mes && evento.Fecha.Year == año)
                {
                    salon.EliminarEvento(evento);
                    Console.WriteLine("El evento ha sido cancelado");
                    Console.ReadKey(true);
                    return; //Se elimina el evento y sale de la funcion
                }
            }
            //Si no se encuentra el evento
            Console.WriteLine("No se encontró evento con esa fecha");
            Console.ReadKey(true);
        }

        //7)SUBMENU--------------------------------------------
        static void submenu(Salon salon)
        {
            Console.Clear();
            Console.WriteLine("***Submenu***");
            
            string op;
            Console.WriteLine("1-Todos los eventos, Cliente y Tipo");
            Console.WriteLine("2-Todos los empleados");
            Console.WriteLine("3-Eventos de un mes");
            Console.WriteLine("4-Salir");
            op = Console.ReadLine();
            while (op != "4")
            {
                switch (op)
                {
                    case "1":
                        //Si no hay eventos cargados
                        if(salon.CantidadEvento() == 0)
                            Console.WriteLine("No hay eventos cargados");
                        
                        //Si hay eventos
                        foreach (Evento evento in salon.ListaEventos)
                            Console.WriteLine("Cliente: {0}, Tipo: {1} año: {2} mes:{3}, dia:{4}", evento.Cliente, evento.Tipo, evento.Fecha.Year, evento.Fecha.Month, evento.Fecha.Day);
                        
                        Console.ReadKey(true);
                        break;
                    
                    case "2":
                        foreach (Empleado empleado in salon.Empleados_fijos)
                            Console.WriteLine("ID: {0}, Nombre: {1}, Legajo: {2}, Cargo: {3}", empleado.ID ,empleado.Nombre, empleado.Legajo, empleado.Cargo);
                        Console.ReadKey(true);
                        break;
                    
                    case "3":
                        //Si no hay eventos cargados
                        if (salon.CantidadEvento() == 0)
                        {
                            Console.WriteLine("No hay eventos cargados");
                            Console.ReadKey(true);
                            break;
                        }    

                        //Si hay eventos muestra el de un mes ingresado
                        Console.Write("Ingrese el numero de mes con 2 digitos: ");
                        int mes = int.Parse(Console.ReadLine());
                        foreach(Evento evento in salon.ListaEventos)
                        {
                            if(evento.Fecha.Month == mes)
                                Console.WriteLine("Cliente: {0}, Tipo: {1} año: {2} mes:{3}, dia:{4}", evento.Cliente, evento.Tipo, evento.Fecha.Year, evento.Fecha.Month, evento.Fecha.Day);
                        }
                        Console.ReadKey(true);
                        break;
                    
                    default:
                        break;

                }
                Console.Clear();
                Console.WriteLine("1-Todos los eventos, Cliente y Tipo");
                Console.WriteLine("2-Todos los empleados");
                Console.WriteLine("3-Eventos de un mes");
                Console.WriteLine("4-Salir");
                op = Console.ReadLine();
            }         
        }
    }
}
