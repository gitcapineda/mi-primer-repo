using System.Collections.Generic;
using Proyecto.App.Dominio;
using System.Linq;

namespace Proyecto.App.Persistencia
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly ApplicationContext _appContext;

        public RepositorioCliente(ApplicationContext contexto)
        {
            _appContext = contexto;
        }


        Cliente IRepositorioCliente.Agregar(Cliente clientenuevo)
        {
            var clienteA = _appContext.Clientes.Add(clientenuevo);
            _appContext.SaveChanges();
            return clienteA.Entity;
        }
        
        Cliente IRepositorioCliente.Modificar(Cliente clienteactualizar)
        {
            var clienteU = _appContext.Clientes.FirstOrDefault(c => c.clienteId == clienteactualizar.clienteId);
            if (clienteU != null)
            {
                clienteU.nombre = clienteactualizar.nombre;
                clienteU.apellido = clienteactualizar.apellido;
                clienteU.edad = clienteactualizar.edad;
                clienteU.genero = clienteactualizar.genero;
                _appContext.SaveChanges();
            }
            return clienteU;
        }
        
        void IRepositorioCliente.Eliminar(int id)
        {
            var clienteB = _appContext.Clientes.FirstOrDefault(c => c.clienteId == id);
            if (clienteB != null)
            {
                _appContext.Clientes.Remove(clienteB);
                _appContext.SaveChanges();
            }
        }
        
        Cliente IRepositorioCliente.ObtenerPorId(int id){
            return _appContext.Clientes.FirstOrDefault(c => c.clienteId == id);
        }
        
        IEnumerable<Cliente> IRepositorioCliente.ObtenerTodos()
        {
            return _appContext.Clientes; 
        }
    }
}