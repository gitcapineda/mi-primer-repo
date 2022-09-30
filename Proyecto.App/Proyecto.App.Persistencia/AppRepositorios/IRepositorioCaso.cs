using System.Collections.Generic;
using Proyecto.App.Dominio;

namespace Proyecto.App.Persistencia
{
    public interface IRepositorioCaso
    {
        Caso Agregar(Caso caso);
        Caso ObtenerPorId(int id);
    }
}