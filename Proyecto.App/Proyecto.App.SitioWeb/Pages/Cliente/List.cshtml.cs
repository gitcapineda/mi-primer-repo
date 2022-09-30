using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Agregar dominio y persistencia
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.SitioWeb.App.Pages
{

    public class ListModel : PageModel
    {
        public IEnumerable<Cliente> clientes {get; set;}
        private IRepositorioCliente _repoCliente;

        public ListModel()
        {
            _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.ApplicationContext());
        }

        public void OnGet()
        {
            clientes = _repoCliente.ObtenerTodos();
        }
    }
}
