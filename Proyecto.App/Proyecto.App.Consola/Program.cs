using System;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.Consola
{
    class Program
    {
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.ApplicationContext());
        private static IRepositorioCaso _repoCaso = new RepositorioCaso(new Proyecto.App.Persistencia.ApplicationContext());

        static void Main(string[] args)
        {
            Console.WriteLine("ABOGADOS APP");
            //AgregarCliente();
            //ModificarCliente();
            //BorrarCliente();
            //BuscarCliente();
            //ObtenerClientes();
            //AgregarCaso();
            BuscarCaso();
        } 

        private static void BuscarCaso()
        {
            // pedir el id del caso a buscar
            Console.WriteLine("Ingrese el id del caso a buscar");
            int idCaso = int.Parse(Console.ReadLine());

            // buscar el caso
            Caso caso = _repoCaso.ObtenerPorId(idCaso);

            // mostrar el caso
            Console.WriteLine("CASO:" + caso.casoId 
            +" "+ caso.descripcionCaso 
            +" "+caso.fechaInicioCaso
            +" "+caso.cantidadTestigos
            +" "+caso.direccionJuzgadoAsignado
            +" "+caso.cliente.nombre
            +" "+caso.cliente.apellido
            +" "+caso.abogado.nombre
            +" "+caso.faseCaso.nombreFase);
        }

        private static void AgregarCaso()
        {
            // Instanciar la entidad
            Caso caso = new Caso();
            
            // Pedir al usuario los datos del caso
            Console.WriteLine("Ingrese la fecha del caso");
            caso.fechaInicioCaso = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la descripcion del caso");
            caso.descripcionCaso = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad de testigos");
            caso.cantidadTestigos = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la direccion del juzgado");
            caso.direccionJuzgadoAsignado = Console.ReadLine();

            // Asignamos las relaciones
            Console.WriteLine("Ingrese el id del cliente");
            caso.clienteId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del abogado");
            caso.abogadoId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id de la fase del caso");
            caso.faseCasoId = int.Parse(Console.ReadLine());
            
            // Invocamos al repositorio
            _repoCaso.Agregar(caso);
        }

        private static void ObtenerClientes()
        {
            // Traer todos los clientes (lista)
            var clientes = _repoCliente.ObtenerTodos();
            // Recorrer y mostrar los clientes
            foreach (var cliente in clientes)
            {
                Console.WriteLine(cliente.nombre + " " + cliente.apellido+ " " + cliente.edad+ " " + cliente.genero);
            }
        }

        private static void BuscarCliente()
        {
            // pedir el id del cliente a buscar
            Console.WriteLine("Ingrese el id del cliente a buscar");
            int id = int.Parse(Console.ReadLine());

            // buscar el cliente
            Cliente cliente = _repoCliente.ObtenerPorId(id);
            Console.WriteLine("El cliente es: " + cliente.nombre + " " + cliente.apellido + " " + cliente.edad + " " + cliente.genero);
        }

        private static void BorrarCliente(){
            // Pedir el id del cliente a borrar
            Console.WriteLine("Ingrese el id del cliente a borrar");
            int id = int.Parse(Console.ReadLine());
            _repoCliente.Eliminar(id);
        }

        public static void ModificarCliente(){
            // Pedir el id del cliente a modificar
            Console.WriteLine("Ingrese el id del cliente a modificar");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = _repoCliente.ObtenerPorId(id);

            // Pedir los nuevos datos
            Console.WriteLine("Ingrese el nuevo nombre");
            cliente.nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo apellido");
            cliente.apellido = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva edad");
            cliente.edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo genero");
            cliente.genero = (Genero) int.Parse(Console.ReadLine());

            _repoCliente.Modificar(cliente);
        }

        public static void AgregarCliente()
        {
            Console.WriteLine("Agregar un cliente");
            // Instanciar la entidad
            Cliente clienteNuevo = new Cliente();
            // Obtener los datos del cliente
            Console.WriteLine("Escriba el nombre del cliente:");
            clienteNuevo.nombre = Console.ReadLine();
            Console.WriteLine("Escriba el apellido del cliente:");
            clienteNuevo.apellido = Console.ReadLine();
            Console.WriteLine("Escriba el edad del cliente:");
            clienteNuevo.edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el genero del cliente: (0 Masculino 1 Femenino 2 No binario)");
            clienteNuevo.genero = (Genero)Enum.Parse(typeof(Genero),Console.ReadLine());
            
            //Invocamos al repositorio
            _repoCliente.Agregar(clienteNuevo);
        }
    }
}