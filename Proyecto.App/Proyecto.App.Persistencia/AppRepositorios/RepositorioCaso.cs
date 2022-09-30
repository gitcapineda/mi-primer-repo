using System.Collections.Generic;
using Proyecto.App.Dominio;
using System.Linq;

namespace Proyecto.App.Persistencia
{
    public class RepositorioCaso : IRepositorioCaso
    {
        private readonly ApplicationContext _appContext;

        public RepositorioCaso(ApplicationContext contexto)
        {
            _appContext = contexto;
        }

        Caso IRepositorioCaso.Agregar(Caso caso)
        {
            var casoAdicionado = _appContext.Casos.Add(caso);
            _appContext.SaveChanges();
            

            return casoAdicionado.Entity;
        }

        Caso IRepositorioCaso.ObtenerPorId(int id){

            return _appContext.Casos.Where(c => c.casoId == id).Select(c => new Caso{
                casoId = c.casoId,
                fechaInicioCaso = c.fechaInicioCaso,
                descripcionCaso = c.descripcionCaso,
                cantidadTestigos = c.cantidadTestigos,
                direccionJuzgadoAsignado = c.direccionJuzgadoAsignado,
                clienteId = c.clienteId,
                abogadoId = c.abogadoId,
                faseCasoId = c.faseCasoId,
                cliente = c.cliente,
                abogado = c.abogado,
                faseCaso = c.faseCaso
            }).FirstOrDefault();
        }
    }
}